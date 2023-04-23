using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal static class Maths
    {
        public static int Sum(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
        public static int Multiply(int x, int y)
        {
            return x * y;
        }
        public static float divide(int x,int y)
        {
            if(y!=0)
                return (float)x/ (float)y;
            return 0;
        }
    }
}
