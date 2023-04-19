using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal class AnagramComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x == null || y == null || x.Length != y.Length)
                return false;
            var X = x.ToCharArray();
            var Y = y.ToCharArray();
            Array.Sort(X);
            Array.Sort(Y);

            for (int i = 0; i < X.Length; i++)
                if (X[i] != Y[i])
                    return false;
            return true;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            if(obj!=null || obj.Length==0)
                return -1;
            var X = obj.ToCharArray();
            Array.Sort(X);
            var Y = X.ToString();
            return Y.GetHashCode();
        }
    }
}
