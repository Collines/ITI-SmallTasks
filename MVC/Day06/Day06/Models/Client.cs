using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day06.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ClientName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }  
    }
}