internal struct Employee
{
    public string Name;
    public string Address;
    public int Age;
    public int Salary;
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name} - Age: {Age} - Address: {Address} - Salary: {Salary:c}");
    }
}
