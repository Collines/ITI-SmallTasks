using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public enum Gender
    {
        Male, Female
    }

    public enum SecurityLevel : byte
    {
        Guest, Developer, Secretary, DBA
    }

    public struct Date
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
        public int GetMonth()
        {
            return Month;
        }
        public int GetDay()
        {
            return Day;
        }
    }
    struct Employee
    {
        private int Id;
        private string Name;
        private SecurityLevel Security;
        private float Salary;
        private Date HiringDate;
        private Gender Gen;

        public Employee(int id, string name, SecurityLevel security, float salary, Date hiringDate, Gender gen)
        {
            Id = id;
            Name = name;
            Security = security;
            Salary = salary;
            HiringDate = hiringDate;
            Gen = gen;
        }

        // Getters
        public int GetId()
        {
            return Id;
        }
        public string GetName()
        {
            return Name;
        }
        public SecurityLevel GetSecurityLevel()
        {
            return Security;
        }
        public float GetSalary()
        {
            return Salary;
        }
        public Date GetHiringDate()
        {
            return HiringDate;
        }
        public Gender GetGender()
        {
            return Gen;
        }

        //Setters
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetSecurity(SecurityLevel security)
        {
            Security = security;
        }
        public void SetSalary(float salary)
        {
            Salary = salary;
        }
        public void setHiringDate(Date hiringDate)
        {
            HiringDate = hiringDate;
        }
        public void SetGender(Gender gender)
        {
            Gen = gender;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Id} - {Name} - {Security} - {Salary} - {HiringDate.GetDay()}/{HiringDate.GetMonth()}/{HiringDate.GetYear()} - {Gen}");
        }

    }
}
