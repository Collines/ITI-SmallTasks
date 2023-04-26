-- 1
create view stdCourses(fullname,[course name]) as 
select st.St_Fname+' '+st.St_Lname, c.Crs_Name from student st inner join Stud_Course sc
on st.St_Id = sc.St_Id and sc.Grade >50 inner join Course c
on c.Crs_Id = sc.Crs_Id

select * from stdCourses
go
-- 2
create view managerTopics([Manager Name],[Topic name]) with encryption as 
select ins.Ins_Name, t.Top_Name from Department dep inner join Instructor ins
on dep.Dept_Manager = ins.Ins_Id inner join Ins_Course ic
on ins.Ins_Id = ins.Ins_Id inner join course c
on c.Crs_Id = ic.Crs_Id inner join Topic t
on t.Top_Id = c.Top_Id

select * from managerTopics;
go
-- 3
create view instDept(instructor,department) as
select i.Ins_Name, d.Dept_Name from Instructor i inner join Department d
on i.Dept_Id = d.Dept_Id and d.Dept_Name in ('SD','Java')

select * from instDept
go

-- 4
create view V1 as
select * from Student where St_Address in ('alex','cairo')
with check option
go
-- 5
create view projectEmployees([Project Name],[No. of Employees]) as
select  p.Pname, count(wf.pno) from Company.Project p inner join Works_for wf
on p.Pnumber = wf.Pno
group by p.Pname
go
-- 6
create schema company
alter schema company transfer departments
go
create schema [Human Resource]
alter schema [Human Resource] transfer Employee
go
-- 7
create nonclustered index myindex1 on department(manager_hiredate) -- created successfully

-- 8
create unique index myindex2 on student(st_age); -- error because there are many age duplicates

-- 9
declare cursor1 Cursor 
for select salary from [Human Resource].Employee
for update
declare @salary int
open cursor1
fetch cursor1 into @salary
while @@FETCH_STATUS=0
	begin
		if @salary < 3000
		update [Human Resource].Employee set salary = salary*1.1
		where current of cursor1
		else
		update [Human Resource].Employee set salary = salary*1.2
		where current of cursor1
		fetch cursor1 into @salary
	end
close cursor1
deallocate cursor1

-- 10
declare c2 cursor
for 
	select d.Dept_Name, i.Ins_Name from Department d inner join Instructor i
	on d.Dept_Manager = i.Ins_Id
for read only
declare @deptName varchar(20), @mgrName varchar(20)
open c2
fetch c2 into @deptName, @mgrName
	while @@FETCH_STATUS = 0
	begin
		select @deptName,@mgrName
		fetch c2 into @deptName, @mgrName
	end
close c2
deallocate c2

-- 11
declare c2 cursor
for 
	select Ins_Name from Instructor
for read only
declare @instName varchar(20), @allNames varchar(max) = ''
open c2
fetch c2 into @instName
	while @@FETCH_STATUS = 0
	begin
		set @allNames=concat(@allNames,',',@instName)
		fetch c2 into @instName
	end
	select @allNames
close c2
deallocate c2

-- 12
