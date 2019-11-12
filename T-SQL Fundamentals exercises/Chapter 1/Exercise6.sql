-- Query is supposed to filter employees which have
-- orders later than the specified date.

SELECT empid, COUNT(*) AS numorders
FROM TSQLV4.Sales.Orders
GROUP BY empid
HAVING MAX(orderdate) < '20160501';

-- This query filters orders rather than employees
-- and only then groups employees so it should be
-- preferred.

SELECT empid, COUNT(*) AS numorders
FROM TSQLV4.Sales.Orders
WHERE orderdate < '20160511'
GROUP BY empid;