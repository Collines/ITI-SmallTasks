using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Validators
{
    internal class PastDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value) => value is DateTime date && date.Year < DateTime.Now.Year;
    }
}
