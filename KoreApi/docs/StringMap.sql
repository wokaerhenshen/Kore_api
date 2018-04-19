USE [KORE_Interactive_MSCRM]
GO

/****** Object:  Table [dbo].[StringMap]    Script Date: 4/16/2018 10:08:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StringMap](
	[ObjectTypeCode] [int] NOT NULL,
	[AttributeName] [nvarchar](100) NOT NULL,
	[AttributeValue] [int] NOT NULL,
	[LangId] [int] NOT NULL,
	[OrganizationId] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](255) NULL,
	[DisplayOrder] [int] NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[VersionNumber] [timestamp] NULL,
	[StringMapId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [cndx_PrimaryKey_StringMap] PRIMARY KEY CLUSTERED 
(
	[StringMapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY],
 CONSTRAINT [UQ_StringMap] UNIQUE NONCLUSTERED 
(
	[ObjectTypeCode] ASC,
	[AttributeName] ASC,
	[AttributeValue] ASC,
	[LangId] ASC,
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StringMap] ADD  DEFAULT (newid()) FOR [rowguid]
GO

ALTER TABLE [dbo].[StringMap] ADD  CONSTRAINT [DF_StringMap_StringMapId]  DEFAULT (newid()) FOR [StringMapId]
GO

ALTER TABLE [dbo].[StringMap]  WITH NOCHECK ADD  CONSTRAINT [organization_string_maps] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[OrganizationBase] ([OrganizationId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[StringMap] CHECK CONSTRAINT [organization_string_maps]
GO


