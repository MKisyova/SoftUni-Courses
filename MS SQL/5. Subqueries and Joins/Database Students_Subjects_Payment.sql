USE Relations

CREATE TABLE Majors(
	MajorID INT IDENTITY PRIMARY KEY,
	MajorName NVARCHAR(50) NOT NULL
);

CREATE TABLE Students(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID) NOT NULL
);

CREATE TABLE Subjects(
	SubjectID INT IDENTITY(101, 1) PRIMARY KEY,
	SubjectName NVARCHAR(50) NOT NULL,
);

CREATE TABLE StudentsSubjects(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL,
	PRIMARY KEY(StudentID, SubjectID)
);	

CREATE TABLE Payments(
	PaymentID INT IDENTITY(1001, 1) PRIMARY KEY,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount DECIMAL(7,2) NOT NULL,
	StudentID INT REFERENCES Students(StudentID) NOT NULL
);

INSERT INTO Majors(MajorName)
    VALUES
	      ('Ivan Ivanov'),
		  ('Ivan Georgiev'),
		  ('Maria Igantova'),
		  ('Nevena Georgieva'),
		  ('Stoyan Ivanov'),
		  ('Georgi Nikolov');

INSERT INTO Students(StudentNumber, StudentName, MajorID)
    VALUES
	      (7767, 'Ivan Stoyanov', 2),
		  (8888, 'Deni Simeonova', 1),
		  (1232, 'Maria Petrova', 1),
		  (6745, 'Lora Ivanova', 3),
		  (4935, 'Martina Lazarova', 3),
		  (7645, 'Filip Filipov',4);

INSERT INTO Subjects(SubjectName)
    VALUES
	      ('C# Basics'),
		  ('C# Fundamentals'),
		  ('C# Advanced'),
		  ('Java Basics'),
		  ('Java Fundamentals'),
		  ('Java Advanced'),
		  ('Python Basics'),
		  ('Python Fundamentals'),
		  ('Python Advanced'),
		  ('JavaScript Basics'),
		  ('JavaScript Fundamentals'),
		  ('JavaScript Advanced');

INSERT INTO Payments(PaymentDate, PaymentAmount, StudentID)
    VALUES
		  ('2022-05-15', 800.50, 1),
		  ('2022-01-10', 1400, 2),
		  ('2022-03-17', 1100.50, 3),
		  ('2022-05-05', 1850, 4);

INSERT INTO StudentsSubjects(StudentID, SubjectID)
    VALUES
		  (1, 101),
		  (1, 102),
		  (1, 103),
		  (2, 101),
		  (3, 104),
		  (4, 107),
		  (5, 112),
		  (6, 101),
		  (6, 102);
