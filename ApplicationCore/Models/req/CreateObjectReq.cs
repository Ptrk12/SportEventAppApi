using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.req
{
    public class CreateObjectReq
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name should have at least one letter length")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Address should have at least three letter length")]
        public string Adress { get; set; }
        [Required]
        [EnumDataType(typeof(Cities))]
        public Cities City { get; set; }
        [Required]
        [EnumDataType(typeof(ObjectTypes))]
        public ObjectTypes ObjectType { get; set; }
        [Required]
        public double PricePerHour { get; set; }
    }
}
