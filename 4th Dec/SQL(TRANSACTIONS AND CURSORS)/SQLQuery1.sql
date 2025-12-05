-----------------------------------------------TRANSACTIONS AND CURSORS------------------------------------------------------

/**
1. Basic Transaction — Commit / Rollback 
Create a table BankAccount with sample records. 
Write a transaction that transfers money from one account to another. 
If the source account balance becomes negative, roll back the transaction; otherwise 
commit.
**/

Create table BankAccount(
AccountId int primary key,
AccountHolder varchar(50),
Balance decimal(10,2)
)

insert into BankAccount values 
(1,'Aasritha',50000.00),
(2,'Jungkook',75000.00),
(3,'Deepti',50000.00)

select * from BankAccount


declare @amountforsend decimal(12,2)=30000
declare @SourceAccountid int=1
declare @TargetAccountid int=2
begin transaction
update BankAccount
set Balance= Balance-@amountforsend
where AccountId=@SourceAccountid
update BankAccount
set Balance=Balance+@amountforsend
where AccountId=@TargetAccountid
 
if(select Balance from BankAccount where AccountId=@SourceAccountid)<0
begin
print 'Insufficiant Balance'
Rollback Transaction
end
else
begin
print 'Transaction success'
commit transaction
end

/**
2. Using SAVEPOINT 
Insert three new records into a table Orders. 
Create a SAVEPOINT after each insert. 
Rollback only the second insert using the SAVEPOINT, then commit the remaining inserts.
**/

select * from Orders;
 
begin transaction
insert into Orders values(18,1012,'2022-11-02','books',120,3)
save transaction sp1
insert into Orders values(19,1013,'2022-12-02','mobile',10000,1)
save transaction sp2
insert into Orders values(20,1014,'2022-11-03','books',2300,2)
save transaction sp3
 
rollback transaction sp1
insert into Orders values(20,1014,'2022-11-03','books',2300,2)
save transaction sp
commit transaction;

/**
3. Handling Errors with TRY…CATCH 
Write a transaction that updates prices in a Products table. 
Introduce a division-by-zero error inside the transaction. 
Use TRY…CATCH to rollback the transaction and log the error message in a separate 
ErrorLog table 
**/

select * from ErrorLog

select * from Product1
 begin try 
begin Transaction 
update Product1
set price = 2000 where productid = 1
declare @x int = 1/0
commit transaction
end try
begin catch
rollback transaction
insert into ErrorLog(errordate,errormessage)
values(getdate(),error_message())
print 'Error occured rollback transaction.. insert error msg in error log table'
end catch;

/**
4. Nested Transactions 
Create nested transactions: 
• Outer transaction inserts a customer 
• Inner transaction inserts an order for the customer 
• Force an error in the inner transaction 
Practice observing whether the outer transaction is committed or rolled back.
**/

begin tran outertrans
insert into customer(custname)
values('riya');
Declare @CustId int=SCOPE_IDENTITY();
Begin TRY
	begin tran innertrans
	insert into orders (custid,price)
	values(@CustId,5000);
	insert into orders (custid,price)
	values(@CustId/0,5000);
	commit Tran innertrans;
END TRY
BEGIN CATCH
	RollBack tran innertrans;
	Print'error';
END Catch
Commit tran outertrans;
select * from customer;
select *from orders;

/**
5.Isolation Level – Dirty Read 
Use two sessions: 
• Session 1: Open a transaction, update a row, but don’t commit 
• Session 2: Use SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED and read 
the same row 
Check whether dirty reads are allowed.
**/

--SESSION 1
 Begin Transaction

 update Employees
 set Salary = 90000
 where EmpId =101

 --SESSION 2
 Set Transaction isolation level read uncommitted

 select Salary 
 from Employees
 where EmpId = 101

 /**
 6. Isolation Level – Non-repeatable Read 
Using two sessions: 
• Session 1 reads a row twice inside a transaction 
• Session 2 updates and commits the same row in between 
Observe changes and understand non-repeatable reads.
**/


/* =========================================================
   Non-Repeatable Read Demo (SQL Server) — Single Script
   ========================================================= */

-- 0) Setup (run once in any session)
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
    DROP TABLE dbo.Employees;
GO

CREATE TABLE dbo.Employees (
    EmployeeID INT PRIMARY KEY,
    Name       NVARCHAR(100),
    Salary     INT
);
GO

INSERT INTO dbo.Employees(EmployeeID, Name, Salary)
VALUES (101, N'Alex', 80000);
GO


/* =========================
   SESSION 1 (Reader)
   ========================= */
-- Open this in SSMS Tab #1

-- Use READ COMMITTED (default), where non-repeatable reads can occur
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
begin transaction;

print 'Session 1: First read';
select  Salary as FirstReadSalary
from dbo.Employees
where EmployeeID = 101;

-- >>> PAUSE HERE <<<
-- Now switch to SSMS Tab #2 and run the "SESSION 2" block below.
-- After Session 2 COMMITs, come back and run the next lines.

print 'Session 1: Second read (after Session 2 updated & committed)';
select Salary as SecondReadSalary
from dbo.Employees
where EmployeeID = 101;

-- Expectation:
-- FirstReadSalary = 80000
-- SecondReadSalary = 90000 (changed in between by Session 2)

commit;
GO


/* =========================
   SESSION 2 (Writer)
   ========================= */
-- Open this in SSMS Tab #2 (run while Session 1 is paused between reads)

begin transaction;

print 'Session 2: Updating salary to 90000';
update dbo.Employees
set Salary = 90000
where EmployeeID = 101;

commit;
GO


/* =========================
   Verification & Cleanup
   ========================= */

-- Final check (run anywhere after both sessions finished)
select  EmployeeID, Name, Salary
from dbo.Employees
where EmployeeID = 101;

-- Optional: reset salary if you want to repeat the demo
-- UPDATE dbo.Employees SET Salary = 80000 WHERE EmployeeID = 101;








