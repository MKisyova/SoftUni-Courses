CREATE DATABASE SoftUni

USE  SoftUni

CREATE TABLE Towns
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30),
	LastName NVARCHAR(30) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
    VALUES
	      ('Sofia'),
		  ('Plovdiv'),
		  ('Varna'),
		  ('Burgas')

INSERT INTO Departments([Name])
    VALUES
	      ('Engineering'),
		  ('Sales'),
		  ('Marketing'),
		  ('Software Development'),
		  ('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
   VALUES
         ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01-02-2013', 3500.00),
		 ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '06-30-2020', 4000.00),
		 ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '01-18-2022', 1600.00),
		 ('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '12-09-2008', 7000.00),
		 ('Peter', 'Spasov', 'Dimitrov', 'Intern', 3, '01-03-2022', 1400.00 )

SELECT [Name] FROM Towns
         ORDER BY [Name]

SELECT [Name] FROM Departments
         ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
         ORDER BY Salary DESC

UPDATE Employees
   SET Salary += Salary * 0.1

