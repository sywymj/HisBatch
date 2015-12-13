USE [Examination]
GO

/****** Object:  Table [dbo].[QualifiedSign]    Script Date: 12/14/2015 00:33:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QualifiedSign](
	[ID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[Serail] [int] NOT NULL,
	[Year] [varchar](4) NOT NULL,
	[SignDate] [datetime] NULL,
	[SignOperID] [int] NULL,
	[SignOperName] [varchar](20) NULL,
	[IsFail] [tinyint] NOT NULL,
	[SignNumber] [varchar](32) NOT NULL,
	[ExpireDate] [datetime] NULL,
	[T1] [varchar](50) NULL,
	[T2] [varchar](50) NULL,
	[T3] [varchar](50) NULL,
 CONSTRAINT [PK_QualifiedSign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[QualifiedSign]  WITH CHECK ADD  CONSTRAINT [FK_QualifiedSign_PersonReg] FOREIGN KEY([PersonID])
REFERENCES [dbo].[PersonReg] ([ID])
GO

ALTER TABLE [dbo].[QualifiedSign] CHECK CONSTRAINT [FK_QualifiedSign_PersonReg]
GO

ALTER TABLE [dbo].[QualifiedSign] ADD  CONSTRAINT [DF_QualifiedSign_SignDate]  DEFAULT (getdate()) FOR [SignDate]
GO


