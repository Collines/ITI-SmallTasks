using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class Club
    {
        public string ClubName { get; set; }
        List<Employee> Members = new();
        public void AddMember(Employee E)
        {
            Members.Add(E);
            ///Try Register for EmployeeLayOff Event Here
            E.EmployeeLayOff += RemoveMember;
        }
        ///CallBackMethod
        public void RemoveMember (object sender, EmployeeLayOffEventArgs e)
        {
            if(sender is Employee Emp && Emp!=null)
            {
                if(e.Cause == LayOffCause.StockOutVacation || e.Cause==LayOffCause.FailedToAchieveTarget)
                {
                    Emp.EmployeeLayOff-= RemoveMember;
                    Members.Remove(Emp);
                }
            }
                
            ///Employee Will not be removed from the Club if Age>60
            ///Employee will be removed from Club if Vacation Stock < 0

        }
        public void ListAll()
        {
            foreach (Employee E in Members)
                Console.WriteLine(E);
        }
    }
}
