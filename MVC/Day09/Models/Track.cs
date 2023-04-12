using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day09.Models
{
    public class Track
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(40,ErrorMessage ="Track name can't exceed 40 characters")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //public virtual ICollection<Course> Courses { get; set; }
        public /*virtual*/ ICollection<Trainee> Trainees { get; set; }
    }
}
