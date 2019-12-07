USE TSQLV4;

SELECT C.custid,
       C.companyname,
       O.orderid,
       O.orderdate
FROM Sales.Customers AS C
LEFT OUTER JOIN Sales.Orders AS O
	ON C.custid = O.custid
WHERE O.orderdate = '20160212'
   OR O.orderid IS NULL;

-- The query is not a correct solution to exercise 7
-- because it does not return customer-order pairs with
-- order date other than 2016/02/12 as null - it filters
-- them out.