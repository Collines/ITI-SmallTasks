using System.ComponentModel.DataAnnotations;

namespace Day01.Models
{
    public class Course
    {
        public int ID { get; set; }
        [MaxLength(50)]
        //[Required]
        public string? Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }

        //[Required]
        public int? Duration { get; set; }
    }
}
