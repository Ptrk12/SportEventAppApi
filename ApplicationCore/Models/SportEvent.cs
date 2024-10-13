using Infrastructure.Enums;

namespace ApplicationCore.Models
{
    public class SportEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string? CreatedBy { get; set; }
        public Disciplines Discipline { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public int ObjectId { get; set; }
        public decimal Price { get; set; }
        public int AmountOfPlayers { get; set; }
        public int Time { get; set; }
        public DateTime DateWhen { get; set; }
        public string? ObjectName { get; set; }
        public Cities? ObjectCity { get; set; }
        public string? Address { get; set; }
        public int PeopleAssigned { get; set; }
        public bool IsMultisportCard { get; set; }
    }
}
