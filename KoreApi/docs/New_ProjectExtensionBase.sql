USE [KORE_Interactive_MSCRM]
GO

/****** Object:  Table [dbo].[New_ProjectExtensionBase]    Script Date: 4/16/2018 9:57:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[New_ProjectExtensionBase](
	[New_ProjectId] [uniqueidentifier] NOT NULL,
	[New_name] [nvarchar](100) NULL,
	[New_Description] [nvarchar](max) NULL,
	[New_AccountId] [uniqueidentifier] NULL,
	[New_FullNameofProject] [nvarchar](100) NULL,
	[New_StartDate] [datetime] NULL,
	[New_EndDate] [datetime] NULL,
	[New_BudgetType] [int] NULL,
	[New_BillingSchedule] [int] NULL,
	[New_StatusRemarks] [nvarchar](max) NULL,
	[New_ProjectNo] [int] NULL,
	[New_BudgetVariance] [float] NULL,
	[New_BudgettedHours] [float] NULL,
	[New_ProjectTypeId] [uniqueidentifier] NULL,
	[New_ProjectManager] [int] NULL,
	[New_SystemModules] [nvarchar](max) NULL,
	[New_UnderReleaseMgmt] [bit] NULL,
	[New_issuehours] [float] NULL,
	[New_warrantyhours] [float] NULL,
	[New_workhours] [float] NULL,
	[New_changerequesthours] [float] NULL,
	[New_ActualChangeRequestHours] [float] NULL,
	[New_ActualWarrantyHours] [float] NULL,
	[New_ActualWorkHours] [float] NULL,
	[New_ActualHours] [float] NULL,
	[New_commissionable] [bit] NULL,
	[New_RateOveride] [money] NULL,
	[new_rateoveride_Base] [money] NULL,
	[New_rateoveride_use] [decimal](23, 10) NULL,
	[New_TenroxStatus] [nvarchar](500) NULL,
	[New_BillingRemarks] [nvarchar](max) NULL,
	[New_PSSAccountId] [uniqueidentifier] NULL,
	[New_ProjectPhase] [int] NULL,
 CONSTRAINT [PK_New_ProjectExtensionBase] PRIMARY KEY CLUSTERED 
(
	[New_ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[New_ProjectExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [Account_New_Projects] FOREIGN KEY([New_AccountId])
REFERENCES [dbo].[AccountBase] ([AccountId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ProjectExtensionBase] CHECK CONSTRAINT [Account_New_Projects]
GO

ALTER TABLE [dbo].[New_ProjectExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [New_ProjectType_New_Projects] FOREIGN KEY([New_ProjectTypeId])
REFERENCES [dbo].[New_ProjectTypeBase] ([New_ProjectTypeId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ProjectExtensionBase] CHECK CONSTRAINT [New_ProjectType_New_Projects]
GO

ALTER TABLE [dbo].[New_ProjectExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [new_pssaccount_new_project] FOREIGN KEY([New_PSSAccountId])
REFERENCES [dbo].[AccountBase] ([AccountId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ProjectExtensionBase] CHECK CONSTRAINT [new_pssaccount_new_project]
GO


