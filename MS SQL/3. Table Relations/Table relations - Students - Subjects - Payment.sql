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