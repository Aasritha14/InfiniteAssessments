create database db_ADODOTNET_db

create table Employee (
    EmpID int identity(1,1) primary key,
    EmpName varchar(100),
    Salary decimal(10,2),
    DateOfJoin date,
    DeptID int foreign key references Department(DeptID)
);
create table Department (
    DeptID int primary key,
    DeptName varchar(50)
);

insert into  Department (DeptID, DeptName)
values
(10, 'HR'),
(20, 'Finance'),
(30, 'IT'),
(40, 'Sales'),
(50, 'Operations');

insert into Employee (EmpName, Salary, DateOfJoin, DeptID)
values
('Aasritha', 52000, '2022-04-15', 30),
('Akshay', 60000, '2021-11-20', 30),
('Anvith Reddy', 48000, '2023-02-10', 10),
('ASHOK', 55000, '2021-07-18', 40),
('Deepalakshmi', 47000, '2022-01-25', 20),
('Deepti', 51000, '2023-03-12', 50),
('Dharani sri', 46000, '2020-09-30', 10),
('Humera', 62000, '2021-12-05', 30)

select * from Employee
select * from Department

--------------------------------------------------------------------------------------------------------

alter procedure sp_emp(@d int, @sal int )
as 
select * from Employee where DeptID=@d and Salary >=@sal
create procedure sp_emp1
as 
select * from Employee 

sp_emp 10

------------------------------------------------------------------------------------------------------------

create table  one
(
cid int primary key,
cname varchar(20)
)

create table  two
(
cid int primary key,
cname varchar(20)
)
----------------------------------------------------------------------------------------------------------
---------------------------------------ASSIGNMENT------------------------------------------------------------
/**Task-1 
Public void GetTransactions(d1 DateTime  , d2 DateTime) 
{ 
// logic to display all records from Employees who date of join  between 
2 dates using procedures 
}
**/

alter procedure sp_GetEmployeeJoinDate(@d1 date, @d2 date)
as
begin
select * from Employee
where DateOfJoin between @d1 and @d2
order by DateOfJoin
end

sp_GetEmployeeJoinDate

/**
Task-2 
Public void GetCommonRecords(int id) 
{ 
// logic to display common records from Employee and department 
based on id  
}
**/

Create procedure sp_GetCommonEmployeeDepartment(@deptId int)
as
begin
select e.EmpId,e.EmpName,e.Salary,e.DateOfJoin,d.DeptID,d.DeptName from Employee as e join Department as d
on e.DeptID=d.DeptID
where d.DeptID=@deptId order by e.EmpID
end

/**Task-3 
 
Public void InsertRecordsusingtrans() 
{ 
// logic to insert records to employee and department using transaction 
}
**/
Create procedure sp_InsertEmployeeDepartment(@DeptID int, @DeptName varchar(50), @EmpName varchar(50),@Salary decimal(11,3),@DateOfJoin date)
as 
begin
begin transaction

insert into Department values   
(60, 'Analytics'),
(70, 'Marketing'),
(80, ' Web Developer')
insert into Employee values 
('John Doe',55000, '2024-08-01', 60),
('Jungkook', 70000,'2025-04-11',70),
('Sahu',50000,'2024-09-12',80)
end

/**Task-4 
 
Connected Insert + Fetch New Identity 
For a Employee table with an identity primary key: 
• Insert a new Employee using INSERT  command. 
• Immediately fetch the newly inserted identity using: 
o SCOPE_IDENTITY() 
• Validate that the ID exists by fetching it again with a new command.
**/

Create procedure sp_InsertEmployeeandValidate(@EmpName varchar(100), @Salary decimal(10,2), @DateOfJoin date, @DeptID int)
as
begin
insert into Employee values(@Empname,@Salary,@DateOfJoin,@DeptID)
select Scope_identity()
end;

/**
Task-5 
Multi-Result Reader with Joins 
A company has Employees and Department tables. 
Write a C# program that: 
• Executes a single SqlCommand that returns two result sets: 
1. List of employees 
2. List of Departments 
• Reads first result set via SqlDataReader.Read(), then moves to the next 
using NextResult().
**/

Create procedure sp_GetEmployeeandDepartment
as 
begin
select 
EmpID, EmpName, Salary, DateOfJoin, DeptID from Employee order by EmpID;
select DeptID, DeptName from Department order by DeptID;
end

/**
Task-6 
Using Stored Procedure That Returns Multiple Output Parameters 
Stored procedure: 
sp_GetEmployeeDet 
   @Empid, 
   @DateofJoin OUTPUT, 
   @Department  OUTPUT 
Task: 
• Call this stored procedure using SqlCommand in connected mode. 
• Retrieve output parameters. 
• Display formatted summary. 
• Check if connection is opened or not, display appropriate message if connection is 
not opened 
• Handle exception for all methods using SqlException Class 
• Pass all the data dynamically. 
• Using single connection for all above operations
**/

Create procedure sp_GetEmployeeDet(@EmpId int,@DateOfJoin  date output, @Department  varchar(50) output)
as
begin
set @DateOfJoin = '2025-04-11';
set @Department = 'Marketing';

select top (1)
@DateOfJoin = e.DateOfJoin,
@Department = d.DeptName
from Employee e join Department d on e.DeptID = d.DeptID where e.EmpID = @EmpId;
end

-----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------DISCONNECTED ARCHITECTURE------------------------------------------------------------------------
Select * from Employee

Select * from Department

/**
Task-1 
Develop a code to print all record from Employee and Department
**/

/**
Task-2 
From a Employee Table 
• Create DataView having following conditions: 
o Salary  > 47000 
o Department = 10 
o EmployeeName Starts with 'M' 
• Apply sorting.
/**

-----------------------------------------------------------------------------------------------------------












