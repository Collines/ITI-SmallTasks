using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day04.Areas.HR.Data
{
    public enum Gender:byte
    {
        Male,
        Female
    }
    public class Employee
    {
        [ReadOnly(true)]
        [HiddenInput()]
        [Key]
        public int EmployeeID { get; set; }
        [Display(Name = "Employee Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Username is too long")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Range(3000,100_000,ErrorMessage ="Enter values between 3000 and 100,000")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime JoinDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}