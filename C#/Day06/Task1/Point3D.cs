using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal class Point3D
    {   // x,y,x ()
        int X, Y, Z;
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Point3D() : this(0, 0, 0)
        {

        }
        public void Show()
        {
            Console.WriteLine($"Point Coordinates: ({X},{Y},{Z})");
        }
        public static explicit operator string( Point3D p )
        {
            return $"({p.X},{p.Y},{p.Z})";
        }
        public static bool operator ==(Point3D P1, Point3D P2)
        {
            return (P1.X == P2.X && P1.Y == P2.Y && P1.Z == P2.Z);
        }
        public static bool operator !=(Point3D P1, Point3D P2)
        {
            return (P1.X != P2.X || P1.Y != P2.Y || P1.Z != P2.Z);
        }
    }
}
