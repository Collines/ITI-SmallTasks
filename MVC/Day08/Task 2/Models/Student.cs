using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day08_Task2.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [EnumDataType(typeof(Gender))]
        [Required]

        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
