USE [KORE_Interactive_MSCRM]
GO
/****** Object:  Table [dbo].[New_ProjectTypeExtensionBase]    Script Date: 4/16/2018 10:07:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[New_ProjectTypeExtensionBase](
	[New_ProjectTypeId] [uniqueidentifier] NOT NULL,
	[New_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_New_ProjectTypeExtensionBase] PRIMARY KEY CLUSTERED 
(
	[New_ProjectTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[New_ProjectTypeExtensionBase] ([New_ProjectTypeId], [New_name]) VALUES (N'8cad98bb-b5ee-da11-953d-0013202f352d', N'.NET Programming')
GO
INSERT [dbo].[New_ProjectTypeExtensionBase] ([New_ProjectTypeId], [New_name]) VALUES (N'a6fa9622-c4ff-da11-953d-0013202f352d', N'Legacy Applications (Non-Microsoft)')
GO
INSERT [dbo].[New_ProjectTypeExtensionBase] ([New_ProjectTypeId], [New_name]) VALUES (N'5678c1a8-b5ee-da11-953d-0013202f352d', N'Microsoft CRM')
GO
INSERT [dbo].[New_ProjectTypeExtensionBase] ([New_ProjectTypeId], [New_name]) VALUES (N'7ea857a1-b5ee-da11-953d-0013202f352d', N'Microsoft Sharepoint')
GO
INSERT [dbo].[New_ProjectTypeExtensionBase] ([New_ProjectTypeId], [New_name]) VALUES (N'5778c1a8-b5ee-da11-953d-0013202f352d', N'Network Administration')
GO
INSERT [dbo].[New_ProjectTypeExtensionBase] ([New_ProjectTypeId], [New_name]) VALUES (N'2b032c65-fb65-db11-bacc-00606771c38f', N'Non-Technical')
GO
ALTER TABLE [dbo].[New_ProjectTypeExtensionBase]  WITH CHECK ADD  CONSTRAINT [FK_New_ProjectTypeExtensionBase_New_ProjectTypeBase] FOREIGN KEY([New_ProjectTypeId])
REFERENCES [dbo].[New_ProjectTypeBase] ([New_ProjectTypeId])
GO
ALTER TABLE [dbo].[New_ProjectTypeExtensionBase] CHECK CONSTRAINT [FK_New_ProjectTypeExtensionBase_New_ProjectTypeBase]
GO
