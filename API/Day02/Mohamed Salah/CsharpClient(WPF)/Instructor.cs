using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CsharpClient_WPF_
{
    public class Instructor
    {
        public int Id { get; set; }

        public string SSN { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int? Age { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal? Salary { get; set; }

        public DateTime? DOB { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}