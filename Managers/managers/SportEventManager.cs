using ApplicationCore.Models;
using Infrastructure.Mappers;
using Infrastructure.Repositories;

namespace Managers.managers
{
    public class SportEventManager : ISportEventManager
    {
        private readonly ISportEventsRepository _sportEventsRepository;
        private readonly IObjectRepository _objectRepository;

        public SportEventManager(ISportEventsRepository sportEventsRepository, IObjectRepository objectRepository)
        {
            _sportEventsRepository = sportEventsRepository;
            _objectRepository = objectRepository;
        }

        public async Task<bool> CreateSportEvent(SportEvent sportEvent)
        {

            //TODO Z TOKENA WYCIAGAC EMAIL I DOKLEJAC TUTAJ !
            var objectDb = await _objectRepository.GetObjectById(sportEvent.ObjectId);
            var result = false;
            if(objectDb != null)
            {
                var sportEventDb = SportEventMapper.FromSportEventToEntity(sportEvent, objectDb);
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
    }
    public interface ISportEventManager
    {
        Task<IEnumerable<SportEvent>> GetAllSportEvents();
        Task<SportEvent> GetSportEventById(int id);
        Task<bool> CreateSportEvent(SportEvent sportEvent);
    }
}
