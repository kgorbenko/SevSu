SELECT orderid, SUM(qty * unitprice) AS totalvalue
FROM TSQLV4.Sales.OrderDetails
GROUP BY (orderid)
HAVING SUM(qty * unitprice) > 10000
ORDER BY totalvalue DESC;