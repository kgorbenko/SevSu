USE TSQLV4;

SELECT C.custid,
	   COUNT(DISTINCT O.orderid) AS numorders,
	   SUM(OD.qty) AS totalqty
FROM Sales.Customers AS C
INNER JOIN Sales.Orders AS O
	ON C.custid = O.custid
INNER JOIN Sales.OrderDetails AS OD
	ON O.orderid = OD.orderid
WHERE C.country = 'USA'
GROUP BY C.custid
ORDER BY C.custid;