using ApplicationCore.Models;
using Infrastructure.Entities;

namespace Infrastructure.Mappers
{
    public class SportEventMapper
    {
        public static SportEvent FromEntityToSportEvent(SportEventEntity entity)
        {
            var result = new SportEvent()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedBy = entity.CreatedBy,
                Discipline = entity.Discipline,
                SkillLevel = entity.SkillLevel,
                Price = entity.Price,
                ObjectId = entity.ObjectId,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                ObjectName = entity.Object.Name,
                ObjectCity = entity.Object.City
            };
            return result;
        }

        public static SportEventEntity FromSportEventToEntity(SportEvent entity, ObjectEntity? objectEntity)
        {
            var result = new SportEventEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedBy = entity.CreatedBy,
                Discipline = entity.Discipline,
                SkillLevel = entity.SkillLevel,
                Price = entity.Price,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                Object = objectEntity,
                ObjectId = objectEntity.Id              
            };
            return result;
        }
    }
}
