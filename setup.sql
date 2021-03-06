create database BlackBallArchitecture
go

USE [BlackBallArchitecture]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 08/08/2014 10:19:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[IsSuperAdmin] [bit] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[PasswordEncrypted] [varchar](500) NULL,
	[Email] [varchar](100) NOT NULL,
	[PostalAddress] [varchar](500) NULL,
	[Phone] [varchar](30) NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[SystemLog](
	[SystemLogID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[WhenOccurred] [datetime] NOT NULL,
	[Message] [varchar](8000) NOT NULL,
	[Details] [text] NULL,
	[SystemLogTypeID] [int] NOT NULL,
 CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED 
(
	[SystemLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SystemLog]  WITH CHECK ADD  CONSTRAINT [FK_SystemLog_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[SystemLog] CHECK CONSTRAINT [FK_SystemLog_Person]
GO


