using Day05;
//List<Employee> Employees = new List<Employee>() 
//    {
//    // Sales Person testing
//    new SalesPerson() { EmployeeID=1, BirthDate=new(1997,6,3),AchievedTarget=2000,VacationStock=5 },
//    new SalesPerson() { EmployeeID = 2, BirthDate = new(1000, 6, 3), AchievedTarget = 3000 },
//    new SalesPerson() { EmployeeID = 3, BirthDate = new(1990, 6, 3), AchievedTarget = 3000 },
//    // Board Member testing
//    new BoardMember() { EmployeeID = 4, BirthDate = new(1000, 6, 3)},
//    new BoardMember() { EmployeeID = 5, BirthDate = new(1990, 6, 3) },
//    new BoardMember() { EmployeeID = 6, BirthDate = new(1997, 6, 3), VacationStock = 5 },
//    // Employee testing
//    new Employee() { EmployeeID = 7, BirthDate = new(1000, 6, 3), VacationStock = 16 },
//    new Employee() { EmployeeID = 8, BirthDate = new(1990, 6, 3), VacationStock = 10 },
//    new Employee() { EmployeeID = 9, BirthDate = new(1997, 6, 3), VacationStock = 5 },
//    };
//foreach (var e in Employees) {
//    SD.AddStaff(e);
//    AhliClub.AddMember(e);
//}


Department SD = new() { DeptID = 1, DeptName = "System Development" };
Club AhliClub = new() { ClubName = "El Ahly" };

// Sales Person testing
SalesPerson Person1 = new SalesPerson() { EmployeeID = 1, BirthDate = new(1997, 6, 3), AchievedTarget = 2000, VacationStock = 5 };
SalesPerson Person2 = new SalesPerson() { EmployeeID = 2, BirthDate = new(1000, 6, 3), AchievedTarget = 3000 };
SalesPerson Person3 = new SalesPerson() { EmployeeID = 3, BirthDate = new(1990, 6, 3), AchievedTarget = 3000 };
// Board Member testing
BoardMember Person4 = new BoardMember() { EmployeeID = 4, BirthDate = new(1000, 6, 3) };
BoardMember Person5 = new BoardMember() { EmployeeID = 5, BirthDate = new(1990, 6, 3) };
BoardMember Person6 = new BoardMember() { EmployeeID = 6, BirthDate = new(1997, 6, 3), VacationStock = 5 };
// Board Member testing
Employee Person7 = new Employee() { EmployeeID = 7, BirthDate = new(1000, 6, 3), VacationStock = 16 };
Employee Person8 = new Employee() { EmployeeID = 8, BirthDate = new(1990, 6, 3), VacationStock = 10 };
Employee Person9 = new Employee() { EmployeeID = 9, BirthDate = new(1997, 6, 3), VacationStock = 5 };

////adding Sales Person to department
//SD.AddStaff(Person1);
//SD.AddStaff(Person2);
//SD.AddStaff(Person3);
//SD.ListAll();
//Console.WriteLine("-----------------");
//Person1.RequestVacation(DateTime.Now, DateTime.Now.AddDays(6));
//Person2.CheckTarget(1000);
//Person3.CheckTarget(2500);
//Person2.EndOfYearOperation();
//SD.ListAll();
//Console.WriteLine("-----------------");


////// adding Sales Person to Club
//Console.WriteLine("Ahly Club members");
///
//AhliClub.AddMember(Person1);
//AhliClub.AddMember(Person2);
//AhliClub.AddMember(Person3);
//AhliClub.ListAll();
//Console.WriteLine("----------------");
//Person1.RequestVacation(DateTime.Now, DateTime.Now.AddDays(6));
//Person2.CheckTarget(3300);
//AhliClub.ListAll();

Console.WriteLine("----------------------------------------------");

////adding BoardMembers to department
//Console.WriteLine("Department Board Members before");
//SD.AddStaff(Person4);
//SD.AddStaff(Person5);
//SD.AddStaff(Person6);
//SD.ListAll();
//Console.WriteLine("Department Board Members after resign and vacation");
//Person4.RequestVacation(DateTime.Now, DateTime.Now.AddDays(6));
//Person5.Resign();
//SD.ListAll();
//Console.WriteLine("-----------------");


////// adding Sales Person to Club
//Console.WriteLine("Ahly Club members");
/////
//AhliClub.AddMember(Person4);
//AhliClub.AddMember(Person5);
//AhliClub.AddMember(Person6);
//AhliClub.ListAll();
//Console.WriteLine("----------------");
//Person4.RequestVacation(DateTime.Now, DateTime.Now.AddDays(6));
//Person4.Resign();
//AhliClub.ListAll();


//Console.WriteLine("----------------------------------------------");

//adding BoardMembers to department
//Console.WriteLine("Department Employees before");
//SD.AddStaff(Person7);
//SD.AddStaff(Person8);
//SD.AddStaff(Person9);
//SD.ListAll();
//Console.WriteLine("Department employees after vacation  and retired age");
//Person8.RequestVacation(DateTime.Now, DateTime.Now.AddDays(11));
//Person7.EndOfYearOperation();

//SD.ListAll();
//Console.WriteLine("-----------------");


//// adding Sales Person to Club
Console.WriteLine("Ahly Club members");

AhliClub.AddMember(Person7);
AhliClub.AddMember(Person8);
AhliClub.AddMember(Person9);
AhliClub.ListAll();
Console.WriteLine("----------------");
Person9.RequestVacation(DateTime.Now, DateTime.Now.AddDays(6));
AhliClub.ListAll();
