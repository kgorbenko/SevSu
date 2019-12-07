USE TSQLV4;

SELECT E.empid, N.dt
FROM HR.Employees AS E
CROSS JOIN (SELECT DATEFROMPARTS(2016, 06, n) AS dt 
			FROM dbo.Nums 
			WHERE n >= 12 AND n <= 16) AS N
ORDER BY e.empid;