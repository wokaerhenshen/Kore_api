USE [KORE_Interactive_MSCRM]
GO

/****** Object:  Table [dbo].[AccountBase]    Script Date: 4/16/2018 10:09:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountBase](
	[AccountId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[AccountCategoryCode] [int] NULL,
	[TerritoryId] [uniqueidentifier] NULL,
	[DefaultPriceLevelId] [uniqueidentifier] NULL,
	[CustomerSizeCode] [int] NULL,
	[PreferredContactMethodCode] [int] NULL,
	[CustomerTypeCode] [int] NULL,
	[AccountRatingCode] [int] NULL,
	[IndustryCode] [int] NULL,
	[TerritoryCode] [int] NULL,
	[AccountClassificationCode] [int] NULL,
	[DeletionStateCode] [int] NOT NULL,
	[BusinessTypeCode] [int] NULL,
	[OwningBusinessUnit] [uniqueidentifier] NULL,
	[OwningTeam] [uniqueidentifier] NULL,
	[OwningUser] [uniqueidentifier] NULL,
	[OriginatingLeadId] [uniqueidentifier] NULL,
	[PaymentTermsCode] [int] NULL,
	[ShippingMethodCode] [int] NULL,
	[PrimaryContactId] [uniqueidentifier] NULL,
	[ParticipatesInWorkflow] [bit] NULL,
	[Name] [nvarchar](160) NULL,
	[AccountNumber] [nvarchar](20) NULL,
	[Revenue] [money] NULL,
	[NumberOfEmployees] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[SIC] [nvarchar](20) NULL,
	[OwnershipCode] [int] NULL,
	[MarketCap] [money] NULL,
	[SharesOutstanding] [int] NULL,
	[TickerSymbol] [nvarchar](10) NULL,
	[StockExchange] [nvarchar](20) NULL,
	[WebSiteURL] [nvarchar](200) NULL,
	[FtpSiteURL] [nvarchar](200) NULL,
	[EMailAddress1] [nvarchar](100) NULL,
	[EMailAddress2] [nvarchar](100) NULL,
	[EMailAddress3] [nvarchar](100) NULL,
	[DoNotPhone] [bit] NULL,
	[DoNotFax] [bit] NULL,
	[Telephone1] [nvarchar](50) NULL,
	[DoNotEMail] [bit] NULL,
	[Telephone2] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Telephone3] [nvarchar](50) NULL,
	[DoNotPostalMail] [bit] NULL,
	[DoNotBulkEMail] [bit] NULL,
	[DoNotBulkPostalMail] [bit] NULL,
	[CreditLimit] [money] NULL,
	[CreditOnHold] [bit] NULL,
	[IsPrivate] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[VersionNumber] [timestamp] NULL,
	[ParentAccountId] [uniqueidentifier] NULL,
	[Aging30] [money] NULL,
	[StateCode] [int] NOT NULL,
	[Aging60] [money] NULL,
	[StatusCode] [int] NULL,
	[Aging90] [money] NULL,
	[PreferredAppointmentDayCode] [int] NULL,
	[PreferredAppointmentTimeCode] [int] NULL,
	[PreferredServiceId] [uniqueidentifier] NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Merged] [bit] NULL,
	[LastUsedInCampaign] [datetime] NULL,
	[DoNotSendMM] [bit] NULL,
	[PreferredSystemUserId] [uniqueidentifier] NULL,
	[PreferredEquipmentId] [uniqueidentifier] NULL,
	[ExchangeRate] [decimal](23, 10) NULL,
	[UTCConversionTimeZoneCode] [int] NULL,
	[OverriddenCreatedOn] [datetime] NULL,
	[TimeZoneRuleVersionNumber] [int] NULL,
	[ImportSequenceNumber] [int] NULL,
	[TransactionCurrencyId] [uniqueidentifier] NULL,
	[CreditLimit_Base] [money] NULL,
	[Aging30_Base] [money] NULL,
	[Revenue_Base] [money] NULL,
	[Aging90_Base] [money] NULL,
	[MarketCap_Base] [money] NULL,
	[Aging60_Base] [money] NULL,
	[YomiName] [nvarchar](160) NULL,
 CONSTRAINT [cndx_PrimaryKey_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [Set_To_Zero93]  DEFAULT (0) FOR [ParticipatesInWorkflow]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotPhone]  DEFAULT ((0)) FOR [DoNotPhone]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotFax]  DEFAULT ((0)) FOR [DoNotFax]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotEMail]  DEFAULT ((0)) FOR [DoNotEMail]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotPostalMail]  DEFAULT ((0)) FOR [DoNotPostalMail]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotBulkEMail]  DEFAULT ((0)) FOR [DoNotBulkEMail]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotBulkPostalMail]  DEFAULT ((0)) FOR [DoNotBulkPostalMail]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [Set_To_Zero94]  DEFAULT (0) FOR [IsPrivate]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_Merged]  DEFAULT (0) FOR [Merged]
GO

ALTER TABLE [dbo].[AccountBase] ADD  CONSTRAINT [DF_AccountBase_DoNotSendMM]  DEFAULT (0) FOR [DoNotSendMM]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [account_master_account] FOREIGN KEY([MasterId])
REFERENCES [dbo].[AccountBase] ([AccountId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [account_master_account]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [account_originating_lead] FOREIGN KEY([OriginatingLeadId])
REFERENCES [dbo].[LeadBase] ([LeadId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [account_originating_lead]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [account_parent_account] FOREIGN KEY([ParentAccountId])
REFERENCES [dbo].[AccountBase] ([AccountId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [account_parent_account]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [account_primary_contact] FOREIGN KEY([PrimaryContactId])
REFERENCES [dbo].[ContactBase] ([ContactId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [account_primary_contact]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [business_unit_accounts] FOREIGN KEY([OwningBusinessUnit])
REFERENCES [dbo].[BusinessUnitBase] ([BusinessUnitId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [business_unit_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [equipment_accounts] FOREIGN KEY([PreferredEquipmentId])
REFERENCES [dbo].[EquipmentBase] ([EquipmentId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [equipment_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [price_level_accounts] FOREIGN KEY([DefaultPriceLevelId])
REFERENCES [dbo].[PriceLevelBase] ([PriceLevelId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [price_level_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [service_accounts] FOREIGN KEY([PreferredServiceId])
REFERENCES [dbo].[ServiceBase] ([ServiceId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [service_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [system_user_accounts] FOREIGN KEY([PreferredSystemUserId])
REFERENCES [dbo].[SystemUserBase] ([SystemUserId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [system_user_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [team_accounts] FOREIGN KEY([OwningTeam])
REFERENCES [dbo].[TeamBase] ([TeamId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [team_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [territory_accounts] FOREIGN KEY([TerritoryId])
REFERENCES [dbo].[TerritoryBase] ([TerritoryId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [territory_accounts]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [transactioncurrency_account] FOREIGN KEY([TransactionCurrencyId])
REFERENCES [dbo].[TransactionCurrencyBase] ([TransactionCurrencyId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [transactioncurrency_account]
GO

ALTER TABLE [dbo].[AccountBase]  WITH NOCHECK ADD  CONSTRAINT [user_accounts] FOREIGN KEY([OwningUser])
REFERENCES [dbo].[SystemUserBase] ([SystemUserId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AccountBase] CHECK CONSTRAINT [user_accounts]
GO


