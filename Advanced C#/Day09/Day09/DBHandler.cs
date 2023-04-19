using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Day09
{
    internal class DBHandler
    {
        public static SqlConnection DBH { get;}
        static DBHandler()
        {
            DBH = new("Server=DESKTOP-VREBPAN\\MSSQLSERVER17;Database=Northwind;Trusted_Connection=True;Encrypt=false;");
        }
    }
}
