
using ApplicationCore.Models;
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
                ObjectType = entity.ObjectType,
            };
        }
    }
}
