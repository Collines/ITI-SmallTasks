using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Branches { get; set; }

        [Required]
        public string Description { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}
