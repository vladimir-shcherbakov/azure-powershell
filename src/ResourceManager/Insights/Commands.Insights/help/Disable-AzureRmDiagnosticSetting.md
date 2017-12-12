---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 60B497F6-98A2-4C60-B142-FF5CD123362D
online version: 
schema: 2.0.0
---

# Disable-AzureRmDiagnosticSetting

## SYNOPSIS
Disables an existing diagnostic setting from a resource.

## SYNTAX

```
Disable-AzureRmDiagnosticSetting [-ResourceId] <String> [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Disable-AzureRmDiagnosticSetting** cmdlet disables an existing diagnostic settings from the specified resource.

## EXAMPLES

### Example 1: Disables an existing named diagnosticSettings from a resource.
```
PS C:\>Disable-AzureRmDiagnosticSetting -ResourceId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/ResourceGroups/ContosoRG/providers/microsoft.keyvault/KeyVaults/ContosoKeyVault" -Name mysetting

This command disables the diagnostic setting called 'mysetting' from a key vault 'ContosoKeyVault'

## PARAMETERS

### -ResourceId
Specifies the resource ID of the resource from which the diagnostic setting will be disabled.

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
Specifies the name of the setting.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Disable-AzureRmDiagnosticSetting](./Disable-AzureRmDiagnosticSetting.md)


