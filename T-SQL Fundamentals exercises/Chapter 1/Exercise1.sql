SELECT orderid, orderdate, custid, empid
FROM TSQLV4.Sales.Orders
WHERE orderdate >= '20150601' AND orderdate < '20150701';