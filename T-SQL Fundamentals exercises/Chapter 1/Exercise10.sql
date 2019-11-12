SELECT custid, region
FROM TSQLV4.Sales.Customers
ORDER BY CASE WHEN region IS NULL THEN '1' ELSE '0' END, 
		 region;