﻿int num = 0, sum = 0, max = 0;
string str;
do
{
    Console.WriteLine("Enter a number");
    num = int.Parse(Console.ReadLine());
    sum += num;
} while (sum <= 100 && num != 0);
//========================
Console.WriteLine("Enter a string");
str = Console.ReadLine();
string[] StrArr = str.Split();
for(int i = StrArr.Length-1; i >=0; i--)
{
    Console.Write(StrArr[i] + " ");
}
Console.WriteLine("\n");
//========================
Console.WriteLine("Enter 3 numbers");
for (int i=1;i<=3;i++)
{
    num = int.Parse(Console.ReadLine());
    if (num > max)
        max = num;
}
Console.WriteLine($"Max number is {max}");
//========================

int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

foreach(int el in intArr)
{
    if(el%2 == 0)
        Console.WriteLine($"{el} is Even");
    else
        Console.WriteLine($"{el} is Odd");
}

//========================

Console.WriteLine("Enter\n1- New\n2- Display\n3- Exit");
num = int.Parse(Console.ReadLine());
switch(num)
{
    case 1:
        Console.WriteLine("New");
        break;
    case 2:
        Console.WriteLine("Display");
        break;
    case 3:
        Console.WriteLine("Exit");
        break;
    default:
        Console.WriteLine("Enter a Valid value");
        break;
}



do
{
    Console.WriteLine("Enter\n1- New\n2- Display\n3- Exit");
    num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 1:
            Console.WriteLine("New");
            break;
        case 2:
            Console.WriteLine("Display");
            break;
        case 3:
            Console.WriteLine("Exit");
            break;
        default:
            Console.WriteLine("Enter a Valid value");
            break;
    }

} while (num != 3);

