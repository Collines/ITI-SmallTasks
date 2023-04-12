using Day09_remake.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day09.Models
{
    public enum Gender
    {
        Male,
       Female,
    }
    public class Trainee
    {
        public int ID { get; set; }

        [MaxLength(40, ErrorMessage = "Name Length can't exceed 40 characters")]
        [Required]
        public string Name { get; set; }

        [EnumDataType(typeof(Gender))]
        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthdate { get; set; }

        public virtual ICollection<TraineeCourse> TraineeCourses { get; set; }
        public /*virtual*/ Track Track { get; set; }
    }
}
