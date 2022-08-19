USE SoftUni

SELECT (FirstName + ' ' + LastName) AS FullName,Salary FROM Employees 

SELECT (FirstName + '.' + LastName + '@softuni.bg') AS FullEmailAddress FROM Employees

SELECT DISTINCT Salary FROM Employees

SELECT * FROM Employees
	WHERE JobTitle = 'Intern'

SELECT FirstName, LastName, JobTitle FROM Employees
	WHERE Salary >= 1000 AND Salary <= 3000

SELECT CONCAT(FirstName, ' ', LastName) AS FullName,Salary FROM Employees
	WHERE Salary = 4235.00 OR Salary = 4840.00	

SELECT CONCAT(FirstName, ' ', LastName) AS FullName,Salary FROM Employees
	WHERE Salary IN (1936.00, 1694.00)	

SELECT FirstName,LastName FROM Employees
	WHERE AddressId IS NULL

SELECT FirstName,LastName FROM Employees
	WHERE AddressId IS NOT NULL

SELECT FirstName,LastName,Salary FROM Employees
	WHERE Salary >= 2000
	ORDER BY Salary DESC

SELECT TOP(3) FirstName, LastName, JobTitle,Salary FROM Employees
	WHERE SALARY >= 5000
	ORDER BY Salary DESC

SELECT FirstName,LastName, JobTitle FROM Employees
	WHERE DepartmentId != 5 

SELECT * FROM Employees
	ORDER BY Salary DESC,
			 FirstName,
			 LastName,
			 MiddleName

CREATE VIEW V_EmployeesSalaries AS
	SELECT FirstName, LastName, Salary FROM Employees

SELECT * FROM V_EmployeesSalaries

CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS FullName, JobTitle FROM Employees

SELECT * FROM V_EmployeeNameJobTitle

SELECT FirstName, LastName, Salary FROM Employees
	ORDER BY Salary DESC
	OFFSET 2 ROWS
	FETCH NEXT 2 ROWS ONLY

SELECT SUM(Salary) AS SalarySum
	FROM (SELECT TOP(3) Salary FROM Employees
	ORDER BY Salary DESC)
	AS	TopThreeSalaries

SELECT TOP(3) * FROM Employees
ORDER BY HireDate ASC, FirstName ASC, LastName ASC

UPDATE Employees
	SET Salary += Salary * 0.5
	WHERE JobTitle IN ('CEO', '.NET Developer', 'Senior Engineer')

SELECT FirstName, LastName, HireDate,
	CASE
		WHEN YEAR(HireDate) < 2020 THEN 2
		ELSE 0
	END AS ExtraPaidLeaveDays
FROM Employees
