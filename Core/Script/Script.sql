USE [master]
GO

CREATE DATABASE [DB_GTI]
GO

USE [DB_GTI]
GO

--TABELAS
CREATE TABLE ENDERECO_CLIENTE (
    CD_ENDERECO_CLIENTE INT NOT NULL IDENTITY,
    CEP VARCHAR(10) NOT NULL,
    LOGRADOURO VARCHAR(100) NOT NULL,
    NUMERO VARCHAR(5) NOT NULL,
    COMPLEMENTO VARCHAR(70) NULL,
    BAIRRO VARCHAR(50) NOT NULL,
    CIDADE VARCHAR(50) NOT NULL,
    UF VARCHAR(5) NOT NULL,
    PRIMARY KEY (CD_ENDERECO_CLIENTE)
)

CREATE TABLE CLIENTE (
    CD_CLIENTE INT NOT NULL IDENTITY,
    CPF VARCHAR(11) NOT NULL,
    NOME VARCHAR(150) NOT NULL,
    RG VARCHAR(10) NULL,
    DATA_EXPEDICAO DATETIME NULL,
	ORGAO_EXPEDICAO VARCHAR(30) NULL,
    UF VARCHAR(5) NULL,
    DATA_NASCIMENTO DATETIME NOT NULL,
    SEXO VARCHAR(15) NOT NULL,
    ESTADO_CIVIL VARCHAR(10) NOT NULL,
    CD_ENDERECO_CLIENTE INT,
    PRIMARY KEY (CD_CLIENTE),
    FOREIGN KEY (CD_ENDERECO_CLIENTE) REFERENCES ENDERECO_CLIENTE(CD_ENDERECO_CLIENTE) 
)