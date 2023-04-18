using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal static class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B?.Title??"";
        }
        public static string GetAuthors(Book B)
        {
            string authors = "[ ";
            foreach (string author in B.Authors)
                authors += $"{author} - ";
            authors += " ]";
            return authors;
        }
        public static string GetPrice(Book B)
        {
            return $"{B.Price}";
        }
    }
}
