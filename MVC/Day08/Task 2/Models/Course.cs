using System.ComponentModel.DataAnnotations;

namespace Day08_Task2.Models
{
    public enum Grade
    {
        A,B, C, D, E, F
    }
    public class Course
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Topic { get; set; }

        [Required]
        [EnumDataType(typeof(Grade))]
        public Grade CourseGrade { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
