CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
    Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
    Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] DECIMAL(4,2) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	Rating DECIMAL(4,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
	VALUES
		('Alfred Hitchcock'),
		('Martin Scorsese'),
		('Federico Fellini'),
		('Steven Spielberg'),
		('Francis Ford Coppola')

INSERT INTO Genres(GenreName)
	VALUES
		('Action'),
		('Comedy'),
		('Drama'),
		('Fantasy'),
		('Thriller')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, Rating)
	VALUES
		('The Godfather', 5, 1972, 2.55, 3, 9.2),
		('Indiana Jones and the Temple of Doom', 4, 1984, 1.58, 1, 7.5),
		('La Dolce Vita', 3, 1960, 2.54, 2, 8.0),
		('Taxi Driver', 2, 1976, 1.54, 3, 8.2)

SELECT * FROM Movies
		  