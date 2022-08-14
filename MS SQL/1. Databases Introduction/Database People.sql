CREATE DATABASE People

USE People

CREATE TABLE People
(
    Id INT PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2048 *1024),
	Height DECIMAL(5, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(max)   
)

INSERT INTO People(Id, [Name], Gender, Birthdate)
    VALUES
	      (12344, 'Maria Ivanova', 'f', '07-30-1998'),
		  (4595064, 'Ivan Ivanov', 'm', '01-23-1994')

INSERT INTO People(Id, [Name], Height, [Weight], Gender, Birthdate)
    VALUES
	      (8348959, 'Stoyan Petrov', 182.5, 85, 'm', '04-04-1992'),
		  (43432, 'Nevena Nikolova', 165, 54, 'f', '02-24-1985')

SELECT * FROM People

CREATE TABLE Users
(
    Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 *1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL,
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
    VALUES
	      ('Ivan', '123456', '08.11.2022', 0),
		  ('Maria', '674665', '05.10.2022', 1),
		  ('Stoyan', '87543', '01.19.2022', 0),
		  ('Asen', '08754', '08.10.2022', 1),
		  ('Nevena', '00000', '06.06.2022', 0)

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07B9F03C3D]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
    VALUES
	      ('Sam', '125667', '08.11.2022', 0)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password], IsDeleted)
    VALUES
	      ('Georgi', '7896445', 0)

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)

INSERT INTO Users(Username, [Password], IsDeleted)
    VALUES
	      ('Iva', '6787898', 1)

SELECT * FROM Users