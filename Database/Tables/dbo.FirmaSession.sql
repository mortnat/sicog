SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaSession](
	[FirmaSessionID] [int] IDENTITY(1,1) NOT NULL,
	[FirmaSessionGuid] [uniqueidentifier] NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonID] [int] NULL,
	[OriginalPersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FirmaSession_FirmaSessionID] PRIMARY KEY CLUSTERED 
(
	[FirmaSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_FirmaSession_FirmaSessionGuid] UNIQUE NONCLUSTERED 
(
	[FirmaSessionGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FirmaSession]  WITH CHECK ADD  CONSTRAINT [FK_FirmaSession_OrignalPerson_OriginalPersonID] FOREIGN KEY([OriginalPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[FirmaSession] CHECK CONSTRAINT [FK_FirmaSession_OrignalPerson_OriginalPersonID]
GO
ALTER TABLE [dbo].[FirmaSession]  WITH CHECK ADD  CONSTRAINT [FK_FirmaSession_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[FirmaSession] CHECK CONSTRAINT [FK_FirmaSession_Person_PersonID]
GO
ALTER TABLE [dbo].[FirmaSession]  WITH CHECK ADD  CONSTRAINT [FK_FirmaSession_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FirmaSession] CHECK CONSTRAINT [FK_FirmaSession_Tenant_TenantID]