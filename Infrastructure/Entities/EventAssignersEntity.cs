namespace Infrastructure.Entities
{
    public class EventAssignersEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public SportEventEntity SportEvent { get; set; }
        public string AssignedPeople { get; set; }
    }
}
