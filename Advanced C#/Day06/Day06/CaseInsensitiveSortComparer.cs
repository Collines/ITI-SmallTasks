using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal class CaseInsensitiveSortComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if(x!=null && y!=null)
            {
                //return x.ToLower().CompareTo(y.ToLower());
                return string.Compare(x,y,StringComparison.OrdinalIgnoreCase);
            }
            return -1;
        }
    }
}
