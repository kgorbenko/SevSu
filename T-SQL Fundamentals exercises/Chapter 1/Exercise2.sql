SELECT orderid, orderdate, custid, empid
FROM TSQLV4.Sales.Orders
WHERE orderdate = EOMONTH(orderdate);