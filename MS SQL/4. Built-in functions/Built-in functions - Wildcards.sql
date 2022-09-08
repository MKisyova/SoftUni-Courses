USE SoftUni

SELECT * FROM Employees
	WHERE JobTitle NOT LIKE 'Intern';

SELECT * FROM Employees
	WHERE LEN(LastName) IN (6,7)
	ORDER BY LastName, FirstName;

SELECT * FROM Employees
	WHERE FirstName LIKE '%[PM]%';

SELECT * FROM Employees
	WHERE FirstName LIKE '[^PM]%'
	ORDER BY FirstName;

SELECT * FROM Employees
	WHERE LastName LIKE '%v%v%'
	ORDER BY FirstName, LastName;

SELECT * FROM Employees
	WHERE MiddleName LIKE '%e_r_v%'
	ORDER BY FirstName, MiddleName, LastName;