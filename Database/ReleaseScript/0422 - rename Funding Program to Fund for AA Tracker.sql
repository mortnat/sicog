update dbo.FieldDefinitionData set FieldDefinitionLabel = 'Fund' where FieldDefinitionID = 8
update dbo.FieldDefinitionData set FieldDefinitionLabel = 'Fund Custom Attribute' where FieldDefinitionID = 282
update dbo.FieldDefinitionData set FieldDefinitionLabel = 'Fund Custom Attribute Data Type' where FieldDefinitionID = 283
update dbo.FieldDefinitionData set FieldDefinitionLabel = 'Fund Custom Attribute Editable By' where FieldDefinitionID = 284
update dbo.FieldDefinitionData set FieldDefinitionLabel = 'Fund Custom Attribute Viewable By' where FieldDefinitionID = 285

update dbo.FieldDefinitionData set FieldDefinitionDataValue = 'The number of projects that have expenditures funded by this fund.' where FieldDefinitionID = 296
update dbo.FieldDefinitionData set FieldDefinitionDataValue = 'Total amount of reported expenditures funded by this fund for all NTAs' where FieldDefinitionID = 297
update dbo.FieldDefinitionData set FieldDefinitionDataValue = 'The number of NTAs that have secured funds from this fund.' where FieldDefinitionID = 298
update dbo.FieldDefinitionData set FieldDefinitionDataValue = '<p>Total amount provided by this fund&nbsp;for all NTAs.</p>' where FieldDefinitionID = 299
update dbo.FieldDefinitionData set FieldDefinitionDataValue = '<p>Total amount of funding&nbsp;NTAs plan to secure from the fund.</p>' where FieldDefinitionID = 300

update dbo.FundingSourceCustomAttributeType set FundingSourceCustomAttributeTypeName = 'Parent Fund' where FundingSourceCustomAttributeTypeID = 2 and TenantID = 11