USE [Examination]
GO

/****** Object:  Table [dbo].[PersonReg]    Script Date: 12/14/2015 00:35:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PersonReg](
	[ID] [uniqueidentifier] NOT NULL,
	[Serial] [int] NOT NULL,
	[RegDate] [datetime] NULL,
	[PSN] [varchar](18) NOT NULL,
	[PersonName] [varchar](10) NOT NULL,
	[Sex] [varchar](2) NOT NULL,
	[Age] [varchar](5) NOT NULL,
	[Nation] [varchar](10) NOT NULL,
	[WorkType] [varchar](50) NOT NULL,
	[Avatar] [image] NOT NULL,
	[Conclusion] [varchar](100) NULL,
	[ZjDoctorID] [varchar](10) NULL,
	[ZjDoctorName] [varchar](10) NULL,
	[RegOperID] [varchar](10) NULL,
	[RegOperName] [varchar](10) NULL,
	[IsFail] [tinyint] NULL,
	[T1] [varchar](50) NULL,
	[T2] [varchar](50) NULL,
	[T3] [varchar](50) NULL,
 CONSTRAINT [PK_PersonReg] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PersonReg] ADD  CONSTRAINT [DF_PersonReg_RegDate]  DEFAULT (getdate()) FOR [RegDate]
GO


