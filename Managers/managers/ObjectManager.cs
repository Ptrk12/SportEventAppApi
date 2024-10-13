using ApplicationCore.Models;
using ApplicationCore.Models.req;
using Infrastructure.Mappers;
using Infrastructure.Repositories;

namespace Managers.managers
{
    public class ObjectManager : IObjectManager
    {
        private readonly IObjectRepository _objectRepository;
        private readonly ISportEventsRepository _sportEventsRepository;

        public ObjectManager(
            IObjectRepository objectRepository, 
            ISportEventsRepository sportEventsRepository)
        {
            _objectRepository = objectRepository;
            _sportEventsRepository = sportEventsRepository;
        }

        public async Task<bool> CreateObject(CreateObjectReq req)
        {
            var entity = ObjectMapper.FromClassToEntityInsertReq(req, null);
            var result = await _objectRepository.CreateObject(entity);
            return result;
        }

        public async Task<bool> DeleteObject(int id)
        {
            var result = false;
            var sportEvents = await _sportEventsRepository.GetAllSportEventsInObject(id);
            if(sportEvents.Count() > 0)
            {
                return result;
            }
            result = await _objectRepository.DeleteObject(id);
            return result;
        }

        public async Task<IEnumerable<ObjectClass>> GetAllObjects()
        {
            var entityDb = await _objectRepository.GetAllObjects();
            var result = new List<ObjectClass>();
            foreach (var item in entityDb)
            {
                var objectClass = ObjectMapper.FromEntityToObject(item);
                result.Add(objectClass);
            }
            return result;
        }

        public async Task<IEnumerable<ObjectBaseInfo>> GetObjectsBaseInfo()
        {
            var entityDb = await _objectRepository.GetAllObjects();
            var result = new List<ObjectBaseInfo>();
            foreach (var item in entityDb)
            {
                ObjectBaseInfo objBaseInfo = new ObjectBaseInfo()
                {
                    Id = item.Id,
                    Name = item.Name
                };

                result.Add(objBaseInfo);
            }
            return result;
        }

        public async Task<ObjectClass> GetObjectById(int id)
        {
            var entityDb = await _objectRepository.GetObjectById(id);
            var result = ObjectMapper.FromEntityToObject(entityDb);
            return result;
        }

        public async Task<bool> UpdateObject(CreateObjectReq objectEntity, int id)
        {
            var result = false;
            var objectDb = await _objectRepository.GetObjectById(id);
            var sportEvents = await _sportEventsRepository.GetAllSportEventsInObject(id);

            if (objectDb != null)
            {
                var req = ObjectMapper.FromClassToEntityInsertReq(objectEntity, sportEvents.ToList());
                req.Id = objectDb.Id;
                result = await _objectRepository.Updateobject(id, req);
            }
            return result;
        }
    }
    public interface IObjectManager
    {
        Task<ObjectClass> GetObjectById(int id);
        Task<IEnumerable<ObjectClass>> GetAllObjects();
        Task<bool> CreateObject(CreateObjectReq req);
        Task<bool> DeleteObject(int id);
        Task<bool> UpdateObject(CreateObjectReq objectEntity, int id);
        Task<IEnumerable<ObjectBaseInfo>> GetObjectsBaseInfo();
    }
}
