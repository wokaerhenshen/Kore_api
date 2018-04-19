USE [KORE_Interactive_MSCRM]
GO

/****** Object:  Table [dbo].[New_TimesheetEntryExtensionBase]    Script Date: 4/16/2018 9:56:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[New_TimesheetEntryExtensionBase](
	[New_TimesheetEntryId] [uniqueidentifier] NOT NULL,
	[New_ID] [nvarchar](100) NULL,
	[New_StartTask] [datetime] NULL,
	[New_EndTask] [datetime] NULL,
	[New_Duration] [int] NULL,
	[New_EntryNo] [int] NULL,
	[New_Remarks] [nvarchar](max) NULL,
	[New_ProjectId] [uniqueidentifier] NULL,
	[New_OutofScope] [bit] NULL,
	[New_InternalRemarks] [nvarchar](max) NULL,
	[New_DurationHours] [float] NULL,
	[New_TaskType] [int] NULL,
	[New_RequestedBy] [nvarchar](50) NULL,
	[New_ChangeRequestId] [uniqueidentifier] NULL,
	[New_IssueId] [uniqueidentifier] NULL,
	[New_IsBatched] [bit] NULL,
	[New_ApprovedForBilling] [bit] NULL,
	[New_Credit] [bit] NULL,
	[new_timesheetbatchid] [uniqueidentifier] NULL,
 CONSTRAINT [PK_New_TimesheetEntryExtensionBase] PRIMARY KEY CLUSTERED 
(
	[New_TimesheetEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


