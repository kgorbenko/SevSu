SELECT empid, firstname, lastname, titleofcourtesy,
CASE
	WHEN titleofcourtesy LIKE N'Mr.%' THEN N'Male'
	WHEN titleofcourtesy LIKE N'Ms.%' OR titleofcourtesy LIKE N'Mrs.%' THEN N'Female'
	ELSE N'Unknown'
END AS gender
FROM TSQLV4.HR.Employees;