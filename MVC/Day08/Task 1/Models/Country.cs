﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day08.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public int countryID { get; set; }
        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        [InverseProperty(nameof(City.cNavigation))]
        public virtual ICollection<City> Cities { get; set; }
    }
}