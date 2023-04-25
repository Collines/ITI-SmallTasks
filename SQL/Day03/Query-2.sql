-- sp_addtype idDT, 'int'

create table instructor
(
id int primary key identity,
firstname varchar(50),
secondName varchar(50),
birthdate date,
overtime float unique,
salary float default 3000,
netSalary as (salary+overtime),
age as(year(getdate())-year(birthdate)),
hiredate date default getdate(),
addres varchar(50),
constraint c1 check(addres in ('Cairo','Alex')),
constraint c2 check(salary>=1000 and salary <=5000)
)

create table course
(
cid int primary key identity,
Cname varchar(50),
Duration int unique,
)

create table lab
(
Lid int primary key identity,
location varchar(50),
capacity int unique,
courseID int,
constraint c3 foreign key(courseID) references course(cid)
			on delete cascade on update cascade,
constraint c4 check(capacity <= 20),
)

create table instructor_courses
(
CID int,
instID int,
constraint c5 primary key (CID,instID),
constraint c6 foreign key(CID) references course(cid) on delete set null on update cascade,
constraint c7 foreign key(instID) references instructor(id) on delete set null on update cascade
)
