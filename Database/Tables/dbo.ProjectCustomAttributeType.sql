SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeType](
	[ProjectCustomAttributeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectCustomAttributeTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectCustomAttributeDataTypeID] [int] NOT NULL,
	[MeasurementUnitTypeID] [int] NULL,
	[IsRequired] [bit] NOT NULL,
	[ProjectCustomAttributeTypeDescription] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectCustomAttributeTypeOptionsSchema] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsViewableOnFactSheet] [bit] NOT NULL,
	[ProjectCustomAttributeGroupID] [int] NOT NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeType_ProjectCustomAttributeTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID] FOREIGN KEY([MeasurementUnitTypeID])
REFERENCES [dbo].[MeasurementUnitType] ([MeasurementUnitTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType] CHECK CONSTRAINT [FK_ProjectCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeType_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID] FOREIGN KEY([ProjectCustomAttributeDataTypeID])
REFERENCES [dbo].[ProjectCustomAttributeDataType] ([ProjectCustomAttributeDataTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType] CHECK CONSTRAINT [FK_ProjectCustomAttributeType_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID] FOREIGN KEY([ProjectCustomAttributeGroupID])
REFERENCES [dbo].[ProjectCustomAttributeGroup] ([ProjectCustomAttributeGroupID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType] CHECK CONSTRAINT [FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID] FOREIGN KEY([ProjectCustomAttributeGroupID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeGroup] ([ProjectCustomAttributeGroupID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType] CHECK CONSTRAINT [FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType] CHECK CONSTRAINT [FK_ProjectCustomAttributeType_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [CK_ProjectCustomAttributeType_PickListTypeOptionSchemaNotNull] CHECK  ((NOT ([ProjectCustomAttributeDataTypeID]=(6) OR [ProjectCustomAttributeDataTypeID]=(5)) AND [ProjectCustomAttributeTypeOptionsSchema] IS NULL OR ([ProjectCustomAttributeDataTypeID]=(6) OR [ProjectCustomAttributeDataTypeID]=(5)) AND [ProjectCustomAttributeTypeOptionsSchema] IS NOT NULL))
GO
ALTER TABLE [dbo].[ProjectCustomAttributeType] CHECK CONSTRAINT [CK_ProjectCustomAttributeType_PickListTypeOptionSchemaNotNull]