using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.Entities
{
    public class ObjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get;set; }
        public double PricePerHour { get; set; }
        public Cities City { get;set; }
        public ObjectTypes ObjectType { get;set; }
        public List<SportEventEntity> SportEvents { get; set; } = new List<SportEventEntity>();
        public string CreatedBy { get; set; }
    }
}
