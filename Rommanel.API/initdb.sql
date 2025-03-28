-- Crie o banco de dados se ele não existir
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Rommanel')
BEGIN
    CREATE DATABASE Rommanel;
END;
GO

-- Use o banco de dados
USE Rommanel;
GO

-- Crie o login se ele não existir
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'rommanel')
BEGIN
    CREATE LOGIN rommanel WITH PASSWORD = 'abc!123';
END;
GO

-- Crie o usuário no banco de dados se ele não existir
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'rommanel')
BEGIN
    CREATE USER rommanel FOR LOGIN rommanel;
END;
GO

-- Conceda permissões ao usuário
ALTER ROLE db_owner ADD MEMBER rommanel; -- Dê ao usuário a função de db_owner (ou defina permissões mais granulares)
GO

USE [Rommanel]
GO

/****** Object:  Table [dbo].[Clients]    Script Date: 3/28/2025 10:40:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpfCnpj] [varchar](15) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[razaoSocial] [varchar](50) NULL,
	[inscricaoEstadual] [varchar](50) NULL,
	[isento] [bit] NULL,
	[dataNascimento] [datetime] NULL,
	[telefone] [varchar](11) NULL,
	[cep] [varchar](8) NULL,
	[endereco] [varchar](50) NULL,
	[numero] [tinyint] NULL,
	[bairro] [varchar](50) NULL,
	[cidade] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[cpfCnpj] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


