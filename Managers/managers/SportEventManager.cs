using ApplicationCore.Models;
using ApplicationCore.Models.req;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Managers.managers
{
    public class SportEventManager : ISportEventManager
    {
        private readonly ISportEventsRepository _sportEventsRepository;
        private readonly IObjectRepository _objectRepository;
        private readonly IUserRepository _userRepository;

        public SportEventManager(
            ISportEventsRepository sportEventsRepository,
            IObjectRepository objectRepository,
            IUserRepository userRepository)
        {
            _sportEventsRepository = sportEventsRepository;
            _objectRepository = objectRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateSportEvent(CreateSportEventReq sportEvent)
        {
            var createdBy = _userRepository.GetUserEmailFromToken();
            var objectDb = await _objectRepository.GetObjectById(sportEvent.ObjectId);
            var result = false;
            if(objectDb != null)
            {
                var sportEventDb = SportEventMapper.FromSportEventToEntityInsertReq(sportEvent, objectDb);
                sportEventDb.CreatedBy = createdBy;
                var executeInfo = await _sportEventsRepository.CreateSportEvent(sportEventDb);

                if (executeInfo.Result)
                {
                    var currentUserMoney = await _userRepository.GetUserMone(createdBy);

                    if(currentUserMoney != null)
                    {
                        var cost = (sportEvent.Time * objectDb.PricePerHour) / sportEvent.AmountOfPlayers;
                        if(currentUserMoney - cost > 0)
                        {
                            double money = (double)currentUserMoney - cost;
                            
                            await _userRepository.UpdateUserMoney(createdBy, money);
                        }
                        else
                        {
                            return false;
                        }

                    }                   

                    JsonArray assignersArray = new JsonArray(createdBy);
                    var assignersArrayJson = JsonSerializer.Serialize(assignersArray);

                    EventAssignersEntity assigners = new EventAssignersEntity()
                    {
                        EventId = executeInfo.resultEntity.Id,
                        SportEvent = executeInfo.resultEntity,
                        AssignedPeople = assignersArrayJson
                    };

                    result = await _sportEventsRepository.CreateAssignedPeopleRecord(assigners);
                }
            }
            return result;
        }

        public async Task<IEnumerable<SportEvent>> GetCurrentLoggedUserEventsAssignedTo()
        {
            var dataDb = await _sportEventsRepository.GetAllSportEvents();
            var currentUserEmail = _userRepository.GetUserEmailFromToken();
            var result = new List<SportEvent>();

            if (!string.IsNullOrEmpty(currentUserEmail))
            {
                foreach(var item in dataDb)
                {
                    var usersInEvent = await _sportEventsRepository.GetAssignersInEvent(item.Id);
                    if(!string.IsNullOrEmpty(usersInEvent) && usersInEvent.Contains(currentUserEmail))
                    {
                        var assignersInTheEvent = JsonSerializer.Deserialize<List<string>>(usersInEvent);
                        var sportEvent = SportEventMapper.FromEntityToSportEvent(item);
                        sportEvent.PeopleAssigned = assignersInTheEvent.Count();
                        sportEvent.IsActive = true;
                        sportEvent.CurrentUserAssignedToEvent = true;

                        sportEvent.Price = await CaclulateSportEventPrice(item);

                        if (sportEvent.IsActive == false)
                        {                          
                            await Task.WhenAll(ReturnMoneyIfEventExpired(assignersInTheEvent, sportEvent.Price), _sportEventsRepository.DeleteSportEvent(item.Id));
                            continue;
                        }

                        result.Add(sportEvent);
                    }
                }
            }
            return result;
        }

        private async Task ReturnMoneyIfEventExpired(List<string> assigners ,double price)
        {
            foreach(var user in assigners)
            {
                var currentUserMoney = await _userRepository.GetUserMone(user);
                if(currentUserMoney != null)
                {
                    var userMoneyParsed = (double)currentUserMoney;
                    await _userRepository.UpdateUserMoney(user, userMoneyParsed + price);
                }
            }
        }

        private async Task<double> CaclulateSportEventPrice(SportEventEntity item)
        {
            var sportObj = await _objectRepository.GetObjectById(item.ObjectId);
            double result = 0;

            if (sportObj?.PricePerHour != null)
            {
                if (item.AmountOfPlayers != 0)
                {
                    var price = (sportObj.PricePerHour * item.Time) / item.AmountOfPlayers;

                    result = price;
                }        
            }
            return result;
        }

        public async Task<IEnumerable<SportEvent>> GetAllSportEvents()
        {
            var dataDb = await _sportEventsRepository.GetAllSportEvents();
            var currentUserEmail = _userRepository.GetUserEmailFromToken();

            var result = new List<SportEvent>();

            foreach(var item in dataDb)
            {
                var sportEvent = SportEventMapper.FromEntityToSportEvent(item);
                sportEvent.IsActive = true;
                var assignersInTheEventString = await _sportEventsRepository.GetAssignersInEvent(item.Id);

                sportEvent.Price = await CaclulateSportEventPrice(item);

                if (!string.IsNullOrEmpty(assignersInTheEventString))
                {
                    var assignersInTheEvent = JsonSerializer.Deserialize<List<string>>(assignersInTheEventString);
                    sportEvent.PeopleAssigned = assignersInTheEvent.Count;

                    if(sportEvent.IsActive == false)
                    {
                        await ReturnMoneyIfEventExpired(assignersInTheEvent, sportEvent.Price);
                    }

                    if (assignersInTheEvent != null && assignersInTheEvent.Contains(currentUserEmail))
                    {
                        sportEvent.CurrentUserAssignedToEvent = true;
                    }
                }   
                if(sportEvent.IsActive == false)
                {
                    await _sportEventsRepository.DeleteSportEvent(item.Id);
                    continue;
                }
                result.Add(sportEvent);
            }
            return result;
        }

        private bool CheckCanModify(SportEventEntity entity)
        {
            var role = _userRepository.CheckIfAdmin();
            var currentUserEmail = _userRepository.GetUserEmailFromToken();

            if (role)
            {
                return true;
            }
            else if(currentUserEmail == entity.CreatedBy)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSportEvent(CreateSportEventReq sportEvent, int id)
        {
            var result = false;
            var sportEventDb = await _sportEventsRepository.GetSportEventById(id);

            if (!CheckCanModify(sportEventDb))
            {
                return false;
            }

            if(sportEventDb != null)
            {
                if(sportEvent?.ObjectId != null)
                {
                    var objectDb = await _objectRepository.GetObjectById(sportEvent.ObjectId);
                    if(objectDb != null)
                    {
                        var updatedEntity = SportEventMapper.FromSportEventToEntityInsertReq(sportEvent, objectDb);
                        updatedEntity.CreatedBy = sportEventDb.CreatedBy;
                        updatedEntity.Id = sportEventDb.Id;
                        result = await _sportEventsRepository.UpdateSportEvent(id, updatedEntity);
                    }
                }
            }
            return result;
        }

        public async Task<bool> DeleteSportEvent(int id)
        {
            var result = false;
            var sportEventDb = await _sportEventsRepository.GetSportEventById(id);
            var assignersInTheEventString = await _sportEventsRepository.GetAssignersInEvent(id);
            var price = await CaclulateSportEventPrice(sportEventDb);


            if (!CheckCanModify(sportEventDb))
            {
                return result;
            }

            if (!string.IsNullOrEmpty(assignersInTheEventString))
            {
                var assignersInTheEvent = JsonSerializer.Deserialize<List<string>>(assignersInTheEventString);
                if(assignersInTheEvent?.Count > 0)
                {
                    await ReturnMoneyIfEventExpired(assignersInTheEvent, price);
                }
            }

            result = await _sportEventsRepository.DeleteSportEvent(id);
            return result;

        }

        public async Task<bool> AssignOrRemoveFromEvent(int sportEventId, string operationType)
        {
            var result = false;
            var currentAssigners = await _sportEventsRepository.GetAssignersInEvent(sportEventId);
            var currentUserEmail = _userRepository.GetUserEmailFromToken();
            var sportEvent = await _sportEventsRepository.GetSportEventById(sportEventId);
            var objectDb = await _objectRepository.GetObjectById(sportEvent.ObjectId);
            

            if (!string.IsNullOrEmpty(currentAssigners))
            {
                var currentAssignersArrayDb = JsonSerializer.Deserialize<List<string>>(currentAssigners);
                var currentAssignersArray = JsonSerializer.Deserialize<List<string>>(currentAssigners);


                if (!string.IsNullOrEmpty(currentUserEmail))
                {
                    if (!currentAssignersArray.Contains(currentUserEmail) && operationType == "add")
                    {
                        currentAssignersArray.Add(currentUserEmail);
                        if(!await OperationOnUserMoney(objectDb, sportEvent, currentUserEmail, "add"))
                        {
                            return false;
                        }
                    }
                    else if (currentAssignersArray.Contains(currentUserEmail) && operationType == "remove")
                    {
                        currentAssignersArray.Remove(currentUserEmail);
                        if(!await OperationOnUserMoney(objectDb, sportEvent, currentUserEmail, "remove"))
                        {
                            return false;
                        }
                    }               
                    if (currentAssignersArray.Count != currentAssignersArrayDb.Count)
                    {
                        var currentAssignersJsonArray = JsonSerializer.Serialize(currentAssignersArray);
                        result = await _sportEventsRepository.AssignOrRemoveFromEvent(sportEventId, currentAssignersJsonArray);
                    }
                }
            }
            else
            {
                if (operationType == "add")
                {
                    var assignersList = new List<string>();
                    assignersList.Add(currentUserEmail);

                    var currentAssignersJsonArray = JsonSerializer.Serialize(assignersList);
                    result = await _sportEventsRepository.AssignOrRemoveFromEvent(sportEventId, currentAssignersJsonArray);

                    if(!await OperationOnUserMoney(objectDb, sportEvent, currentUserEmail, "add"))
                    {
                        return false;
                    }
                }
            }

            return result;
        }

        private async Task<bool> OperationOnUserMoney(ObjectEntity objectDb, SportEventEntity sportEvent, string currentUserEmail,string operation)
        {
            if (objectDb?.PricePerHour != null)
            {
                if (sportEvent.AmountOfPlayers != 0)
                {
                    var price = (objectDb.PricePerHour * sportEvent.Time) / sportEvent.AmountOfPlayers;
                    var currentUserMoney = await _userRepository.GetUserMone(currentUserEmail);
                    if (currentUserMoney != null)
                    {
                        if(operation == "add")
                        {
                            var userMoneyParsed = (double)currentUserMoney;
                            if(userMoneyParsed - price > 0)
                            {
                                return await _userRepository.UpdateUserMoney(currentUserEmail, userMoneyParsed - price);
                            }
                            else
                            {
                                return false;
                            }                         
                        }
                        else
                        {
                            var userMoneyParsed = (double)currentUserMoney;
                            if(userMoneyParsed - price > 0)
                            {
                                return await _userRepository.UpdateUserMoney(currentUserEmail, userMoneyParsed + price);
                            }
                            else
                            {
                                return false;
                            }
                        }

                    }
                }
            }
            return false;
        }

        public async Task<SportEvent> GetSportEventById(int id)
        {
            var eventDb = await _sportEventsRepository.GetSportEventById(id);
            if(eventDb != null)
            {
                var objectDd = await _objectRepository.GetObjectById(eventDb.ObjectId);

                var result = SportEventMapper.FromEntityToSportEvent(eventDb);

                if (objectDd != null)
                {
                    result.Price = await CaclulateSportEventPrice(eventDb);
                }
                return result;
            }
            return new SportEvent();
        }

        public async Task<IEnumerable<string>> GetAssignersInSportEvent(int sportEventId)
        {
            var peopleInEvent = await _sportEventsRepository.GetAssignersInEvent(sportEventId);

            if (!string.IsNullOrEmpty(peopleInEvent))
            {
                return JsonSerializer.Deserialize<IEnumerable<string>>(peopleInEvent);
            }
            return Enumerable.Empty<string>();
        }
    }
    public interface ISportEventManager
    {
        Task<IEnumerable<SportEvent>> GetCurrentLoggedUserEventsAssignedTo();
        Task<bool> AssignOrRemoveFromEvent(int sportEventId, string operationType);
        Task<IEnumerable<SportEvent>> GetAllSportEvents();
        Task<bool> CreateSportEvent(CreateSportEventReq sportEvent);
        Task<bool> UpdateSportEvent(CreateSportEventReq sportEvent, int id);
        Task<bool> DeleteSportEvent(int id);
        Task<SportEvent> GetSportEventById(int id);
        Task<IEnumerable<string>> GetAssignersInSportEvent(int sportEventId);
    }
}
