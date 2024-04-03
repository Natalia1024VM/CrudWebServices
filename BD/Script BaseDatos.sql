Create Database PruebaTecnica

GO

use PruebaTecnica

GO

CREATE TABLE [dbo].[Course](
	[IdCourse] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[MessageError] [varchar](500) NULL,
	[DateCreate] [Datetime] NOT NULL,
	[UsrCreate][varchar](200) NOT null,
	[DateModify] [Datetime]  NULL,
	[Asset] [bit] NOT NULL
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	[IdCourse] ASC
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Qualification](
	[IdQualification] [int] NOT NULL,
	[Nota] [decimal](8, 2) NULL,
	[IdSubject] [int] NOT NULL,
	[MessageError] [varchar](500) NULL,
	[DateCreate] [Datetime] NOT NULL,
	[UsrCreate][varchar](200) NOT null,
	[DateModify] [Datetime] NULL,
	[Asset] [bit] NOT NULL
 CONSTRAINT [PK_IdSubject] PRIMARY KEY CLUSTERED 
(
	[IdSubject] ASC,
	[IdQualification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Qualification]  WITH CHECK ADD  CONSTRAINT [FK_Qualification_Subject] FOREIGN KEY([IdSubject])
REFERENCES [dbo].[Subject] ([IdSubject])
GO

ALTER TABLE [dbo].[Qualification] CHECK CONSTRAINT [FK_Qualification_Subject]
GO


CREATE TABLE [dbo].[Studient](
	[Name] [varchar](200) NOT NULL,
	[ID] [varchar](10) NOT NULL,
	[IdCourse] [int] NOT NULL,
	[IdQualification] [int] NOT NULL,
	[MessageError] [varchar](500) NULL,
	[DateCreate] [Datetime] NOT NULL,
	[UsrCreate][varchar](200) NOT null,
	[DateModify] [Datetime] NULL,
	[Asset] [bit] NOT NULL
 CONSTRAINT [PK_Studient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Studient]  WITH CHECK ADD  CONSTRAINT [FK_Studient_Course] FOREIGN KEY([IdCourse])
REFERENCES [dbo].[Course] ([IdCourse])
GO

ALTER TABLE [dbo].[Studient] CHECK CONSTRAINT [FK_Studient_Course]
GO

ALTER TABLE [dbo].[Studient]  WITH CHECK ADD  CONSTRAINT [FK_Studient_Qualification] FOREIGN KEY([IdQualification])
REFERENCES [dbo].[Qualification] ([IdQualification])
GO

ALTER TABLE [dbo].[Studient] CHECK CONSTRAINT [FK_Studient_Qualification]
GO


CREATE TABLE [dbo].[Subject](
	[IdSubject] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Teacher] [varchar](200) NOT NULL,
	[MessageError] [varchar](500) NULL,
	[DateCreate] [Datetime] NOT NULL,
	[UsrCreate][varchar](200) NOT null,
	[DateModify] [Datetime] NULL,
	[Asset] [bit] NOT NULL
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[IdSubject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



INSERT INTO Course values(1, 'Septimo', '', GETDATE(), 'ADMI',null, 1)
INSERT INTO Course values(2, 'Noveno', '', GETDATE(), 'ADMI',null, 1)

GO

INSERT INTO Subject Values(1, 'Matematicas', 'Luis Perez','', GETDATE(), 'ADMI',null, 1)
INSERT INTO Subject Values(2, 'Español', 'Maria Ruiz','', GETDATE(), 'ADMI',null, 1)

GO
INSERT INTO Qualification values(1, 4.2, 1,'', GETDATE(), 'ADMI',null, 1)
INSERT INTO Qualification values(1, 4.6, 2,'', GETDATE(), 'ADMI',null, 1)
INSERT INTO Qualification values(2, 4.0, 1,'', GETDATE(), 'ADMI',null, 1)
INSERT INTO Qualification values(2, 3.9, 2,'', GETDATE(), 'ADMI',null, 1)

GO

INSERT INTO Studient Values('Natalia Velasquez', '1024584360', 1, 1,'', GETDATE(), 'ADMI',null, 1)
INSERT INTO Studient Values('Andres Serrato', '123456', 1, 2,'', GETDATE(), 'ADMI',null, 1)

GO


select * from Course
select * from Subject
select * from Qualification
select * from Studient


--drop table Course
--drop table Subject
--drop table Qualification
--drop table Studient
