USE Relations

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO	Teachers ([Name], ManagerID)
	VALUES
		('Nadya', NULL),
		('Maya', 105),
		('Ivan', 101),
		('Stoyan', 101),
		('Milena', 102),
		('Nevena', 102);
		