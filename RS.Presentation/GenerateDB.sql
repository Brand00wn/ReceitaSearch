USE [master]
GO
/****** Object:  Database [PessoaJuridica]    Script Date: 5/18/2020 11:18:25 AM ******/
CREATE DATABASE [PessoaJuridica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PessoaJuridica', FILENAME = N'C:\Users\User\PessoaJuridica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PessoaJuridica_log', FILENAME = N'C:\Users\User\PessoaJuridica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PessoaJuridica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PessoaJuridica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PessoaJuridica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PessoaJuridica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PessoaJuridica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PessoaJuridica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PessoaJuridica] SET ARITHABORT OFF 
GO
ALTER DATABASE [PessoaJuridica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PessoaJuridica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PessoaJuridica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PessoaJuridica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PessoaJuridica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PessoaJuridica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PessoaJuridica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PessoaJuridica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PessoaJuridica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PessoaJuridica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PessoaJuridica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PessoaJuridica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PessoaJuridica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PessoaJuridica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PessoaJuridica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PessoaJuridica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PessoaJuridica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PessoaJuridica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PessoaJuridica] SET  MULTI_USER 
GO
ALTER DATABASE [PessoaJuridica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PessoaJuridica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PessoaJuridica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PessoaJuridica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PessoaJuridica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PessoaJuridica] SET QUERY_STORE = OFF
GO
USE [PessoaJuridica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PessoaJuridica]
GO
/****** Object:  Table [dbo].[Atividade]    Script Date: 5/18/2020 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atividade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](max) NULL,
	[Code] [varchar](max) NULL,
 CONSTRAINT [PK_Atividade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 5/18/2020 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UF] [varchar](max) NULL,
	[Municipio] [varchar](max) NULL,
	[Bairro] [varchar](max) NULL,
	[Logradouro] [varchar](max) NULL,
	[CEP] [varchar](max) NULL,
	[Numero] [varchar](max) NULL,
	[Complemento] [varchar](max) NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entidade]    Script Date: 5/18/2020 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[Fantasia] [varchar](max) NULL,
	[NaturezaJuridica] [varchar](max) NULL,
	[CNPJ] [varchar](max) NOT NULL,
	[Email] [varchar](max) NULL,
	[Telefone] [varchar](max) NULL,
	[Tipo] [varchar](max) NULL,
	[Porte] [varchar](max) NULL,
	[Situacao] [varchar](max) NULL,
	[DtSituacao] [datetime2](7) NULL,
	[DtAbertura] [datetime2](7) NULL,
	[EFR] [varchar](max) NULL,
	[MotivoSituacao] [varchar](max) NULL,
	[SituacaoEspecial] [varchar](max) NULL,
	[DtSituacaoEspecial] [datetime2](7) NULL,
	[DtUltimaAtualizacao] [datetime2](7) NULL,
	[CapitalSocial] [money] NOT NULL,
	[EnderecoId] [int] NOT NULL,
	[Status] [varchar](max) NULL,
	[Ativo] [bit] NULL,
 CONSTRAINT [PK_Entidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntidadeAtividadePrincipal]    Script Date: 5/18/2020 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntidadeAtividadePrincipal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtividadeId] [int] NOT NULL,
	[EntidadeId] [int] NOT NULL,
 CONSTRAINT [PK_AtividadeEntidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntidadeAtividadeSecundaria]    Script Date: 5/18/2020 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntidadeAtividadeSecundaria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtividadeId] [int] NOT NULL,
	[EntidadeId] [int] NOT NULL,
 CONSTRAINT [PK_AtividadeEntidadeSecundaria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QSA]    Script Date: 5/18/2020 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QSA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Qualificacao] [varchar](max) NULL,
	[EntidadeId] [int] NULL,
 CONSTRAINT [PK_QSA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entidade]  WITH CHECK ADD  CONSTRAINT [FK_Entidade_Endereco] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([Id])
GO
ALTER TABLE [dbo].[Entidade] CHECK CONSTRAINT [FK_Entidade_Endereco]
GO
ALTER TABLE [dbo].[EntidadeAtividadePrincipal]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeEntidade_Atividade] FOREIGN KEY([AtividadeId])
REFERENCES [dbo].[Atividade] ([Id])
GO
ALTER TABLE [dbo].[EntidadeAtividadePrincipal] CHECK CONSTRAINT [FK_AtividadeEntidade_Atividade]
GO
ALTER TABLE [dbo].[EntidadeAtividadePrincipal]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeEntidade_Entidade] FOREIGN KEY([EntidadeId])
REFERENCES [dbo].[Entidade] ([Id])
GO
ALTER TABLE [dbo].[EntidadeAtividadePrincipal] CHECK CONSTRAINT [FK_AtividadeEntidade_Entidade]
GO
ALTER TABLE [dbo].[EntidadeAtividadeSecundaria]  WITH CHECK ADD  CONSTRAINT [FK_Atividade_AP] FOREIGN KEY([AtividadeId])
REFERENCES [dbo].[Atividade] ([Id])
GO
ALTER TABLE [dbo].[EntidadeAtividadeSecundaria] CHECK CONSTRAINT [FK_Atividade_AP]
GO
ALTER TABLE [dbo].[EntidadeAtividadeSecundaria]  WITH CHECK ADD  CONSTRAINT [FK_Entidade_AP] FOREIGN KEY([EntidadeId])
REFERENCES [dbo].[Entidade] ([Id])
GO
ALTER TABLE [dbo].[EntidadeAtividadeSecundaria] CHECK CONSTRAINT [FK_Entidade_AP]
GO
ALTER TABLE [dbo].[QSA]  WITH CHECK ADD  CONSTRAINT [FK_QSA_Entidade] FOREIGN KEY([EntidadeId])
REFERENCES [dbo].[Entidade] ([Id])
GO
ALTER TABLE [dbo].[QSA] CHECK CONSTRAINT [FK_QSA_Entidade]
GO
USE [master]
GO
ALTER DATABASE [PessoaJuridica] SET  READ_WRITE 
GO
