--------------------BUILT-IN PROCEDURE---------------------------
sp_help
sp_depends
sp_helpdb
sp_helptext
sp_columns
sp_stored_procedures
sp_rename
sp_bindefaults
sp_unbinddefaults
sp_spaceused
sp_bindrule
sp_addtype
sp_tables

--------------------HOW TO CREATE SIMPLE PROCEDURE---------------------------
create procedure  sp_students
as 
select * from students

sp_students

---------------------HOW TO CREATE SIMPLE PROCEDURE WITH PARAMETER----------------------------
create procedure getbyaddress(@b varchar(20))
as
select * from customers where caddress=@b

getbyaddress 'Bangalore'

------------------HOW TO ALTER PROCEDURE------------------------------
create procedure getbyaddress(@a varchar(20))
as
select custid, custname,caddress from customersname where caddress=@a


 getbyaddres'Pune'

-- how to drop the procedure
drop procedure getbyaddress
-----------------------------------------------------------------------------

-- procedure can contain simple logic with out queries as well
create procedure Addproc(@a int, @b int)
as
print @a + @b
-----------------------------------------------------------------------------
Addproc 10, 20
-----------------------------------------------------------------------------

-- can procedure return value?
create procedure Addproc1(@a int, @b int)
as
return @a + @b


-- how to execute procedure which returns ?
declare @result int
   exec @result = AddProc1 10,20
   print @result

-----------------------------------------------------------------------------
   -- can procedure return multiple values?
   --No
   create procedure Addproc2(@a int, @b int, @c int output,  @d int output)
as
set @c= @a + @b   -- a_+b  and a*b
set @d= @a * @b 



-- how to execute procedure which returns output params?
declare @m int
declare @n int   -- null

exec Addproc2 10,20,@m output ,@n output  -- reading the value from c and d
print @m
print @n  -- print the value
-----------------------------------------------------------------------------

-- how to create procedure with try/catch block

create procedure divide(@a int, @b int)
as
begin try
 print @a/@b
end TRY
begin catch
print 'Error OCCURED : ' + error_message()
end CATCH
-----------------------------------------------------------------------------

divide 10,0
-----------------------------------------------------------------------------
sp_depends customers
-----------------------------------------------------------------------------
-- how to execute the procedure with insert command

insert into customers exec getbyaddress 'pune'
-----------------------------------------------------------------------------
select * from customers

select * from customers


create table testing
(
custid int identity (10,10),
custname varchar(20),
age int
)


insert into testing values('Ashok',23)
insert into testing values('Logeshwaran',23)
select * from testing


create procedure myproc(@cname varchar(20),@ag int)
as
insert into testing values(@cname,@ag)
return scope_identity()
-- i want to know what values has been assiged for custid 

declare @res int
exec @res = myproc 'deepa',22
print @res


-----------------------------------------------------------------------------

create procedure displaydata(@tbl varchar(20))
as
declare @myquery nvarchar(100)
set @myquery = 'select * from ' + @tbl
exec sp_executesql @myquery -- runs the select command



displaydata 'employeesales'
