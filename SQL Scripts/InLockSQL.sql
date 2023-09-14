CREATE DATABASE inlock_games_db_morning;

USE inlock_games_db_morning;
USE inlock_games_db_morning_auto;

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
VALUES (NEWID(), '308E5A9B-5BE1-42BE-96EF-77B337021278','Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','2012-09-24','99'),
	   (NEWID(), 'DBA53BDC-F3CF-4EAC-9CCE-1A5ECFEF4420','Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western.','2012-09-27','120');

SELECT * FROM Game;

INSERT INTO UserType
VALUES (NEWID(), 'Comum'),(NEWID(), 'Administrador');

DELETE FROM UserType;

SELECT * FROM UserType;

INSERT INTO [User]
VALUES (NEWID(), 'A8F4CE9F-A637-49F7-8D32-A385B0CAC4C5','cliente@cliente.com','cliente'),
       (NEWID(), '6DEA218E-DFBE-4433-8DA4-B1908AD3FA64','admin@admin.com','admin');

SELECT * FROM [User];