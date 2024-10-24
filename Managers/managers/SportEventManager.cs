﻿using ApplicationCore.Models;
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

        public async Task<IEnumerable<SportEvent>> GetAllSportEvents()
        {
            var dataDb = await _sportEventsRepository.GetAllSportEvents();
            var currentUserEmail = _userRepository.GetUserEmailFromToken();

            var result = new List<SportEvent>();

            foreach(var item in dataDb)
            {
                var sportEvent = SportEventMapper.FromEntityToSportEvent(item);
                var assignersInTheEventString = await _sportEventsRepository.GetAssignersInEvent(item.Id);
                if (!string.IsNullOrEmpty(assignersInTheEventString))
                {
                    var assignersInTheEvent = JsonSerializer.Deserialize<List<string>>(assignersInTheEventString);
                    sportEvent.PeopleAssigned = assignersInTheEvent.Count;

                    if (assignersInTheEvent != null && assignersInTheEvent.Contains(currentUserEmail))
                    {
                        sportEvent.CurrentUserAssignedToEvent = true;
                    }
                }            
                result.Add(sportEvent);
            }
            return result;
        }

        public Task<SportEvent> GetSportEventById(int id)
        {
            throw new NotImplementedException();
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
            //DODAC SPRAWDZANIE CZY DO EVENTU PRZYPISANI SA LUDZIE JESLI TAK TO NIE MOZNA USUWAC !
            var result = false;
            var sportEventDb = await _sportEventsRepository.GetSportEventById(id);

            if (!CheckCanModify(sportEventDb))
            {
                return result;
            }

            result = await _sportEventsRepository.DeleteSportEvent(id);
            return result;
        }

        public async Task<bool> AssignOrRemoveFromEvent(int sportEventId, string operationType)
        {
            var result = false;
            var currentAssigners = await _sportEventsRepository.GetAssignersInEvent(sportEventId);

            if (!string.IsNullOrEmpty(currentAssigners))
            {
                var currentAssignersArrayDb = JsonSerializer.Deserialize<List<string>>(currentAssigners);
                var currentAssignersArray = JsonSerializer.Deserialize<List<string>>(currentAssigners);

                var currentUserEmail = _userRepository.GetUserEmailFromToken();

                if (!string.IsNullOrEmpty(currentUserEmail))
                {
                    if (!currentAssignersArray.Contains(currentUserEmail) && operationType == "add")
                    {
                        currentAssignersArray.Add(currentUserEmail);
                    }
                    else if (currentAssignersArray.Contains(currentUserEmail) && operationType == "remove")
                    {
                        currentAssignersArray.Remove(currentUserEmail);
                    }
                    if(currentAssignersArray.Count != currentAssignersArrayDb.Count)
                    {
                        var currentAssignersJsonArray = JsonSerializer.Serialize(currentAssignersArray);
                        result = await _sportEventsRepository.AssignOrRemoveFromEvent(sportEventId, currentAssignersJsonArray);
                    }
                }
            }

            return result;
        }
    }
    public interface ISportEventManager
    {
        Task<bool> AssignOrRemoveFromEvent(int sportEventId, string operationType);
        Task<IEnumerable<SportEvent>> GetAllSportEvents();
        Task<SportEvent> GetSportEventById(int id);
        Task<bool> CreateSportEvent(CreateSportEventReq sportEvent);
        Task<bool> UpdateSportEvent(CreateSportEventReq sportEvent, int id);
        Task<bool> DeleteSportEvent(int id);
    }
}
