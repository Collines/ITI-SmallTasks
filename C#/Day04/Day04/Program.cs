using Day04;

Employee[] Emps= new Employee[1];
Console.WriteLine($"Enter {Emps.Length} Employees data");
for (int i = 0; i < Emps.Length; i++)
{
    Console.WriteLine("Enter Employee's ID");
    int id;
    do
    {
        id = int.Parse(Console.ReadLine());
        if (id <= 0)
            Console.WriteLine("Enter a valid ID");
    }
    while (id <= 0);
    Console.WriteLine("Enter Employee's Name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter Employee's Security Level (Guest-Developer-Secretary-DBA)");
    SecurityLevel security = (SecurityLevel)Enum.Parse(typeof(SecurityLevel), Console.ReadLine());
    Console.WriteLine("Enter Employee's Salary");
    float salary;
    do
    {
        salary = float.Parse(Console.ReadLine());
        if (salary <= 0)
            Console.WriteLine("Enter a valid Salary");
    }
    while (salary <= 0);
    Console.WriteLine("Enter Employee's Hiring Date as dd-mm-yy");
    string[] DateArr;
    do
    {
        DateArr = Console.ReadLine().Split('-');
        if(int.Parse(DateArr[0]) > 31 || int.Parse(DateArr[0]) < 1)
            Console.WriteLine("Enter a valid day (1~31)");
        else if(int.Parse(DateArr[1]) > 12 || int.Parse(DateArr[1]) < 1)
            Console.WriteLine("Enter a valid month (1~12)");
        else if (int.Parse(DateArr[2]) > 2023 || int.Parse(DateArr[2]) < 1900)
            Console.WriteLine("Enter a valid year (1900~2023)");
    } while (int.Parse(DateArr[0]) > 31 || int.Parse(DateArr[0]) < 1 || int.Parse(DateArr[1]) > 12 || int.Parse(DateArr[1]) < 1 || int.Parse(DateArr[2]) > 2023 || int.Parse(DateArr[2]) < 1900);
    Date hiringDate = new Date(int.Parse(DateArr[0]), int.Parse(DateArr[1]), int.Parse(DateArr[2]));
    Console.WriteLine("Enter Employee's Gender (Male or Female)");
    Gender Gen = (Gender) Enum.Parse(typeof(Gender), Console.ReadLine());
    Emps[i] = new Employee(id,name,security,salary,hiringDate,Gen);
}

for (int i = 0; i < Emps.Length; i++)
{
    Emps[i].ShowInfo();
}