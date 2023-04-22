
#region firstTask
/*Employee[] Employees = new Employee[2];

Console.WriteLine($"Enter {Employees.Length} Employees data");

for (int i = 0; i < Employees.Length; i++)
{
    Console.WriteLine("Enter Employee's name");
    Employees[i].Name = Console.ReadLine();
    Console.WriteLine("Enter Employee's Addres");
    Employees[i].Address = Console.ReadLine();
    Console.WriteLine("Enter Employee's Age");
    Employees[i].Age = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter Employee's Salary");
    Employees[i].Salary = int.Parse(Console.ReadLine());
}

for (int i = 0; i < Employees.Length; i++)
    Employees[i].PrintInfo();*/

#endregion

#region Swap

static void Swap(int x, int y)
{
    int temp = x;
    x = y;
    y = temp;
}

static void RefSwap(ref int x,ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}

int a = 5, b = 10;
Console.WriteLine($"a: {a} - b: {b} -- before value swapping");
Swap(a, b);
Console.WriteLine($"a: {a} - b: {b} -- after value swapping");
Console.WriteLine();
Console.WriteLine($"a: {a} - b: {b} -- before ref swapping");
RefSwap(ref a, ref b);
Console.WriteLine($"a: {a} - b: {b} -- after ref swapping");

#endregion

#region Menu

static int Sum(int a, int b)
{
    return a + b;
}
static int Subtract(int a, int b)
{
    return a - b;
}
static int Multiply(int a, int b)
{
    return a * b;
}
static int Divide(int a, int b)
{
    return a/b;
}
Console.WriteLine("Enter 2 numbers");
int num1, num2, choice;
Console.Write($"Enter first number: ");
num1 = int.Parse(Console.ReadLine());
Console.Write($"Enter second number: ");
num2 = int.Parse(Console.ReadLine());

do 
{
    Console.WriteLine("1- Sum\n2-Substract\n3-Multiply\n4-Divide");
    choice = int.Parse(Console.ReadLine());
    switch(choice)
    {
        case 1:
            Console.WriteLine($"{num1}+{num2} = {Sum(num1,num2)}");
            break;
        case 2:
            Console.WriteLine($"{num1}-{num2} = {Subtract(num1, num2)}");
            break;
        case 3:
            Console.WriteLine($"{num1}*{num2} = {Multiply(num1, num2)}");
            break;
        case 4:
            if(num2==0)
                Console.WriteLine("Can't divide by 0");
            else
                Console.WriteLine($"{num1}/{num2} = {Divide(num1, num2)}");
            break;
        case 0:
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Enter a valid choice");
            break;

    }
} while (choice !=0);

#endregion