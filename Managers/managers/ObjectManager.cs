using ApplicationCore.Models;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using System.Linq.Expressions;

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

        public async Task<bool> CreateObject(ObjectEntity objectEntity)
        {
            var result = await _objectRepository.CreateObject(objectEntity);
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

        public async Task<ObjectClass> GetObjectById(int id)
        {
            var entityDb = await _objectRepository.GetObjectById(id);
            var result = ObjectMapper.FromEntityToObject(entityDb);
            return result;
        }

        public async Task<bool> UpdateObject(ObjectEntity objectEntity, int id)
        {
            var result = false;
            var objectDb = await _objectRepository.GetObjectById(id);
            var sportEvents = await _sportEventsRepository.GetAllSportEventsInObject(id);

            if (objectDb != null)
            {
                objectEntity.Id = objectDb.Id;
                objectEntity.SportEvents = sportEvents.ToList();
                result = await _objectRepository.Updateobject(id, objectEntity);
            }
            return result;
        }
    }
    public interface IObjectManager
    {
        Task<ObjectClass> GetObjectById(int id);
        Task<IEnumerable<ObjectClass>> GetAllObjects();
        Task<bool> CreateObject(ObjectEntity objectEntity);
        Task<bool> DeleteObject(int id);
        Task<bool> UpdateObject(ObjectEntity objectClass ,int id);
    }
}
