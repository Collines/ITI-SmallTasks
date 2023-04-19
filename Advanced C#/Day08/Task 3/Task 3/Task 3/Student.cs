using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Grade { get; set; }
        public string Image { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
