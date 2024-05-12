using ApplicationCore.Models;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using Infrastructure.Repositories;

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

        public async Task<bool> CreateSportEvent(SportEvent sportEvent)
        {
            var createdBy = _userRepository.GetUserEmailFromToken();
            var objectDb = await _objectRepository.GetObjectById(sportEvent.ObjectId);
            var result = false;
            if(objectDb != null)
            {
                var sportEventDb = SportEventMapper.FromSportEventToEntity(sportEvent, objectDb);
                sportEventDb.CreatedBy = createdBy;
                result = await _sportEventsRepository.CreateSportEvent(sportEventDb);
            }
            return result;
        }

        public async Task<IEnumerable<SportEvent>> GetAllSportEvents()
        {
            var dataDb = await _sportEventsRepository.GetAllSportEvents();
            var result = new List<SportEvent>();

            foreach(var item in dataDb)
            {
                var sportEvent = SportEventMapper.FromEntityToSportEvent(item);
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

        public async Task<bool> UpdateSportEvent(SportEvent sportEvent, int id)
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
                        var updatedEntity = SportEventMapper.FromSportEventToEntity(sportEvent, objectDb);
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

            if (!CheckCanModify(sportEventDb))
            {
                return result;
            }

            result = await _sportEventsRepository.DeleteSportEvent(id);
            return result;
        }
    }
    public interface ISportEventManager
    {
        Task<IEnumerable<SportEvent>> GetAllSportEvents();
        Task<SportEvent> GetSportEventById(int id);
        Task<bool> CreateSportEvent(SportEvent sportEvent);
        Task<bool> UpdateSportEvent(SportEvent sportEvent, int id);
        Task<bool> DeleteSportEvent(int id);
    }
}
