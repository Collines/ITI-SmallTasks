using System;
using Day01;
int students, subjs;
Console.WriteLine("Enter Number of Students");
while (!int.TryParse(Console.ReadLine(), out students))
{
    Console.WriteLine("Please Enter a valid number");
}
Console.WriteLine("Enter Number of Subjects");
while (!int.TryParse(Console.ReadLine(), out subjs))
{
    Console.WriteLine("Please Enter a valid number");
}
int[,] Subjects = new int[students + 1, subjs + 1]; // added +1 row for average and +1 column for sum

// filling the array
for (int i = 0; i < Subjects.GetLength(0) - 1; i++)
{

    for (int j = 0; j < Subjects.GetLength(1) - 1; j++)
    {
        int val;
        Console.WriteLine($"Enter Marks for [{i}][{j}]");
        while (!int.TryParse(Console.ReadLine(), out val))
        {
            Console.WriteLine($"Please Enter a number");
        }
        Subjects[i, j] = val;
    }
}
#region Debugging rows<cols
//   0   1   2   3 
///0 10 20  30  40|x
///1 50 60  70  80|x
///2 90 100 110 120|x
/// ----------
///3 x x x x| 
#endregion
#region Debugging rows > cols
//   0    1   2  
///0 10  20  30  |x
///1 40  50  60  |x
///2 70  80  90  |x
///3 100 110 120 |x
/// ------------
///4  x x x x| 
#endregion

//getting sum and avg
int rows = Subjects.GetLength(0), cols = Subjects.GetLength(1);
int comparingPar = rows < cols ? cols - 1 : rows - 1;
for (int i = 0; i < rows; i++)
{
    int sum = 0, avg = 0;
    for (int j = 0; j < comparingPar/*cols - 1*/; j++)
    {
        if (rows < cols)
        {
            if (i + 1 < rows)
                sum += Subjects[i, j];
            if (j + 1 < rows)
                avg += Subjects[j, i];
        }
        else
        {
            if (j < cols - 1)
                sum += Subjects[i, j];
            if (i < cols - 1)
                avg += Subjects[j, i];
        }
    }
    Subjects[i, cols - 1] = sum;
    Subjects[rows - 1, i < cols - 1 ? i : cols - 1] = avg / (rows - 1);

}
for (int i = 0; i < cols - 1; i++)
{
    if (i == 0)
        Console.Write($"                Subj {i + 1}  ");
    else
        Console.Write($"Subj {i + 1}  ");
}
Console.Write($"      Sum");
for (int i = 0; i < rows; i++)
{
    if (i < rows - 1)
        Console.Write($"\nStudent {i + 1} Marks: ");
    else
        Console.Write($"\n        Average: ");
    for (int j = 0; j < cols; j++)
        Console.Write($"{Subjects[i, j]}       ");
}


//Employee[] emps =
//{
//    new Employee(1, "Yasser", SecurityLevel.Guest, 10000, new Date(10, 11, 2010), Gender.Male),
//     new Employee(2, "Ahmed", SecurityLevel.DBA, 8000, new Date(10, 11, 2012), Gender.Male),
//      new Employee(3, "Mohamed Salah", SecurityLevel.SecurityOfficer, 6000, new Date(10, 11, 2015), Gender.Male),
//      //new Employee(4, "Khaled", SecurityLevel.DBA, 3333, new Date(10, 11, 2007), Gender.Male)
//};
//Array.Sort(emps);
//foreach (Employee emp in emps)
//{
//    Console.WriteLine(emp.ToString());
//}
//Console.WriteLine(emps[2].ToString());
//EmployeeSearch ES = new EmployeeSearch(emps);
//Console.WriteLine(ES["mido"]?.ToString());
//Console.WriteLine(ES[new Date(10, 11, 2015)]?.ToString());
//Console.WriteLine(ES[4]?.ToString());