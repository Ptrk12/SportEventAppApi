using Infrastructure.Enums;

namespace Infrastructure.Entities
{
    public class ObjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get;set; }
        public string City { get;set; }
        public string ObjectType { get;set; }
        public List<SportEventEntity> SportEvents { get; set; } = new List<SportEventEntity>();
    }
}
