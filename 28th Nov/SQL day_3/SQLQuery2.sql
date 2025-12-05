select * from Orders
select * from customers 

-- inner join common values 
select * from customers inner join Orders 
on customers.custid = orders.custid

-- outer join (atleast from 1 table it will display all the records)
select * from customers right outer join Orders 
on customers .custid = orders.custid

select * from customers left outer join Orders 
on customers .custid = orders.custid

--result : display customers who made orders + who not made orders 
select * from customers full outer join Orders 
on customers .custid = orders.custid

--cross join (statistical data)
select * from customers cross join Orders

--self join 
select b.* from customers as a, customers as b
where a.age > b.age
and b.custname = 'Anvitha'

select a.* from customers as a, customers as b
where a.age > b.age
and b.custname = 'Anvitha'

--UNION ALL UNION, EXCEPT, INTERSECT
select * into customersname from customers 

select * from customers 
select * from Orders

--UNION ALL
select * from customers
union all
select * from customersname

--EXCEPT
select * from customers
except
select * from customersname

--Intersect
select * from customers
intersect
select * from customersname 

