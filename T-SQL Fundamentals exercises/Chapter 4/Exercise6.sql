USE TSQLV4;

SELECT C.custid, C.companyname
FROM Sales.Customers AS C
WHERE EXISTS (SELECT *
			  FROM Sales.Orders AS O
			  WHERE O.custid = C.custid AND
					YEAR(orderdate) = 2015)
	  AND NOT
	  EXISTS (SELECT *
			  FROM Sales.Orders AS O
			  WHERE O.custid = C.custid AND
					YEAR(orderdate) = 2016)
ORDER BY custid;