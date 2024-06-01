using ApplicationCore.Models;
using Infrastructure.Entities;
using Infrastructure.Enums;

namespace Infrastructure.Mappers
{
    public class SportEventMapper
    {
        public static SportEvent FromEntityToSportEvent(SportEventEntity entity)
        {
            Enum.TryParse(entity.Discipline, out Disciplines discipline);
            Enum.TryParse(entity.SkillLevel, out SkillLevel skillLevel);

            var result = new SportEvent()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedBy = entity.CreatedBy,
                Discipline = discipline,
                SkillLevel = skillLevel,
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
                Discipline = entity.Discipline.ToString(),
                SkillLevel = entity.SkillLevel.ToString(),
                Price = entity.Price,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                Object = objectEntity,
                ObjectId = objectEntity.Id              
            };
            return result;
        }

        public static SportEventEntity FromSportEventToEntityInsertReq(SportEvent entity, ObjectEntity? objectEntity)
        {
            var result = new SportEventEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Discipline = entity.Discipline.ToString(),
                SkillLevel = entity.SkillLevel.ToString(),
                Price = entity.Price,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                ObjectId = objectEntity.Id
            };
            return result;
        }
    }
}
