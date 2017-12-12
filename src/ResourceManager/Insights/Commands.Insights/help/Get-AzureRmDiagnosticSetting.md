---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 60B497F6-98A2-4C60-B142-FF5CD123362D
online version: 
schema: 2.0.0
---

# Get-AzureRmDiagnosticSetting

## SYNOPSIS
Gets the diagnostic settings that specify how monitoring data about azure resources is routed to data destinations. 

## SYNTAX

```
Get-AzureRmDiagnosticSetting [-ResourceId] <String> [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDiagnosticSetting** cmdlet gets the diagnostic settings for the specified resource.

Diagnostic settings set how the monitoring data from a resource is routed to different supported data destinations.

The list of supported data destinations is:

- Azure Storage Account
- Azure Event Hubs
- Azure Analytics Workspace

## EXAMPLES

### Example 1: Get a named diagnosticSettings for a resource
```
PS C:\>Get-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.keyvault/KeyVaults/ContosoKeyVault -Name mysetting

Name: mysetting
StorageAccountId   : /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.storage/accounts/ContosoStorageAccount
Metrics

Logs
Enabled  : True
Category : AuditEvent
```

This command shows that the log and metric categories from an Azure Key Vault named ContosoKeyVault are routed to storage account named ContosoStorageAccount.

### Example 2: List all existing diagnosticSettings for a resource.
```
PS C:\>Get-AzureRmDiagnosticSetting -ResourceId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.automation/automationaccounts/myresource"

Name: mysetting1
StorageAccountId   : /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.storage/accounts/ContosoStorageAccount1
Metrics

Logs
Enabled  : True
Category : JobLogs

Name: mysetting2
WorkspaceId   : /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.operationalinsights/workspaces/myworkspace
Metrics

Logs
Enabled  : True
Category : JobStreams
```

This command shows two diagnostic settings mysetting1 and mysetting2. The setting mysetting1 routes JobLogs to storage account and 
mysetting2 routes JobStreams to an oms workspace.

## PARAMETERS

### -ResourceId
Specifies the ID of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the setting. If no name is specified, the result is a list of all diagnostic settings for the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: service
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSServiceDiagnosticSettings

## NOTES

## RELATED LINKS

[Get-AzureRmDiagnosticSetting](./Get-AzureRmDiagnosticSetting.md)


