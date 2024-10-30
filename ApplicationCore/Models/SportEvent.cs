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
        public double Price { get; set; }
        public int AmountOfPlayers { get; set; }
        public int Time { get; set; }
        public DateTime DateWhen { get; set; }
        public string? ObjectName { get; set; }
        public Cities? ObjectCity { get; set; }
        public string? Address { get; set; }
        public int PeopleAssigned { get; set; }
        public bool IsMultisportCard { get; set; }
        public bool CurrentUserAssignedToEvent { get; set; }
        private bool isActive { get; set; }
        public bool IsActive
        {
            get
            {
                if(DateTime.Now >= DateWhen)
                {
                    return false;
                }
                if (DateTime.Now >= DateWhen.AddHours(-2) && DateTime.Now < DateWhen && PeopleAssigned != AmountOfPlayers)
                {
                    return false;
                }
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
    }
}
