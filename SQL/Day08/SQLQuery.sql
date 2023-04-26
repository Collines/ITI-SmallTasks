--- 1
use ITI
create proc studDepData as
	select count(s.St_Id) [student number], d.Dept_Name from Student s inner join Department d
	on s.Dept_Id = d.Dept_Id
	group by d.Dept_Name

studDepData;

--- 2
use Company

alter proc projNum as
declare @num int
declare @t table (fname varchar(20),lname varchar(20),pid int,RN int)
	insert into @t
	select Fname,Lname,p.Pnumber, Row_number() over(order by Fname desc) as RN from Employee e inner join Works_for wf
	on wf.ESSn = e.SSN inner join Project p
	on p.Pname = 'p2' and p.Pnumber = wf.Pno
	select @num=count(*) from @t
	if @num>=3
		select 'The number of employees in the project p1 is 3 or more'
	else
		while @num >= 1
		begin
			select 'The following employees work for the project p1 '+fname+' '+lname from @t where RN = @num
			set @num -=1
		end
	
	projNum

--- 3
create proc updateRemovedEmp @oldEmpId int, @newEmpId int, @Pnum int as
	update Works_for set ESSn = @newEmpId
	where ESSn = @oldEmpId and Pno = @Pnum

--- 4
create table Audit (
projectNo varchar(20),
UserName varchar(20),
ModifiedDate date,
Budget_Old int,
Budget_New int
)
insert into Audit values ('P2','Dbo','2008-01-31','95000','200000')

create trigger t1 on project
after update as
	if update(budget)
	begin
		declare @pno int, @oldbudg int, @newbudg int
		select @pno=Pnumber, @newbudg=budget from inserted
		select @pno=Pnumber, @oldbudg=budget from deleted
		insert into Audit values(@pno,SUSER_NAME(),GETDATE(),@oldbudg,@newbudg)
	end

--- 5
use ITI
create trigger t1 on department
instead of insert as
	select 'you can’t insert a new record in that table'

insert into Department(Dept_Id,Dept_Name) values (80,'Testing')
	
--- 6
use Company
alter trigger t2 on employee
instead of insert as
	if format(GETDATE(),'MMMM') = 'march'
		select 'you can’t insert a new record in that table in March'
	else
		insert into Employee select * from inserted

insert into Employee(ssn,jobtype) values (156998,1)

--- 7
use ITI
create table student_audit(
serverUserName varchar(30),
Date date,
note varchar(80)
)
create trigger t3 on student
after insert as
	declare @key int
	select @key=St_Id from inserted
	insert into student_audit values
	(SUSER_NAME(),GETDATE(),SUSER_NAME()+' Inserted a new row with key= '+CONVERT(varchar(20),@key)+' in Student table')

insert into student (St_Id,St_Fname) values (15153,'MoSalah')

--- 8
create trigger t4 on student
instead of delete as
	declare @key int
	select @key=St_Id from deleted
	insert into student_audit values
	(SUSER_NAME(),GETDATE(),SUSER_NAME()+' Tried to delete row with key= '+CONVERT(varchar(20),@key))

	delete from Student where St_Id=15153