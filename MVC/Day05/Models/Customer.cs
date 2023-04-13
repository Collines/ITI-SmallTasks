using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day05.Models
{
    public enum Gender:byte
    {
        Male=1,
        Female
    }
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}