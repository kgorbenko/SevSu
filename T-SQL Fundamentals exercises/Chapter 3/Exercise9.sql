USE TSQLV4;

SELECT DISTINCT
	   C.custid,
	   C.companyname,
	   CASE
	       WHEN O.orderdate IS NOT NULL THEN 'YES' ELSE 'NO'
	   END AS HasOrderOn20160212
FROM Sales.Customers AS C
	LEFT OUTER JOIN Sales.Orders AS O
		ON C.custid = O.custid AND
		   O.orderdate = '20160212';