using Day09_remake.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day09.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Course
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage ="Topic Length can't exceed 40 characters")]
        public string Topic { get; set; }

        //[Required]
        //[EnumDataType(typeof(Grade))]
        //public Grade Grade { get; set; }

        public /*virtual*/ ICollection<TraineeCourse> TraineeCourses { get; set; }
        //public virtual Track Track { get; set; }
    }
}
