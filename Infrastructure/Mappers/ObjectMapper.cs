
using ApplicationCore.Models;
using ApplicationCore.Models.req;
using Infrastructure.Entities;
namespace Infrastructure.Mappers
{
    public class ObjectMapper
    {
        public static ObjectClass FromEntityToObject(ObjectEntity entity)
        {
            return new ObjectClass()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Adress = entity.Adress,
                City = entity.City,
                ObjectType = entity.ObjectType
            };
        }

        public static ObjectEntity FromClassToEntityInsertReq(CreateObjectReq entity, List<SportEventEntity>? sportEvents)
        {
            return new ObjectEntity()
            {
                Name = entity.Name,
                Description = entity.Description,
                Adress = entity.Adress,
                City = entity.City,
                ObjectType = entity.ObjectType,
                SportEvents = sportEvents
            };
        }
    }
}
