USE Relations

CREATE TABLE Students(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Exams(
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
);

CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
	PRIMARY KEY(StudentID, ExamID)
);	

INSERT INTO Students([Name])
	VALUES
		('Maria Petrova'),
		('Ivan Ivanov'),
		('Georgi Georgiev'),
		('Nevena Stoyanova');

INSERT INTO Exams([Name])
	VALUES
		('Oracle'),
		('C# Advanced'),
		('C# OOP'),
		('Java Advanced'),
		('Python Advanced');

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(4, 104);

SELECT * FROM StudentsExams AS se
	JOIN Students AS s ON se.StudentID = s.StudentID
	JOIN Exams AS e ON se.ExamID = e.ExamID;