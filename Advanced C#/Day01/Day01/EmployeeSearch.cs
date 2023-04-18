using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    internal class EmployeeSearch
    {
        Employee[] Employees;
        public EmployeeSearch(Employee[] employees)
        {
            Employees= employees;
        }
        public Employee this[int id]
        {
            get
            {
                for (int i = 0; i < Employees.Length; i++)
                {
                    if (Employees[i].Id == id)
                        return Employees[i];
                }
                return null;
            }
        }
        public Employee this[Date HD]
        {
            get
            {
                for (int i = 0; i < Employees.Length; i++)
                {
                    if (Employees[i].HiringDate.GetDateInSec() == HD.GetDateInSec())
                        return Employees[i];
                }
                return null;
            }
        }
        public Employee this[string name]
        {
            get
            {
                for (int i = 0; i < Employees.Length; i++)
                {
                    if (Employees[i].Name == name)
                        return Employees[i];
                }
                return null;
            }
        }

    }
}
