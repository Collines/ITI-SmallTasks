using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal class Duration
    {
        int Hours;
        int Minutes;
        int Seconds;
        private int Secs { get {
                return Hours * 3600 + Minutes * 60 + Seconds;
        }}

        public Duration(int hours, int minutes, int seconds)
        {
            int SEC = hours * 3600 + minutes* 60 + seconds;
            if (SEC >= 0)
            {
                FillData(SEC);  
            } else
            {
                Hours = 0;
                Minutes = 0;
                Seconds = 0;
            }
            #region Deprecated code
            //if (hours >= 0) // hours must not be negative
            //{
            //    if(minutes <0) // if minutes are negative take from hours
            //    {
            //        if (hours >= 1) // hours must be greater than 0 to take from them
            //        { 
            //            hours--;
            //            minutes += 60;
            //        }
            //        else minutes = 0;
            //    }
            //    if (seconds < 0)  // if seconds are negative take from hours
            //    {
            //        if (minutes >= 1) // minutes must be greater than 0 to take from them
            //        {
            //            minutes--;
            //            seconds += 60;
            //        } else
            //            seconds = 0;
            //    }
            //    // 2 140 150 => 4 22 30 
            //    Hours = hours + (minutes / 60);
            //    minutes = minutes % 60;
            //    Minutes = minutes + (seconds / 60);
            //    Seconds = seconds % 60;
            //} else
            //{
            //    Hours = 0;
            //    Minutes= 0;
            //    Seconds = 0;    
            //} 
            #endregion
        }
        public Duration(int seconds)//5450
        {
            if(seconds >= 0)
            {
                FillData(seconds);
            }
            else
            {
                Hours = 0;
                Minutes = 0;
                Seconds = 0;
            }
        }

        private void FillData(int seconds)
        {
            Hours = seconds / 3600; // 5450/3600 = 1.51388888
            Minutes = (seconds % 3600) / 60; // (5450%3600)/60 = 1850/60 = 30.xx
            Seconds = seconds % 60;
        }

        private static void FillData(int seconds,out int H,out int M, out int S)
        {
            H = seconds / 3600; // 5450/3600 = 1.51388888
            M = (seconds % 3600) / 60; // (5450%3600)/60 = 1850/60 = 30.xx
            S = seconds % 60;
        }

        private int ToSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }
        public override string ToString()
        {
            string time = "";
            if (Hours > 0)
                time += $"Hours: {Hours}, ";
            return time += $"Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public void Show()
        {
            Console.WriteLine(ToString());
        }

        public static explicit operator string(Duration D)
        {
            return D.ToString();
        }

        public static implicit operator bool(Duration D)
        {
            return (D.Seconds != 0 || D.Minutes != 0 || D.Hours != 0);
        }

        public static Duration operator +(Duration D1, Duration D2)
        {
            return new Duration(D1.Hours + D2.Hours, D1.Minutes + D2.Minutes, D1.Seconds + D2.Seconds);
        }

       
        public static Duration operator +(Duration D1,int seconds)
        {
            FillData(seconds, out int H, out int M, out int S);
            return new Duration(D1.Hours + H, D1.Minutes + M, D1.Seconds + S);
        }
        public static Duration operator +(int seconds, Duration D1)
        {
            FillData(seconds, out int H, out int M, out int S);
            return new Duration(D1.Hours + H, D1.Minutes + M, D1.Seconds + S);
        }
        public static Duration operator -(Duration D1, Duration D2)
        {
            return new Duration(D1.Hours - D2.Hours, D1.Minutes - D2.Minutes, D1.Seconds - D2.Seconds);
        }
        public static Duration operator -(Duration D1, int seconds)
        {
            int SEC = D1.Secs;
            int diff = SEC - seconds;
            if (diff >= 0)
            {
                FillData(diff, out int H, out int M, out int S);
                return new Duration(H, M, S);
            }
            else
                return new Duration(0);
            #region Deprecated Code 2
            //if (D1.Hours - H >= 0)
            //{
            //    if (D1.Minutes - M < 0)
            //    {
            //        if (D1.Hours - H >= 1)
            //        {
            //            D1.Hours -= 1;
            //            D1.Minutes += 60;
            //        }
            //    }
            //    if (D1.Seconds - S < 0)
            //    {
            //        D1.Minutes -= 1;
            //        D1.Minutes += 60;
            //    }
            //    return new Duration(D1.Hours - H, D1.Minutes - M, D1.Seconds - S);
            //}
            //else return new Duration(0); 
            #endregion
        }
        public static Duration operator -(int seconds, Duration D1)
        {
            int SEC = D1.Secs;

            int diff = seconds-SEC;
            if (diff >= 0)
            {
                FillData(diff, out int H, out int M, out int S);
                return new Duration(H, M, S);
            }
            else
                return new Duration(0);
        }

        public static Duration operator++(Duration d)
        {
            return new Duration(d.Hours,d.Minutes+1,d.Seconds);
        }
        public static Duration operator --(Duration d)
        {
            return new Duration(d.Hours, d.Minutes - 1, d.Seconds);
        }
        public static bool operator==(Duration d1, Duration d2)
        {
            return (d1.Hours==d2.Hours && d1.Minutes==d2.Minutes && d1.Seconds==d2.Seconds);
        }
        public static bool operator !=(Duration d1, Duration d2)
        {
            if (d1 == d2)
                return false;
            else return true;
        }
        public static bool operator >(Duration d1, Duration d2)
        {
            int D1 = d1.Secs;
            int D2 = d2.Secs;
            return (D1 > D2);
        }
        public static bool operator >=(Duration d1, Duration d2)
        {
            int D1 = d1.Secs;
            int D2 = d2.Secs;
            return (D1 >= D2);
        }
        public static bool operator <(Duration d1, Duration d2)
        {
            if (!(d1 >= d2))
                return true;
            return false;
        }
        public static bool operator <=(Duration d1, Duration d2)
        {
            int D1 = d1.Secs;
            int D2 = d2.Secs;
            return (D1 <= D2);
            #region OldVer
            //if (!(d1 > d2))
            //    return true;
            //return false; 
            #endregion
        }
    }
}
