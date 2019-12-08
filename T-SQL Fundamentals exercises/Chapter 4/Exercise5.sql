USE TSQLV4;

SELECT O1.custid, O1.orderid, O1.orderdate, O1.empid
FROM Sales.Orders AS O1
WHERE O1.orderdate = (SELECT MAX(O2.orderdate)
				   FROM Sales.Orders AS O2
				   WHERE O2.custid = O1.custid)
ORDER BY O1.custid;