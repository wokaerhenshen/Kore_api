USE [KORE_Interactive_MSCRM]
GO

/****** Object:  Table [dbo].[New_ChangeRequestExtensionBase]    Script Date: 4/16/2018 10:00:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[New_ChangeRequestExtensionBase](
	[New_ChangeRequestId] [uniqueidentifier] NOT NULL,
	[New_name] [nvarchar](100) NULL,
	[New_ChangeTitle] [nvarchar](60) NULL,
	[New_Remarks] [nvarchar](max) NULL,
	[New_ProjectId] [uniqueidentifier] NULL,
	[New_ChangeRequestNo] [int] NULL,
	[New_DateOpened] [datetime] NULL,
	[New_CompletionDeadline] [datetime] NULL,
	[New_DateClosed] [datetime] NULL,
	[New_EstimatedHours] [float] NULL,
	[New_ChangePriority] [int] NULL,
	[New_ThisChangeis] [int] NULL,
	[New_Analyst] [nvarchar](100) NULL,
	[New_AnalysisDate] [datetime] NULL,
	[New_Disposition] [int] NULL,
	[New_Implementer] [nvarchar](100) NULL,
	[New_ImplementationDate] [datetime] NULL,
	[New_ActualHours] [int] NULL,
	[New_StatusResolutionRemark] [nvarchar](max) NULL,
	[New_SystemModule] [nvarchar](100) NULL,
	[New_ActionType] [int] NULL,
	[New_OLDGUID] [nvarchar](40) NULL,
	[New_RelatedReleaseId] [uniqueidentifier] NULL,
	[new_clientcreatorid] [uniqueidentifier] NULL,
	[New_SystemModuleDropDown] [int] NULL,
	[New_StatusLastChanged] [datetime] NULL,
	[New_totalhoursbilled] [float] NULL,
	[New_ApprovedBy] [nvarchar](100) NULL,
	[New_RequestedBy] [nvarchar](100) NULL,
	[New_NewFeature] [int] NULL,
	[New_ReportChecklist] [bit] NULL,
	[New_CRMEntityChecklist] [bit] NULL,
	[New_CRMFormDesignChecklist] [bit] NULL,
	[New_CRMViewsChecklist] [bit] NULL,
	[New_SystemDataChecklist] [bit] NULL,
	[New_UserSetupChecklist] [bit] NULL,
	[New_IssueDescription] [nvarchar](3000) NULL,
	[New_TestedBy] [nvarchar](500) NULL,
	[new_testedbyid] [uniqueidentifier] NULL,
	[New_Locked] [bit] NULL,
	[New_HideonPortal] [bit] NULL,
	[New_ClientActionRequired] [bit] NULL,
	[New_SpecialDeploymentRequirements] [nvarchar](max) NULL,
	[New_HidefromWeeklyStatus] [bit] NULL,
	[New_NextMonday] [datetime] NULL,
	[New_DebugInformation] [nvarchar](max) NULL,
	[New_EnablePMOnlyTimeslips] [bit] NULL,
	[New_TestPlan] [nvarchar](max) NULL,
	[New_FullEstimateHours] [int] NULL,
	[New_CreatePBI] [bit] NULL,
	[New_WeeklyWBITitle] [nvarchar](200) NULL,
	[New_RecurringWBITitleMonthly] [nvarchar](200) NULL,
 CONSTRAINT [PK_New_ChangeRequestExtensionBase] PRIMARY KEY CLUSTERED 
(
	[New_ChangeRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [Contact_New_ChangeRequests] FOREIGN KEY([new_clientcreatorid])
REFERENCES [dbo].[ContactBase] ([ContactId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase] CHECK CONSTRAINT [Contact_New_ChangeRequests]
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [New_Project_New_ChangeRequests] FOREIGN KEY([New_ProjectId])
REFERENCES [dbo].[New_ProjectBase] ([New_ProjectId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase] CHECK CONSTRAINT [New_Project_New_ChangeRequests]
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [New_Release_New_ChangeRequests] FOREIGN KEY([New_RelatedReleaseId])
REFERENCES [dbo].[New_ReleaseBase] ([New_ReleaseId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase] CHECK CONSTRAINT [New_Release_New_ChangeRequests]
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase]  WITH NOCHECK ADD  CONSTRAINT [new_systemuser_new_testedby] FOREIGN KEY([new_testedbyid])
REFERENCES [dbo].[SystemUserBase] ([SystemUserId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[New_ChangeRequestExtensionBase] CHECK CONSTRAINT [new_systemuser_new_testedby]
GO


