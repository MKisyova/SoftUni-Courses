USE SoftUni

SELECT FirstName, LastName, Salary, 
		DENSE_RANK() 
		OVER (PARTITION BY Salary ORDER BY Id) AS [Rank]
		FROM Employees
	WHERE Salary <= 10000 
	ORDER BY Salary DESC;

SELECT FirstName, LastName, 
		LOWER(CONCAT(FirstName, SUBSTRING(LastName, 2, LEN(LastName) - 1))) AS MixedName
		FROM Employees
	WHERE RIGHT(FirstName, 1) = LEFT(LastName,1)
	ORDER BY FirstName;

SELECT FirstName, 
		ISNULL(MiddleName, '_') AS MiddleName, 
		LastName, HireDate
	FROM Employees
	WHERE JobTitle = 'Intern'
	ORDER BY HireDate;

SELECT * FROM Employees
	ORDER BY Salary DESC
	OFFSET 2 ROWS
	FETCH NEXT 1 ROWS ONLY;


	