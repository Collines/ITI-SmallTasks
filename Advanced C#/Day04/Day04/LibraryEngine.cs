using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public delegate string bookFunctionsDelDT(Book b); // User defined delegate
    internal static class LibraryEngine
    {
        //public static void ProcessBooks(List<Book> bList, bookFunctionsDelDT fPtr)
        //{
        //    foreach (Book B in bList)
        //    {
        //        Console.WriteLine(fPtr(B));
        //    }
        //}

        public static void ProcessBooks(List<Book> bList, Func<Book,string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

    }
}
