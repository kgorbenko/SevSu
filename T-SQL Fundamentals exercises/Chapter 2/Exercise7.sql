SELECT TOP(3) shipcountry, AVG(freight) AS avgfreight
FROM TSQLV4.Sales.Orders
WHERE orderdate >= '20150101' AND orderdate < '20160101'
GROUP BY shipcountry
ORDER BY avgfreight DESC;