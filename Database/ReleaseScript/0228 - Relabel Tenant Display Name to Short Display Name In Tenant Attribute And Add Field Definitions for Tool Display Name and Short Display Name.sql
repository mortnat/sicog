Insert Into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition) Values 
(279, 'TenantShortDisplayName', 'Short Display Name', 'This will be displayed as the first half of the browser tab (before the |), as the page title for the Tenant Configuration Page, as the display name for the tenant in the Tenant Grid, and in confirmation messages to verify the user is altering data for the right tenant'),
(280, 'ToolDisplayName', 'Tenant Display Tool', 'This will displayed in Notification Emails sent out by the Project Firma Tool and the Page Title for the Home Page of the Website'),
(281, 'TenantSquareLogo', 'Square Logo', 'This will be used in the Email Notification of Project Updates, the subject of Scheduled Project Update Job Reminders, Backward and Forward Looking Fact Sheets, Being Displayed in Tenant Configuration Logos Card, and Editing Tenant Configuration Logos')

Insert Into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel) 
Select TenantID, 279, 'This will be displayed as the first half of the browser tab (before the |), as the page title for the Tenant Configuration Page, as the display name for the tenant in the Tenant Grid, and in confirmation messages to verify the user is altering data for the right tenant', '' From dbo.Tenant

Insert Into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel) 
Select TenantID, 280, 'This will displayed in Notification Emails sent out by the Project Firma Tool and the Page Title for the Home Page of the Website', '' From dbo.Tenant

Insert Into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel) 
Select TenantID, 281, 'This will be used in the Email Notification of Project Updates, the subject of Scheduled Project Update Job Reminders, Backward and Forward Looking Fact Sheets, Being Displayed in Tenant Configuration Logos Card, and Editing Tenant Configuration Logos', '' From dbo.Tenant

Go

Exec sp_rename 'dbo.TenantAttribute.TenantDisplayName', 'TenantShortDisplayName', 'Column'
