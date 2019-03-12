  Insert Into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
  Values
  (273, N'OrganizationTypeAbbreviation', N'Abbreviation', N'Not used anywhere right now, but we have used these in the past for certain visualizations where real estate is limited. Must be unique.'),
  (274, N'LegendColor', N'Legend Color', N'Hex Color. Used in charts and other visuals'),
  (275, N'ShowOnProjectMaps', N'Show On Map?', N'For maps that display layers for organizations, this setting determines whether geometries (e.g. boundaries) for that organization type should be visible by default when the map is loaded. If this setting is true (=1) AND if organizations of this type have spatial boundaries defined, then those boundaries will be shown when the map is loaded. Otherwise, the user can access the layer selector on the map (when available) to manaully turn on organization layers. For example, the small homepage map and overall Project Map use this setting to determine which organizations'' boundaries to display (for example, in the RCD Project Tracker, only organizations with the type "RCD" are displayed on these maps).'),
  (276, N'IsDefaultOrganizationType', N'Is Default?', N'Organizations that are automatically added to the list when a new user logs in must be given an Organization Type. This field identifies which Org Type to use as the default. Only one Org Type can be the default (e.g. IsDefaultOrganizationType=1 for only one)'),
  (277, N'IsFundingType', N'Is Funding Type?', N'Only used by the Accomplishment Dashboard, to exclude organizations that do not participate in funding from the dashboard display. (For example, the CA RCD Tracker has OrgType "Senate District" yet they don''t provide funding and therefore we don''t want all the individual Senate Districts to show up in the Organization selection dropdown menu; therefore IsFundingType = 0 (false) for OrgType = SenateDistrict).')

  Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
  Select TenantID, 273, N'Not used anywhere right now, but we have used these in the past for certain visualizations where real estate is limited. Must be unique.', N'' From dbo.Tenant 

  Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
  Select TenantID, 274, N'Hex Color. Used in charts and other visuals', N'' From dbo.Tenant

  Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
  Select TenantID, 275, N'For maps that display layers for organizations, this setting determines whether geometries (e.g. boundaries) for that organization type should be visible by default when the map is loaded. If this setting is true (=1) AND if organizations of this type have spatial boundaries defined, then those boundaries will be shown when the map is loaded. Otherwise, the user can access the layer selector on the map (when available) to manaully turn on organization layers. For example, the small homepage map and overall Project Map use this setting to determine which organizations'' boundaries to display (for example, in the RCD Project Tracker, only organizations with the type "RCD" are displayed on these maps).', N'' From dbo.Tenant

  Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
  Select TenantID, 276, N'Organizations that are automatically added to the list when a new user logs in must be given an Organization Type. This field identifies which Org Type to use as the default. Only one Org Type can be the default (e.g. IsDefaultOrganizationType=1 for only one)', N'' From dbo.Tenant

  Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
  Select TenantID, 277, N'Only used by the Accomplishment Dashboard, to exclude organizations that do not participate in funding from the dashboard display. (For example, the CA RCD Tracker has OrgType "Senate District" yet they don''t provide funding and therefore we don''t want all the individual Senate Districts to show up in the Organization selection dropdown menu; therefore IsFundingType = 0 (false) for OrgType = SenateDistrict).', N'' From dbo.Tenant
