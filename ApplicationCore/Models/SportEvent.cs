
namespace ApplicationCore.Models
{
    public class SportEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string Discipline { get; set; }
        public string SkillLevel { get; set; }
        public int ObjectId { get; set; }
        public decimal Price { get; set; }
        public int AmountOfPlayers { get; set; }
        public int Time { get; set; }
        public DateTime DateWhen { get; set; }
        public string? ObjectName { get; set; }
        public string? ObjectCity { get; set; }
    }
}
