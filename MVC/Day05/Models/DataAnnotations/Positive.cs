using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day05.Models.DataAnnotations
{
    public class Positive : ValidationAttribute
    {
        
        public override bool IsValid(object value)
        {

            if (value!=null)
            {
                decimal val = (decimal)value;
                if (val > 0)
                    return true;
                else
                {
                    ErrorMessage = "Value should be a positive number";
                    return false;
                }

            }
            return false;
        }
    }
}