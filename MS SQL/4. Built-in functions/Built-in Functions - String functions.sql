USE SoftUni

SELECT * FROM Employees
	WHERE SUBSTRING(FirstName, 1, 2) = 'Pe';

SELECT * FROM Employees
	WHERE LastName LIKE '%va%';

SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) FROM Employees;
	
SELECT REPLACE([FirstName], 'Ivan', 'Ivancho') FROM Employees;

SELECT LEFT(FirstName, 2), LastName FROM Employees;

SELECT REVERSE([FirstName]), LastName FROM Employees;
