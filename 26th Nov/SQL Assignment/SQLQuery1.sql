create database Custdb;

-- create customers table --

create table customers(
custid int, 
custname varchar(20),
age tinyint,
caddress varchar(50),
cphone varchar(10)
)

insert into customers values
(101, 'Aasritha', 21, 'Bangalore', '7878787879'),
(102, 'Jungkook', 28, 'SouthKorea', '9098909890'),
(103, 'Deepti', 23, 'UttarPradesh', '7876787678'),
(104, 'Asritha', 22, 'Undavalli', '5656565454'),
(105, 'Pujitha', 24, 'Hyderabad', '4343434567'),
(106, 'Sahu' , 34, 'Pune', '6767676767'),
(107, 'Anvitha', 16, 'Vijayawada', '7865243532')


-- Second Orders table create --
create table Orders(
custid int,
orderid int,
orderdate date,
product varchar(20),
price float,
qty int
)

insert into Orders values
(101, 1010, '2025-11-08', 'Book', 98.99, 2),
(102, 2987, '2025-03-23', 'Cosmetic', 700.99, 4),
(103, 5677, '2024-01-20', 'Dishwasher', 350.00, 5),
(104, 5688, '2024-04-17', 'Bags', 20000.00, 2),
(105, 2433, '2025-02-14', 'Watch', 150000.00, 1),
(106, 6788, '2025-03-01', 'Dress', 3000.00, 4),
(107, 5698, '2024-06-02', 'IPhone', 150000.00, 1),
(108, 4566, '2025-12-08', 'Laptop', 78000.00, 1)



-- 1.Display the list of customers who resides in Bangalore --
select * from customers where caddress = 'Bangalore'

-- 2. Display the list of customers who does not resides in Bangalore or chennai --
select * from customers where caddress not in ('Bangalore', 'Chennai')

-- 3.Display the list of customers who’s age is greater then 50 and does not resides in Bangalore --
select * from customers where age > 50 and caddress <> 'Bangalore'

-- 4.Display the list of customers who’s name starts with A --
select * from customers where custname like 'A%'

-- 5.Display the list of customers who’s name contains a word Br --
select * from customers where custname like 'Br'

-- 6.Display the list of customer who’s name start between a to k --
select * from customers where custname >= 'A' and custname < 'K'

-- 7. Display the list of customers who’s name is 5 character long --
select * from customers where len(custname) = 5

-- 8.Display the list of customer who’s name -- a. Start with s -- b. Third character is c-- c. Ends with e 

select * from customers where custname like 'S_C%e'

-- 9. Display unique customer names from customers table --
select distinct custname  from customers 

-- 10.. List orders details where qty falling in the range 100-200  and 700-1200 
select * from Orders where (qty between 100 and 200) or (qty between 700 and 1200) 

-- 11.  List customer details where custname beginning with AL and endingwith N  
select * from customers where custname like 'AL%N'

-- 12. Display what each  price would be if a 20% price increase were to take place. Show the custid , old price and new price ,using meaningful headings(use orders table
select * from Orders;
select custid as customer_Id,price as Old_Price,
price + (price * 0.20) as new_Price
from Orders;

-- 13.. Display top 3 highest qty from orders table -- 
select top 3 qty from Orders order by qty desc 

-- 14. Display how many times customers have purchased a product (displaycount and customerid from orders table) -- 
select custid as customerid, count(*) as purchasecount from customers
group by custid

--15. Display the list of orders who’s orders made earlier then 5 years from now --
select * from Orders where orderdate < DateAdd(year, -5, GetDate());

--16.  Select * from customers where custname is null --
select * from customers where custname is Null

/**17.Display orderdetails in following format 
OrderID-Date Total(price*qty) 
100-1/1/2000 500**/
select
    concat(orderid, '-', format(orderdate, 'dd/MM/yyyy')) as Order_Details,
    (price * qty) AS Total
from Orders

--18.  Update orders table by decreasing price by 20% for qty > 50 --
update  Orders set price = price * 0.80 where qty > 50

--19. You want to retrieve data for all the orders who made order '1-12-90' having price 4000 – 6000 and sort the column in descending order on price 
 select * from Orders where orderdate = '1-12-90' and price between '4000' and  '6000'

 /**20. Display order details in following format 
Custid Price (sum of price) Count (count of qty) 
1 5000 3 
2 4000 9 
3 6700 6**/
select custid, sum(price) as [Price (sum of price)], count(qty) as [Count (count of qty)] from Orders
group by custid;

--21. Display above details only for price > 4000
select custid, sum(price) as [Price (sum of price)], count(qty) as [Count (count of qty)] from Orders
where price > 4000
group by custid

/**22. Write a query to create duplicate table of customer , and name it as 
custhistory 
a. Delete all the records of custhistory 
b. Copy records of customers to custhistory where age > 30**/
select * into custhistory from customers

delete from custhistory 

insert into custhistory select * from customers where age > 30







