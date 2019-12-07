USE TSQLV4;

SELECT C.custid,
	   C.companyname,
	   O.orderid,
	   O.orderdate
FROM Sales.Customers AS C 
LEFT OUTER JOIN Sales.Orders AS O
	ON C.custid = O.custid;