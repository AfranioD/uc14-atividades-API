CREATE DATABASE Projeto
GO

USE Projeto
GO

CREATE TABLE Projetos (
    Id INT PRIMARY KEY IDENTITY,
    Titulo VARCHAR(150) NOT NULL,
    QuantidadePaginas INT,
    Disponivel BIT
)
GO

INSERT INTO Projetos (Titulo, QuantidadePaginas, Disponivel) 
VALUES ('Titulo A', 120, 1)
GO

INSERT INTO Projeto (Titulo, QuantidadePaginas, Disponivel) 
VALUES ('Titulo B', 220, 0)
GO

-- UPDATE Projeto SET Titulo = 'Titulo A1' Where Id = 1;

 -- DELETE FROM Projeto WHERE Id = 1;

SELECT Id, Titulo, QuantidadePaginas, Disponivel FROM Projeto
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(120) NOT NULL
)
GO

INSERT INTO Usuarios VALUES ('email@sp.br', '1234')
GO

SELECT * FROM Usuarios WHERE email = 'email@sp.br' AND senha = '1234'
GO