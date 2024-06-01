using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class SportEvent
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        [Required]
        [EnumDataType(typeof(Disciplines))]
        public Disciplines Discipline { get; set; }
        [Required]
        public SkillLevel SkillLevel { get; set; }
        [Required]
        public int ObjectId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int AmountOfPlayers { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public DateTime DateWhen { get; set; }
        public string? ObjectName { get; set; }
        public string? ObjectCity { get; set; }
    }
}
