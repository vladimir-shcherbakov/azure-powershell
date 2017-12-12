---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: B5F2388E-0136-4F8A-8577-67CE2A45671E
online version: 
schema: 2.0.0
---

# Add-AzureRmDiagnosticSetting

## SYNOPSIS
Adds diagnostic settings that specify how monitoring data about azure resources is routed to data destinations. 

## SYNTAX

```
Add-AzureRmDiagnosticSetting -ResourceId <String> -Name <String> 
 [-StorageAccountId <String>] 
 [-EventHubAuthorizationRuleId <String>]
 [-EventHubName <String>]
 [-WorkspaceId <String>]
 [-LogCategory <System.Collections.Generic.List`1[System.String]>]
 [-MetricCategory <System.Collections.Generic.List`1[System.String]>]
 [-RetentionInDays <Int32>]  
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmDiagnosticSetting** cmdlet allows routing logs and metrics from azure resources to supported data destinations.

The list of supported data destinations is:

- Azure Storage Account
- Azure Event Hubs
- Azure Analytics Workspace

## EXAMPLES

### Example 1: Route all metrics and logs for a resource to the specified storage account
```
PS C:\>Add-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.logic/workspaces/mylogicapp -Name mysetting -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.storage/storageaccounts/myaccount
```

This command routes all metrics and logs from logic app 'mylogicapp' to storage account 'myaccount'

### Example 2: Selecting the metric and log categories
```
PS C:\>Add-AzureRmDiagnosticSetting -ResourceId <resourceId> -Name mysetting -LogCategory LogCategory1,LogCategory2 -MetricCategory MetricCategory1
StorageAccountId   : <storageAccountId>
EventHubAuthorizationRuleId : 
EventHubName: 
WorkspaceId : 
Metrics
Enabled   : True
Timegrain : PT1M
Category  : MetricCategory1
Enabled   : False
Timegrain : PT1M
Category  : MetricCategory2
Logs
Enabled  : True
Category : LogCategory1
Enabled  : True
Category : LogCategory2
Enabled  : False
Category : LogCategory3
Enabled  : False
Category : LogCategory4
```

This command enables LogCategory1, LogCategory2 and MetricCategory1 only.

### Example 3: Selecting a particular eventhub
```
PS C:\>Add-AzureRmDiagnosticSetting -ResourceId <resourceId> -Name mysetting -EventHubAuthorizationRuleId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.eventhub/namespaces/mynamespace -EventHubName myeventhub
EventHubAuthorizationRuleId : /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.eventhub/namespaces/mynamespace
EventHubName: myeventhub
WorkspaceId : 
Metrics
Enabled   : True
Timegrain : PT1M
Category  : MetricCategory1
Logs
Enabled  : True
Category : LogCategory1
```

This command specifies a particular event hub to be used. If event hub name is not included, an event hub will be created for each category of metric and log data.

## PARAMETERS

### -Categories
Deprecated. Use LogCategories instead.

This parameter is being replaced by LogCategories.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LogCategory
Specifies the list of log categories to be routed.
If no LogCategories are specified, Categories is used instead. If neither Categories or LogCategories
are specified, the command assumes all categories.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MetricCategory
Specifies the list of metric categories to be routed.
If no MetricCategories are specified, the command assumes all categories.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Specifies the ID of the resource from which data will be routed.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the unique name of the setting.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionEnabled
Indicates whether a retention policy is applied to the data stored in a storage account for the specified categories.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionInDays
Specifies the retention policy, in days, for the specified categories.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventHubAuthorizationRuleId
Resource ID of the event hub namespace authorization rule from the event hub namespace that will be used as the data destination.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventHubName
Name of the event hub to which data will be sent within the event hub namespace. If none is specified, an event hub is created for each category of log and metric data.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountId
Specifies the resource ID of the storage account in which the data is saved.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Timegrains
Deprecated. Use MetricCategories instead.

Specifies the time grains to enable or disable for metrics, according to the value of *Enabled*.
If you do not specify a time grain, this command operates on all available time grains.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceId
The Azure resource ID of the Log Analytics workspace to which data should be sent.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmDiagnosticSetting](./Get-AzureRmDiagnosticSetting.md)


