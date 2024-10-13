using Infrastructure.Enums;

namespace Infrastructure.Entities
{
    public class SportEventEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public Disciplines Discipline { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public int ObjectId { get; set; }   
        public decimal Price { get;set; }
        public int AmountOfPlayers { get; set; }
        public int Time { get; set; }
        public DateTime DateWhen { get; set; }
        public ObjectEntity Object { get; set; }
        public bool IsMultiSportCard { get; set; }
    }
}
