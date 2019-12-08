USE TSQLV4;

SELECT E.empid, E.firstname, E.lastname
FROM HR.Employees AS E
WHERE NOT EXISTS (SELECT *
				  FROM Sales.Orders AS O
				  WHERE empid = E.empid AND
						orderdate >= '20160501')