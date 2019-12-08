USE TSQLV4;

SELECT DISTINCT C1.country
FROM Sales.Customers AS C1
WHERE country NOT IN (SELECT E.country
					  FROM HR.Employees AS E)