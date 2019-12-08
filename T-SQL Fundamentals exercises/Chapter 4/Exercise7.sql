USE TSQLV4;

SELECT C.custid, C.companyname
FROM Sales.Customers AS C
WHERE C.custid IN (SELECT O.custid
				   FROM Sales.Orders AS O
				   INNER JOIN Sales.OrderDetails AS OD
				       ON O.orderid = OD.orderid
				   WHERE OD.productid = 12);