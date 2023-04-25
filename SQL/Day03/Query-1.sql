select d.Dnum, d.Dname, e.SSN as mgrID, e.fname as mgrName from Departments d inner join Employee e
on d.MGRSSN = e.SSN;

select d.Dname, p.Pname from Departments d  join Project p
on d.Dnum = p.Dnum;

select d.*, e.Fname from Dependent d  join Employee e
on d.ESSN = e.SSN;

select pnumber, pname, plocation from Project
where city in ('Cairo','Alex')

select * from Project
where Pname like 'a%'

select * from Employee
where Dno = 30 and salary between 1000 and 2000

select e.Fname, w.Hours*7 as workingHours, p.Pname from Employee e join Works_for w
on e.Dno = 10 and e.SSN = w.ESSn
join Project p
on p.Pname = 'Al Rabwah' and p.Pnumber=w.Pno and w.Hours *7 >= 10

select e.Fname+' '+e.Lname as Fullname, s.Fname+' '+s.Lname as SuperVisor from Employee e inner join Employee s
on s.SSN = e.Superssn and s.Fname+' '+s.Lname = 'Kamel Mohamed'

select e.Fname, p.Pname from Employee e join works_for w
on w.ESSn = e.SSN  join Project p
on w.Pno = p.Pnumber
order by p.Pname;

select p.Pnumber, d.Dname, e.Lname, e.Address, e.Bdate from Project p join Departments d
on d.Dnum=p.Dnum and  p.City = 'Cairo' join Employee e
on d.MGRSSN = e.SSN

select e.* from Employee e join Departments d
on d.MGRSSN = e.SSN

select * from Employee e left outer join Dependent d
on e.SSN = d.ESSN

insert into Employee (SSN,Superssn,Salary,Dno,Fname,Lname,Bdate,Sex,Address) values (102672,112233,3000,30,'Mohamed','Salah','03-06-1997','M','Cairo');

insert into Employee (SSN,Dno,Fname,Lname,Bdate,Sex,Address) values (102660,30,'Mohamed','Essam','03-06-1997','M','Cairo');

update Employee set Salary = salary*1.2 where SSN = 102672;