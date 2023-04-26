--- preparation queries
create table jobs (
jobID int primary key identity,
jobType varchar(20),
)
insert into jobs values ('Clerk'),('Manager')

alter table employee
add jobtype int, hireDate date default(getdate()), constraint c1 foreign key(jobType) references jobs(jobID)

alter table project
add budget int

update Employee set jobtype = 1 where 
ssn not in (select MGRSSN from Departments)
update Employee set jobtype = 2 where 
ssn in (select MGRSSN from Departments)

declare c1 cursor for
select hiredate from employee
declare @hdate date, @counter int = 1
open c1
fetch c1 into @hdate
while @@FETCH_STATUS =0
	begin
	update Employee set hireDate = DATEADD(DAY,-@counter,GETDATE())
	where current of c1
	fetch c1 into @hdate
	set @counter +=10
	end
close c1
deallocate c1;

--- 1
create view v_clerk(name,project,[hiring date]) as
select e.Fname+' '+e.Lname,p.Pname,e.hireDate from Employee e inner join jobs j
on j.jobID = e.jobtype inner join Works_for wf
on wf.ESSn = e.SSN inner join Project p
on p.Pnumber = wf.Pno

select * from v_clerk


-- 2
create view v_without_budget as
select Pname,Pnumber,Plocation,City,Dnum from project

go

--3
create view v_count([project], [no. of jobs]) as
select pname, count(w.pno) from Project inner join Works_for w
on w.Pno = Pnumber
group by pname
select * from v_count;

go

-- 4
create view v_project_p2 as
select name,project from v_clerk where project ='p2'

select * from v_project_p2

-- 5
alter view v_without_budget as
select Pname,Pnumber,Plocation,City,Dnum from project where Pname in ('p1','p2')

select * from v_without_budget

-- 6
drop view v_clerk,v_count

-- 7
