USE SoftUni

SELECT TOP(2) FirstName, LastName, 
		FORMAT(HireDate, 'yyyy-MM-dd') 
		FROM Employees
	WHERE DATEPART(YEAR, HireDate) < 2022
	ORDER BY HireDate, FirstName, LastName;

SELECT FirstName, LastName, HireDate,
		DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsInCompany,
		DATEDIFF(MONTH, HireDate, GETDATE()) AS MonthsInCompany
		FROM Employees
	ORDER BY MonthsInCompany DESC;

SELECT FirstName, LastName, JobTitle,
	CASE
		WHEN YEAR(HireDate) < 2015 THEN DATEADD(MONTH, 5 ,GETDATE())
		WHEN YEAR(HireDate) >= 2015 AND YEAR(HireDate) < 2020 THEN DATEADD(MONTH, 7 ,GETDATE())
		WHEN YEAR(HireDate) >= 2020 THEN DATEADD(MONTH, 9 ,GETDATE())
	END AS ProjectFinishDate
	FROM Employees;

	