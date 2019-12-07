USE TSQLV4;

SELECT E.empid,
	   E.firstname,
	   E.lastname,
	   N.n
FROM HR.Employees AS E 
CROSS JOIN (SELECT n 
			FROM dbo.Nums 
			WHERE n <= 5) AS N;