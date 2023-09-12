CREATE DATABASE inlock_games_db_morning;

USE inlock_games_db_morning;

CREATE TABLE Studio (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
);

CREATE TABLE Game (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	StudioId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Studio(Id),
	[Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(100) NOT NULL,
	ReleaseDate DATE NOT NULL,
	Price SMALLMONEY NOT NULL
);

CREATE TABLE UserType (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Title VARCHAR(100) NOT NULL
);

CREATE TABLE [User] (
	Id UNIQUEIDENTIFIER PRIMARY KEY, 
	UserTypeId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES UserType(Id),
	Email VARCHAR(100) NOT NULL,
	[Password] VARCHAR(100) NOT NULL
);

INSERT INTO Studio
VALUES (NEWID(), 'Blizzard'),(NEWID(), 'Rockstar Studios'),(NEWID(), 'Square Enix');

SELECT * FROM Studio;

INSERT INTO Game
VALUES (NEWID(), '308E5A9B-5BE1-42BE-96EF-77B337021278','Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','2012-09-24','99'),
	   (NEWID(), 'DBA53BDC-F3CF-4EAC-9CCE-1A5ECFEF4420','Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','2012-09-27','120');

SELECT * FROM Game;

INSERT INTO UserType
VALUES (NEWID(), 'Comum'),(NEWID(), 'Administrador');

SELECT * FROM UserType;

INSERT INTO [User]
VALUES (NEWID(), 'E55A7F11-F142-4588-B2E5-9A5BF723F06F','cliente@cliente.com','cliente'),
       (NEWID(), '33C6CB5C-31B2-4A58-90D2-F8B6C3684663','admin@admin.com','admin');

SELECT * FROM [User];