--1
create function getMonth(@date date)
returns Varchar(15)
	begin
		declare @monthName varchar(15)
		select @monthName=format(@date,'MMMM')
		return @monthName	
	end
	
select dbo.getMonth('2017-07-15')

--2
create function getRange(@num1 int, @num2 int)
returns @t table
			(
			 [values] int
			)
as
	begin
		while @num1 <= @num2
		begin
			insert into @t values (@num1)
			set @num1+=1
		end
		return
	end

	select * from getRange(10,50)

--3
alter function getStudData(@stdId int)
returns @t table 
(
	StudName varchar(50),
	DepartmentName varchar(50)
) as 
begin
	insert into @t
	select s.St_Fname+' '+s.St_Lname as Fullname, d.Dept_Name as DepartmentName from Student s inner join Department d
	on d.Dept_Id=s.Dept_Id and s.St_Id= @stdId
	return
end

select * from getStudData(1)

--4
create function getStdNameStatus(@stdID int)
returns Varchar(30)
	begin
		declare @fname varchar(30), @lname varchar(30), @txt varchar(50)
		select @fname=St_Fname,@lname=St_lname from Student where St_Id=@stdID
		if(@fname is null and @lname is null)
			set @txt = 'First name & last name are null'
		else if(@fname is null)
			set @txt = 'First name is null'
		else if(@lname is null)
			set @txt = 'Last name is null'
		else
			set @txt = 'First name & last name are not null'
		return @txt	
	end

	select dbo.getStdNameStatus(1--13,14)

--5
Create function getMGRData(@mgrID int)
returns table
	as
	return
	(
	 select d.Dept_Name,i.Ins_Name,d.Manager_hiredate from Department d inner join Instructor i
	 on d.Dept_Manager = i.Ins_Id and i.Ins_Id = @mgrID
	)

	select * from getMGRData(1)

--6
create function getStudName(@name varchar(20))
returns @t table 
(
	StudName varchar(50)
) as 
begin
	if(@name ='first name')
	begin
	insert into @t
	select ISNULL(St_Fname,'[no first name]') from Student
	end
	else if(@name ='last name')
	begin
	insert into @t
	select ISNULL(St_Lname,'[no last name]') from Student
	end
	else if(@name ='full name')
	begin
	insert into @t
	select ISNULL(St_Fname,'[no first name]')+' '+ISNULL(St_Lname,'[no last name]') from Student
	end
	return
end

select * from getStudName('full name')

--7
select st_id, SUBSTRING(St_Fname,1,len(St_Fname)-1) from Student

--8
delete from Stud_Course
where St_Id in (select std.St_Id from Student std inner join Department d
on d.Dept_Id = std.Dept_Id and d.Dept_Name = 'SD')

-- 9
create table last_transactions -- Target table Must be Physical
(
userID int,
transAmount float
constraint primaryC1 primary key(userID,transAmount)
)
insert into last_transactions values (1,4000),(1,2000),(1,100000)
select * from last_transactions
--
create table daily_transactions -- Source
(
 userID int,
transAmount float
constraint primaryC2 primary key(userID,transAmount)
)
select * from daily_transactions

insert into daily_transactions values (1,1000),(2,2000),(3,1000)

merge into last_transactions as T
using daily_transactions as S
on T.userID = s.userID
when matched then
update set T.transAmount = s.transAmount
when not matched then
insert values(s.UserID,s.transAmount);

