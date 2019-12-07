SELECT custid,
	   orderdate,
	   orderid,
	   ROW_NUMBER() OVER (PARTITION BY custid ORDER BY orderdate)
FROM TSQLV4.Sales.Orders
ORDER BY custid;