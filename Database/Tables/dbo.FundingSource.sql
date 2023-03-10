SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSource](
	[FundingSourceID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[FundingSourceName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsActive] [bit] NOT NULL,
	[FundingSourceDescription] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundingSourceAmount] [money] NULL,
 CONSTRAINT [PK_FundingSource_FundingSourceID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_FundingSource_FundingSourceID_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingSourceID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_FundingSource_OrganizationID_FundingSourceName] UNIQUE NONCLUSTERED 
(
	[OrganizationID] ASC,
	[FundingSourceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FundingSource]  WITH CHECK ADD  CONSTRAINT [FK_FundingSource_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[FundingSource] CHECK CONSTRAINT [FK_FundingSource_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[FundingSource]  WITH CHECK ADD  CONSTRAINT [FK_FundingSource_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[FundingSource] CHECK CONSTRAINT [FK_FundingSource_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[FundingSource]  WITH CHECK ADD  CONSTRAINT [FK_FundingSource_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FundingSource] CHECK CONSTRAINT [FK_FundingSource_Tenant_TenantID]