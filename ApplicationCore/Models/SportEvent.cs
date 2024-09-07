using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class SportEvent
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Name should have at least one letter length")]
        public string Name { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Description should have at least one letter length")]
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        [Required]
        [EnumDataType(typeof(Disciplines))]
        public Disciplines Discipline { get; set; }
        [Required]
        [EnumDataType(typeof(SkillLevel))]
        public SkillLevel SkillLevel { get; set; }
        public int ObjectId { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Please enter valid price")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Please enter valid amount of players")]
        public int AmountOfPlayers { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Please enter valid event time")]
        public int Time { get; set; }
        [Required]
        public DateTime DateWhen { get; set; }
        public string? ObjectName { get; set; }
        public Cities? ObjectCity { get; set; }
        public int PeopleAssigned { get; set; }
        [Required]
        public bool IsMultisportCard { get; set; }
    }
}
