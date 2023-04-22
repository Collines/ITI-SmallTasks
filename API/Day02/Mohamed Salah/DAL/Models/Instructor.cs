using DAL.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Length should between {1} and {2}")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(22,60)]
        public int? Age { get; set; }


        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        [PastDate(ErrorMessage ="Date should be in the past")]

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
