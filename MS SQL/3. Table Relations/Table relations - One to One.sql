CREATE DATABASE Relations

USE Relations

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8) NOT NULL,
)

CREATE TABLE Persons(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL
)

INSERT INTO Passports( PassportID, PassportNumber)
	VALUES
		(101, 'H67IG57T'),
		(102, 'O89DV09K'),
		(103, 'U67DC48O')

INSERT INTO Persons (FirstName, Salary, PassportID)
	VALUES
		('Roberto', 43300.00, 102),
		('Tom', 56000.00, 103),
		('Yana', 62200.00, 101)