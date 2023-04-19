using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public enum LayOffCause
    { 
        Retired,
        StockOutVacation,
        FailedToAchieveTarget,
        Resign
    }
    public class EmployeeLayOffEventArgs:EventArgs
    {
        public LayOffCause Cause { get; set; }
    }
    internal class Employee // publisher
    {
        public int EmployeeID { get; init; }
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e) => EmployeeLayOff?.Invoke(this, e);
        public DateTime BirthDate {get;init;}
        public int VacationStock { get; set; } = 0;
        public bool RequestVacation(DateTime From, DateTime To)
        {
            if(From==To || From > To)
                return false;
             else
            {
                TimeSpan diff = To - From;
                if (diff.Days > VacationStock)
                {
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.StockOutVacation });
                    return false;
                }
                VacationStock -= diff.Days;
                return true;
            }
            
        }
        public void EndOfYearOperation()
        {
            var diff = DateTime.Now.Year - BirthDate.Year;
            //DateTime zero = new DateTime(0, 0, 0);
            //TimeSpan diff = DateTime.Now - BirthDate;
            if (diff > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Retired });
            }
        }
        public override string ToString()
        {
            return $"(ID: {EmployeeID} - {BirthDate} - Vacation Stock: {VacationStock})";
        }
    }
}
