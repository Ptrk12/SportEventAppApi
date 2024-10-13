using ApplicationCore.Models;
using ApplicationCore.Models.req;
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
                EventName = entity.Name,
                CreatedBy = entity.CreatedBy,
                Discipline = entity.Discipline,
                SkillLevel = entity.SkillLevel,
                Price = entity.Price,
                ObjectId = entity.ObjectId,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                ObjectName = entity.Object.Name,
                ObjectCity = entity.Object.City,
                IsMultisportCard = entity.IsMultiSportCard,
                Address = entity.Object.Adress
            };
            return result;
        }

        public static SportEventEntity FromSportEventToEntity(SportEvent entity, ObjectEntity? objectEntity)
        {
            var result = new SportEventEntity()
            {
                Id = entity.Id,
                Name = entity.EventName,
                Discipline = entity.Discipline,
                SkillLevel = entity.SkillLevel,
                Price = entity.Price,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                Object = objectEntity,
                ObjectId = objectEntity.Id,
                IsMultiSportCard = entity.IsMultisportCard
            };
            return result;
        }

        public static SportEventEntity FromSportEventToEntityInsertReq(CreateSportEventReq entity, ObjectEntity? objectEntity)
        {
            var result = new SportEventEntity()
            {
                Name = entity.EventName,
                Discipline = entity.Discipline,
                SkillLevel = entity.SkillLevel,
                Price = entity.Price,
                AmountOfPlayers = entity.AmountOfPlayers,
                Time = entity.Time,
                DateWhen = entity.DateWhen,
                ObjectId = objectEntity.Id,
                IsMultiSportCard = entity.IsMultisportCard
            };
            return result;
        }
    }
}
