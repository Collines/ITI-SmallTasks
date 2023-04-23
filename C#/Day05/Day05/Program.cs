using Day05;

Employee[] Emps = new Employee[1];
bool IsValidDate(int day, int month, int year)
{
    if (day > 31 || day < 1)
        return false;
    else if (month > 12 || month < 1)
        return false;
    else if (year > 2023 || year < 1900)
        return false;
    return true;
}
Console.WriteLine($"Enter {Emps.Length} Employees data");
for (int i = 0; i < Emps.Length; i++)
{
    Console.WriteLine("Enter Employee's ID");
    int id;
    while (!(int.TryParse(Console.ReadLine(), out id)) || id <= 0)
    {
        Console.WriteLine("Enter a valid number (greater than 0)");

    }
    //do
    //{
    //    id = int.Parse(Console.ReadLine());
    //    if (id <= 0)
    //        Console.WriteLine("Enter a valid ID");
    //}
    //while (id <= 0);
    Console.WriteLine("Enter Employee's Name");
    string name = Console.ReadLine();
    while (string.IsNullOrEmpty(name))
    {
        Console.WriteLine("Enter a valid Employee's Name");
        name = Console.ReadLine();
    }
    Console.WriteLine("Enter Employee's Security Level (Guest-Developer-Secretary-DBA)");
    SecurityLevel security;
    while (!Enum.TryParse<SecurityLevel>(Console.ReadLine(), out security))
    {
        Console.WriteLine("Enter a valid security level");
    }
    Console.WriteLine("Enter Employee's Salary");
    float salary;
    while (!float.TryParse(Console.ReadLine(), out salary) || salary <= 0) {
        Console.WriteLine("Enter a valid Salary (number greater than 0)");
    }
    //do
    //{
    //    salary = float.Parse(Console.ReadLine());
    //    if (salary <= 0)
    //        Console.WriteLine("Enter a valid Salary");
    //}
    //while (salary <= 0);


    string[] DateArr;
    Console.WriteLine("Enter Employee's Hiring Date as dd-mm-yyyy");
    do
    {
        DateArr = Console.ReadLine().Split('-', '/');
        if (DateArr.Length != 3)
            Console.WriteLine("Enter a valid date dd-mm-yyyy");
    }
    while (DateArr.Length != 3);

    int day, month, year;

    while (DateArr.Length != 3 ||
        !int.TryParse(DateArr[0], out day) ||
        !int.TryParse(DateArr[1], out month) ||
        !int.TryParse(DateArr[2], out year) ||
        !IsValidDate(day, month, year) ||
        (day > 31 || day < 1) ||
        (month > 12 || month < 1) ||
        (year > 2023 || year < 1990))
    {
        Console.WriteLine("Enter a valid date dd-mm-yyyy");
        DateArr = Console.ReadLine().Split('-', '/');
    }
    //do
    //{
    //    DateArr = Console.ReadLine().Split('-');
    //    //if (int.Parse(DateArr[0]) > 31 || int.Parse(DateArr[0]) < 1)
    //    //    Console.WriteLine("Enter a valid day (1~31)");
    //    //else if (int.Parse(DateArr[1]) > 12 || int.Parse(DateArr[1]) < 1)
    //    //    Console.WriteLine("Enter a valid month (1~12)");
    //    //else if (int.Parse(DateArr[2]) > 2023 || int.Parse(DateArr[2]) < 1900)
    //    //    Console.WriteLine("Enter a valid year (1900~2023)");
    //} while (int.Parse(DateArr[0]) > 31 || int.Parse(DateArr[0]) < 1 || int.Parse(DateArr[1]) > 12 || int.Parse(DateArr[1]) < 1 || int.Parse(DateArr[2]) > 2023 || int.Parse(DateArr[2]) < 1900 || DateArr.Length != 3);

    // Constructing new date
    // Date hiringDate = new Date(int.Parse(DateArr[0]), int.Parse(DateArr[1]), int.Parse(DateArr[2]));
    Date hiringDate = new Date(day, month,year);


    Console.WriteLine("Enter Employee's Gender (Male or Female)");
    Gender Gen;
    while(!Enum.TryParse<Gender>(Console.ReadLine(), out Gen))
    {
        Console.WriteLine("Enter a valid Gender (Male - Female)");
    }
    Emps[i] = new Employee(id, name, security, salary, hiringDate, Gen);
}

for (int i = 0; i < Emps.Length; i++)
{
    Emps[i].ShowInfo();
}