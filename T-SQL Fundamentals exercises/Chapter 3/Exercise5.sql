USE TSQLV4;

SELECT C.custid, C.companyname
FROM Sales.Customers AS C
LEFT OUTER JOIN Sales.Orders AS O
	ON C.custid = O.custid
WHERE O.orderid IS NULL;