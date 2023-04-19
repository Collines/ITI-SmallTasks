using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class SalesPerson:Employee
    {
        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if(e.Cause==LayOffCause.FailedToAchieveTarget || e.Cause==LayOffCause.Retired)
                base.OnEmployeeLayOff(e);
        }
        public int AchievedTarget {
            get;
            set;
        }
        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget < Quota)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.FailedToAchieveTarget });
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"(ID: {EmployeeID} - {BirthDate} - Vacation Stock: {VacationStock} - Target= {AchievedTarget})";
        }
    }
}
