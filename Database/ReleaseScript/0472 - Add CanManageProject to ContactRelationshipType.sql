alter table dbo.ContactRelationshipType add CanManageProject bit null

go

update dbo.ContactRelationshipType set CanManageProject = 0

alter table dbo.ContactRelationshipType alter column CanManageProject bit not null

-- add Field Definition and default definition
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES
(371, N'CanContactTypeManageProject', N'Can Manage the Project?')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(371, 'If yes, users of this contact type can manage the project like the primary contact.')


-- update Contact Type rich text intro
update dbo.FirmaPage set FirmaPageContent = '<p>Define and update the set of contact types you want available to projects. You can control whether each contact type is required or not. You can also control if the contact type accepts multiple values. If no, users will only be able to select one person as that contact type (e.g. "Technical Lead"). If yes, users will be to add as many people as they like as that contact type (e.g. "Scientific Advisor"). Lastly, you can also control if the contact type can manage projects like the primary contact.</p>'
 where FirmaPageTypeID = 82
update dbo.FirmaPage set FirmaPageContent = '<p>Define and update the set of contact types you want available to Near Term Actions. You can control whether each contact type is required or not. You can also control if the contact type accepts multiple values. If no, users will only be able to select one person as that contact type (e.g. "Technical Lead"). If yes, users will be to add as many people as they like as that contact type (e.g. "Scientific Advisor"). Lastly, you can also control if the contact type can manage Near Term Actions like the primary contact.</p>'
 where TenantID = 11 and  FirmaPageTypeID = 82