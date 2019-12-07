SELECT empid, firstname, lastname
FROM TSQLV4.HR.Employees
WHERE LEN(lastname) - LEN(REPLACE(lastname, N'e', N'')) >= 2;