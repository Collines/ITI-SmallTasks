using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public enum Gender:byte
    {
        Male, Female
    }

    public enum SecurityLevel : byte
    {
        Guest, Developer, Secretary, DBA
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
            return Day+"/"+Month+"/"+Year;
        }
    }
    public class Employee
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

        public int Id { 
            get 
            {return id;}
            set 
            {
                if(!(value <=0))
                {
                    id = value;
                }
            } 
        }
        public string Name
        {
            get 
            {return name;}
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name= value;
                }
            }
        }
        public SecurityLevel Security
        {
            get { return security;}
            set { security = value;}
        }

        public float Salary
        {
            get { return salary; }
            set { 
                if(!(value <=0))
                    salary= value;
                    }
        }
        public Date HiringDate
        {
            get { return hiringDate; }
            set { 
                if(!(value.GetDay() >31 || value.GetDay() <1 || value.GetMonth() > 12 || value.GetMonth() < 1 || value.GetYear() > 2023 || value.GetYear() < 1990 ))
                    hiringDate= value;
            }
        }
        public Gender Gen
        {
            get { return gen; }
            set { gen = value; }
        }


        // Getters
        #region Old getters/setters
        //public int GetId()
        //{
        //    return Id;
        //}
        //public string GetName()
        //{
        //    return Name;
        //}
        //public SecurityLevel GetSecurityLevel()
        //{
        //    return Security;
        //}
        //public float GetSalary()
        //{
        //    return Salary;
        //}
        //public Date GetHiringDate()
        //{
        //    return HiringDate;
        //}
        //public Gender GetGender()
        //{
        //    return Gen;
        //}

        ////Setters
        //public void SetId(int id)
        //{
        //    Id = id;
        //}
        //public void SetName(string name)
        //{
        //    Name = name;
        //}
        //public void SetSecurity(SecurityLevel security)
        //{
        //    Security = security;
        //}
        //public void SetSalary(float salary)
        //{
        //    Salary = salary;
        //}
        //public void setHiringDate(Date hiringDate)
        //{
        //    HiringDate = hiringDate;
        //}
        //public void SetGender(Gender gender)
        //{
        //    Gen = gender;
        //} 
        #endregion

        public void ShowInfo()
        {
            Console.WriteLine($"{Id} - {Name} - {Security} - {Salary} - {HiringDate.GetDateStr()} - {Gen}");
        }
    }
}
