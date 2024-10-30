
using Infrastructure.Enums;
namespace ApplicationCore.Models
{
    public class ObjectClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public Cities City { get; set; }
        public ObjectTypes ObjectType { get; set; }
        public string CreatedBy { get; set; }
        public double PricePerHour { get; set; }
    }
}
