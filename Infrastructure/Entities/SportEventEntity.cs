using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class SportEventEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual UserEntity? User { get; set; }
        public string? CreatedBy { get; set; }
        public Disciplines Discipline { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public int ObjectId { get; set; }   
        public int AmountOfPlayers { get; set; }
        public int Time { get; set; }
        public DateTime DateWhen { get; set; }
        public ObjectEntity Object { get; set; }
        public bool IsMultiSportCard { get; set; }
    }
}
