
using ApplicationCore.Models;
using Infrastructure.Entities;
using Infrastructure.Enums;

namespace Infrastructure.Mappers
{
    public class ObjectMapper
    {
        public static ObjectClass FromEntityToObject(ObjectEntity entity)
        {
            Enum.TryParse(entity.City,out Cities city);
            Enum.TryParse(entity.ObjectType,out ObjectTypes objectType);

            return new ObjectClass()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Adress = entity.Adress,
                City = city,
                ObjectType = objectType
            };
        }
    }
}
