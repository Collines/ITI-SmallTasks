using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public enum Gender : byte
    {
        Male, Female
    }

    [Flags]
    public enum SecurityLevel : byte
    {
        Guest=1, Secretary=2, Developer=4, DBA=8, SecurityOfficer= 1^2^4^8^16
    }

    public class Date
    {
        int Year;
        int Month;
        int Day;
        public Date(int day, int month, int year)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public int GetYear()
        {
            return Year;
        }
        /// <summary>
        /// Convert Date to seconds
        /// </summary>
        /// <returns>Date value in seconds</returns>
        public int GetMonth()
        {
            return Month;
        }
        public int GetDay()
        {
            return Day;
        }
        public string GetDateStr()
        {
            return Day + "/" + Month + "/" + Year;
        }
        public long GetDateInSec()
        {
            return (1970 - Year) * 365 * 24 * 3600 + Month * 30 * 24 * 3600 + Day * 24 * 3600;
        }
    }
    public class Employee:IComparable
    {
        private int id;
        private string name;
        private SecurityLevel security;
        private float salary;
        private Date hiringDate;
        private Gender gen;

        public Employee(int _id, string _name, SecurityLevel _security, float _salary, Date _hiringDate, Gender _gen)
        {
            Id = _id;
            Name = _name;
            Security = _security;
            Salary = _salary;
            HiringDate = _hiringDate;
            Gen = _gen;
        }

        public int Id
        {
            get
            { return id; }
            set
            {
                if (!(value <= 0))
                {
                    id = value;
                }
            }
        }
        public string Name
        {
            get
            { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        public SecurityLevel Security
        {
            get { return security; }
            set { security = value; }
        }

        public float Salary
        {
            get { return salary; }
            set
            {
                if (!(value <= 0))
                    salary = value;
            }
        }
        public Date HiringDate
        {
            get { return hiringDate; }
            set
            {
                if (!(value.GetDay() > 31 || value.GetDay() < 1 || value.GetMonth() > 12 || value.GetMonth() < 1 || value.GetYear() > 2023 || value.GetYear() < 1990))
                    hiringDate = value;
            }
        }
        public Gender Gen
        {
            get { return gen; }
            set { gen = value; }
        }

        public int CompareTo(object? obj)
        {
            Employee? e = obj as Employee;
            string val = $"{this.hiringDate.GetDateInSec() - e?.hiringDate.GetDateInSec()}";
            return int.Parse(val);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Id} - {Name} - {Security} - {Salary} - {HiringDate.GetDateStr()} - {Gen}");
        }

        public override string ToString() {
            return String.Format($"{security} {Name} is taking {salary:C}");
        }
    }
}
