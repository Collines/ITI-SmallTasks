select d.Dependent_name, d.Sex, e.Fname+' '+e.Lname as Employee from Dependent d inner join Employee e
on e.Sex = 'f' and d.Sex = 'f' and e.SSN = d.ESSN
union 
select d.Dependent_name, d.Sex, e.Fname+' '+e.Lname as Employee from Dependent d inner join Employee e
on e.Sex = 'm' and d.Sex = 'm' and e.SSN = d.ESSN

select p.Pname, sum(w.Hours) as totalWeeklyHours from Project p join Works_for w
on p.Pnumber = w.Pno
group by Pname
--3
select d.* from Departments d inner join Employee e 
on e.SSN = (select min(ssn) from Employee) and e.Dno = d.Dnum
--4
select d.Dname, max(isnull(e.salary,0)) as maxSalary, min(isnull(e.salary,0)) minSalary, AVG(isnull(e.Salary,0)) as avgSalary from Departments d join Employee e
on d.Dnum = e.Dno
group by d.Dname;
--5
select e.SSN ,e.fname+' '+e.lname as fullname from Employee e inner join Departments d
on e.SSN = d.MGRSSN and e.SSN not in (select essn from Dependent)
group by fname+' '+lname , e.ssn
--6
select d.Dnum, d.Dname, count(isnull(e.ssn,0)) as countOfEmployees,
avg(isnull(e.Salary,0)) as avgDepSalary,
(select avg(isnull(salary,0)) from Employee) as avgEmployeesSalary
from Departments d inner join Employee e
on d.Dnum = e.Dno
group by d.Dname, d.Dnum
having avg(isnull(e.Salary,0)) < (select avg(isnull(salary,0)) from Employee)
--7
select e.dno,e.Fname+' '+e.lname as fullname, p.pname as projectName from Employee e inner join Works_for w
on e.SSN = w.ESSn inner join Project p
on w.Pno = p.Pnumber
order by e.Dno, fullname

--8
--select top 2  salary from Employee 
--order by  salary desc
select
  (SELECT MAX(Salary) FROM Employee) as maxSalary,
  (SELECT MAX(Salary) FROM Employee
	WHERE Salary NOT IN (SELECT MAX(Salary) FROM Employee )
  ) as secondMaxSalary


-- 9
/*select e.fname+' '+e.lname as name from Employee e inner join Dependent d
on d.Dependent_name like '%'+e.fname+'%'*/
select e.fname+' '+e.lname as name from Employee e inner join Dependent d
on e.fname+' '+e.lname=d.Dependent_name

select e.fname from Employee e intersect select Dependent_name from Dependent

-- 10
select ssn, fname+' '+lname from Employee e
where exists (select ESSN from Dependent where ESSN = e.SSN)

--11
insert into Departments (Dname,Dnum,MGRSSN,[MGRStart Date]) values ('DEPT IT',100,112233,'1-11-2006')

--12
update Departments set MGRSSN = 968574
where Dnum = 100
update Departments set MGRSSN = 102672
where Dnum = 20
update Employee set Superssn = 102672
where SSN = 102660

--13
update Departments set MGRSSN = 102672
where MGRSSN =  223344
update Employee set Superssn = 102672
where Superssn = 223344
update Works_for set ESSn = 102672
where ESSn = 223344
delete from Dependent
where ESSN = 223344
delete from Employee
where SSN = 223344
--14
update Employee set Salary = salary * 1.3
where SSN = (
select w.ESSn from Project p inner join Works_for w
on p.Pname = 'Al Rabwah' and Pnumber = w.Pno
)



--6
select d.Dnum, d.Dname, count(isnull(e.Salary,0)) as countOfEmployees,avg(isnull(e.Salary,0)) as avgDepSalary,(select avg(isnull(salary,0)) from Employee) as avgEmployeesSalary  from Departments d inner join Employee e
on d.Dnum = e.Dno
group by d.Dname, d.Dnum
having avg(isnull(e.Salary,0)) < (select avg(isnull(salary,0)) from Employee)


select d.dnum, d.Dname, (select count(ssn) from Employee) as 'number of employees' from Departments d inner join Employee e
on d.Dnum = e.Dno
group by  d.dnum, d.Dname