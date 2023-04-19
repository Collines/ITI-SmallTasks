using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff  = new();

        public void AddStaff(Employee? E)
        {
            if(E!=null && !Staff.Contains(E))
            {
                Staff.Add(E);
                ///Try Register for EmployeeLayOff Event Here
                E.EmployeeLayOff += RemoveStaff;
            }
            
        }
        ///CallBackMethod
        public void RemoveStaff(object sender,EmployeeLayOffEventArgs e)
        {
            if(sender is Employee Emp && Emp!=null && Staff.Contains(Emp))
            {
                //if(sender is SalesPerson)
                //{
                //    if(e.Cause == LayOffCause.Retired || e.Cause == LayOffCause.FailedToAchieveTarget)
                //    {
                //        Emp.EmployeeLayOff -= RemoveStaff;
                //        Staff.Remove(Emp);
                //    }
                //} else if(sender is BoardMember)
                //{
                //    if (e.Cause == LayOffCause.Resign)
                //    {
                //        Emp.EmployeeLayOff -= RemoveStaff;
                //        Staff.Remove(Emp);
                //    }
                //} else
                        Emp.EmployeeLayOff -= RemoveStaff;
                        Staff.Remove(Emp);
            }
        }
        public void ListAll()
        {
            foreach (Employee E in Staff)
                Console.WriteLine(E);
        }
    }
}
