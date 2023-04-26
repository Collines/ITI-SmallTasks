--1
select count(st_age) as studentNumber from Student

--2
select distinct Ins_Name  from Instructor

--3
select s.St_Id as [Student ID], s.St_Fname+' '+s.St_Lname as [Student Full Name], d.Dept_Name as [Department Name] from Student s inner join
Department d on d.Dept_Id = s.Dept_Id

--4
select i.* from Instructor i left outer join
Department d on d.Dept_Id = i.Dept_Id

--5
select s.St_Fname+' '+s.St_Lname as [Student Full Name], c.Crs_Name from Student s inner join Stud_Course sc
on sc.Grade is not null and sc.St_Id = s.St_Id inner join Course c
on c.Crs_Id = sc.Crs_Id

--6
select c.Top_Id as [topic id],count(c.Crs_Id) as [Number of courses] from course c inner join Topic t
on t.Top_Id = c.Top_Id
group by c.Top_Id

--7
select max(Salary) as [Max salary], min(Salary) as [Min salary] from Instructor

--8
select * from Instructor
where salary < (select avg(isnull(salary,0)) from Instructor)

--9
select d.Dept_Name from Department d inner join Instructor i
on i.Salary  = (select min(salary) from Instructor) and i.Dept_Id = d.Dept_Id

--10
select top(2) salary from Instructor order by salary desc;

--11
select Ins_Name,coalesce(Convert(varchar(20),salary),'instructor bonus') from Instructor

--12
select avg(isnull(salary,0)) as [Average salary] from Instructor

-- 13
select s.St_Fname as studentname, super.*  from student s inner join Student super
on super.St_Id = s.St_super

--14
Select *
from (select *, Row_number() over(partition by dept_id order by salary desc) as RN
      from Instructor where salary is not null) as X
where RN in (1,2)

--15
Select *
from (select *, Row_number() over(partition by dept_id order by newid() desc) as RN
      from Student) as X
where RN = 1


------- part 2
--1
select SalesOrderID,ShipDate from Sales.SalesOrderHeader
where OrderDate >= '7/28/2002' and OrderDate <= '7/29/2014'

--2
select ProductID, Name from Production.Product where
StandardCost < 110

--3
select ProductID, Name from Production.Product where
Weight is null

--4
select * from  Production.Product where
color in ('Silver', 'Black','Red')

--5
select ProductID, Name from Production.Product where
Name like 'B%'

--6
select * from Production.ProductDescription where
Description like '%[_]%';

--7
select sum(TotalDue) as [sum of total due] from Sales.SalesOrderHeader
where OrderDate >= '7/1/2001' and OrderDate <= '7/31/2014'

--8
select distinct HireDate from HumanResources.Employee

--9
select avg(ListPrice) from (select distinct listprice from Production.Product) as x

--10
select 'The ['+p.Name+'] is only! '+'['+ CONVERT(varchar(50),p.ListPrice)+']' as data from Production.Product p
where ListPrice between 100 and 120
order by ListPrice desc

--11
select rowguid,name,SalesPersonID,Demographics into [store_Archive]
from Sales.Store

select rowguid,name,SalesPersonID,Demographics into [store_Archive2]
from Sales.Store where 2=1

--12
select format(getdate(),'dd-MM-yy')
union
select format(getdate(),'dd-MM-yy hh:mm:ss')
union
select format(getdate(), 'dddd, MMMM, yyyy')
union
select format(getdate(), 'MMM dd yyyy')