SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateProvince](
	[StateProvinceID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[StateProvinceName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StateProvinceAbbreviation] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StateProvinceFeature] [geometry] NULL,
	[StateProvinceFeatureForAnalysis] [geometry] NOT NULL,
 CONSTRAINT [PK_StateProvince_StateProvinceID] PRIMARY KEY CLUSTERED 
(
	[StateProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_StateProvince_StateProvinceAbbreviation_TenantID] UNIQUE NONCLUSTERED 
(
	[StateProvinceAbbreviation] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_StateProvince_StateProvinceID_TenantID] UNIQUE NONCLUSTERED 
(
	[StateProvinceID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_StateProvince_StateProvinceName_TenantID] UNIQUE NONCLUSTERED 
(
	[StateProvinceName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[StateProvince]  WITH CHECK ADD  CONSTRAINT [FK_StateProvince_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[StateProvince] CHECK CONSTRAINT [FK_StateProvince_Tenant_TenantID]
GO
ALTER TABLE [dbo].[StateProvince]  WITH CHECK ADD  CONSTRAINT [CK_StateProvince_StateProvinceFeature_SpatialReferenceID_Must_Be_4326] CHECK  (([StateProvinceFeature] IS NULL OR [StateProvinceFeature].[STSrid]=(4326)))
GO
ALTER TABLE [dbo].[StateProvince] CHECK CONSTRAINT [CK_StateProvince_StateProvinceFeature_SpatialReferenceID_Must_Be_4326]
GO
ALTER TABLE [dbo].[StateProvince]  WITH CHECK ADD  CONSTRAINT [CK_StateProvince_StateProvinceFeatureForAnalysis_SpatialReferenceID_Must_Be_4326] CHECK  (([StateProvinceFeatureForAnalysis] IS NULL OR [StateProvinceFeatureForAnalysis].[STSrid]=(4326)))
GO
ALTER TABLE [dbo].[StateProvince] CHECK CONSTRAINT [CK_StateProvince_StateProvinceFeatureForAnalysis_SpatialReferenceID_Must_Be_4326]