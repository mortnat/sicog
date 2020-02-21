﻿--begin tran


CREATE TABLE [dbo].[ProjectCategory](
	[ProjectCategoryID] [int] NOT NULL,
	[ProjectCategoryName] [varchar](100) NOT NULL,
	[ProjectCategoryDisplayName] [varchar](100) NOT NULL
 
 
 CONSTRAINT [PK_ProjectCategory_ProjectCategoryID] PRIMARY KEY CLUSTERED 
(
	[ProjectCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 
 
 CONSTRAINT [AK_ProjectCategory_ProjectCategoryDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectCategoryDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 
 
 CONSTRAINT [AK_ProjectCategory_ProjectCategoryName] UNIQUE NONCLUSTERED 
(
	[ProjectCategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert dbo.ProjectCategory (ProjectCategoryID, ProjectCategoryName, ProjectCategoryDisplayName) values 
(1, 'Normal', 'Normal'),
(2, 'Administrative', 'Administrative')
GO


--rollback tran