//Task #1
using Day06;

int x, y, z, a, b, c;
Console.WriteLine("Enter 2 3D Points");
Console.WriteLine($"Enter X for the 1st point: ");
while (!int.TryParse(Console.ReadLine(), out x))
{
    Console.WriteLine("Enter a valid number");
}
Console.WriteLine("Enter Y for the 1st point: ");
while (!int.TryParse(Console.ReadLine(), out y))
{
    Console.WriteLine("Enter a valid number");
}
Console.WriteLine("Enter Z for the 1st point: ");
while (!int.TryParse(Console.ReadLine(), out z))
{
    Console.WriteLine("Enter a valid number");
}
Console.WriteLine($"Enter X for the 2nd point: ");
while (!int.TryParse(Console.ReadLine(), out a))
{
    Console.WriteLine("Enter a valid number");
}
Console.WriteLine("Enter Y for the 2nd point: ");
while (!int.TryParse(Console.ReadLine(), out b))
{
    Console.WriteLine("Enter a valid number");
}
Console.WriteLine("Enter Z for the 2nd point: ");
while (!int.TryParse(Console.ReadLine(), out c))
{
    Console.WriteLine("Enter a valid number");
}

Point3D P1 = new Point3D(x, y, z);
Point3D P2 = new Point3D(a, b, c);
string K, g;
K = (string)P1;
g = (string)P2;
Console.WriteLine($"{K} ---- {g}");
P1.Show();
P2.Show();
if (P1 == P2)
    Console.WriteLine("P1 == P2");
else
    Console.WriteLine("P1 != P2");