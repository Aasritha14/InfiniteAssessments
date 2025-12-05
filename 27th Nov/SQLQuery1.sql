select * from customers
select * from Orders

--1. display all teh records  from customers who made a purchase of books --

select * from customers 
where custid in (select custid from Orders where product='Notebook')

--2. display all the records from customer who made a purchase of books , toys, cd--

select * from customers 
where custid in (select custid from Orders where product in ('Book', 'Toys', 'CD'))

--3. display the list of customers who never made any purchase--
select * from customers 
where custid not in (select custid from Orders)

--4. display the second highest age from customers (do not use top keyword)
select max(age) as secondhighest from customers
where age <(select max(age) from customers )

--5. display the list from orders  where customers stays in bangalore 
select * from Orders
where custid in(select custid from customers where caddress = 'Bangalore')

--6. display list of customer who made lowest purchase (in terms of quantity) 
select * from customers where custid in (select custid from Orders where qty in (select min(qty) from Orders))

--7.display the list of customer who's age is greater then  ajay's age ( but we dont know ajay's age)
select * from customers
where age > (select age from customers where custname = 'Ajay')

--8.update customer table where custid =100's age  =      custid=200's age
update customers set age = 
( select age from customers where custid =200) 
where custid = 100

--9.Display those details who made orders in December of any year --

select * from customers where custid in(select custid from Orders
where month(orderdate) =12);

--10.Show all  orders made before first half of the month (before the 16th of the month who does not reside in bangalore).
select * from Orders 
where day(orderdate)<16 and custid in (select custid from customers where caddress <>   'Bangalore')

--11. Display list of customers  from delhi and Bangalore who made purchase of less than 3 product  
select * from customers where caddress in('Delhi', 'Bangalore') and custid in ( select custid from Orders where qty <3)

--12.Display list of orders where price is greater than average price 
select * from Orders where price >(select avg(price) from Orders)

--13 update orders table increasing  price by 10%  for customers residing in Bangalore and who have purchased books.
select * from Orders

update Orders set price = (select (price+price*0.1) 
from Orders where qty >= 1 and 
custid in (select custid from customers where caddress in ('Bangalore')))

/**14Display orderdetails in following format 
OrderID-Date Total(price*qty) 
100-1/1/2000 500**/

select  concat(OrderID, '-', convert(varchar(10), OrderDate, 101)) as [OrderID-Date],
(price * qty) as Total From Orders

