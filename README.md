A continuacion dejo los script que use para implementar el modelo de datos:

CREATE DATABASE MVCCANDIDATE
USE MVCCANDIDATE

CREATE TABLE dbo.candidates (
    Idcandidate INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Surname VARCHAR(150) NOT NULL,
    Birthdate DATETIME NOT NULL,
    Email VARCHAR(250) UNIQUE NOT NULL,
    InsertDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME NULL
);

CREATE TABLE dbo.candidateexperiences (
    IdCandidateExperience INT PRIMARY KEY IDENTITY(1,1),
    IdCandidate INT NOT NULL,
    Company VARCHAR(100) NOT NULL,
    Job VARCHAR(100) NOT NULL,
    Description VARCHAR(4000) NOT NULL,
    Salary NUMERIC(8,2) NOT NULL,
    BeginDate DATETIME NOT NULL,
    EndDate DATETIME NULL,
    InsertDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME NULL,
    FOREIGN KEY (IdCandidate) REFERENCES dbo.candidates(Idcandidate)
);
