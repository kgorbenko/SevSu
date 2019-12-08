USE TSQLV4;

SELECT custid, orderid, orderdate, empid
FROM Sales.Orders
WHERE custid IN (SELECT custid
				 FROM Sales.Orders
				 GROUP BY custid
				 HAVING COUNT(*) = (SELECT TOP (1) COUNT(*)
									FROM Sales.Orders
									GROUP BY custid
									ORDER BY COUNT(*) DESC))