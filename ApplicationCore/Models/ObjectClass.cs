
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class ObjectClass
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(250)]
        public string Adress { get; set; }
        [Required]
        public Cities City { get; set; }
        [Required]
        public ObjectTypes ObjectType { get; set; }
    }
}
