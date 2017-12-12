# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------


# Setup for record mode
# New-AzureRmResource -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -Location eastus

$resourceId = "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2"

$storageAccountId = "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/vmss123/providers/Microsoft.Storage/storageAccounts/qj7vz3po4dtccvmssash1sa" 
$eventHubId = "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/Default-ServiceBus-EastUS/providers/Microsoft.ServiceBus/namespaces/mdmtesting/authorizationRules/RootManageSharedAccessKey"
$eventHubName = "eventHubName"

$settingName1 = "service"
$settingName2 = "mysetting"

<#
.SYNOPSIS
Tests getting diagnostic settings
#>
function Test-GetAzureRmDiagnosticSetting
{
    try 
    {
		Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1 -StorageAccountId $storageAccountId -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName

        $actual = Get-AzureRmDiagnosticSetting -ResourceId $resourceId -name $settingName1

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
		
    }
    finally
    {
		# Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests getting diagnostic settings list
#>
function Test-GetAzureRmDiagnosticSetting-List
{
    try 
    {
		Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1 -StorageAccountId $storageAccountId
		Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName

        $actual = Get-AzureRmDiagnosticSetting -ResourceId $resourceId

		Assert-AreEqual 2                 $actual.Count
		Assert-AreEqual $settingName1     $actual[0].Name
		Assert-AreEqual $storageAccountId $actual[0].StorageAccountId
		Assert-AreEqual $null             $actual[0].ServiceBusRuleId
		Assert-AreEqual $null             $actual[0].EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual[0].EventHubName
	
		Assert-AreEqual $settingName2     $actual[1].Name
		Assert-AreEqual $null             $actual[1].StorageAccountId
		Assert-AreEqual $eventHubId       $actual[1].ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual[1].EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual[1].EventHubName

		for ($i = 1; $i -lt 2; $i++) {
			Assert-AreEqual 1                 $actual[$i].Metrics.Count 
			Assert-AreEqual $true             $actual[$i].Metrics[0].Enabled 
			Assert-AreEqual "00:01:00"        $actual[$i].Metrics[0].Timegrain 
			Assert-AreEqual "AllMetrics"      $actual[$i].Metrics[0].Category 
			Assert-AreEqual 2                 $actual[$i].Logs.Count
			Assert-AreEqual $true             $actual[$i].Logs[0].Enabled
			Assert-AreEqual "TestLog1"        $actual[$i].Logs[0].Category
			Assert-AreEqual $true             $actual[$i].Logs[1].Enabled
			Assert-AreEqual "TestLog2"        $actual[$i].Logs[1].Category
		}
    }
    finally
    {
		# Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
	    Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics
#>
function Test-SetAzureRmDiagnosticSetting
{
    try 
    {
		# Testing default setting name
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -StorageAccountId $storageAccountId -Enabled $true 

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -Enabled $true -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName

		Assert-AreEqual $settingName2     $actual.Name
		Assert-AreEqual $null             $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics with retention
#>
function Test-SetAzureRmDiagnosticSettingWithRetention
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -StorageAccountId $storageAccountId -Enabled $true -RetentionEnabled $true -RetentionInDays 90

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		Assert-AreEqual $true             $actual.Metrics[0].RetentionPolicy.Enabled 
		Assert-AreEqual 90                $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual 90                $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[1].RetentionPolicy.Enabled
		Assert-AreEqual 90                $actual.Logs[1].RetentionPolicy.Days
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics for log categories only using deprecated parameter log category
#>
function Test-SetAzureRmDiagnosticSetting-CategoriesOnly
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -StorageAccountId $storageAccountId -Enabled $true -Categories TestLog2

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $false            $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $false            $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics for time grains only
#>
function Test-SetAzureRmDiagnosticSetting-TimegrainsOnly
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -StorageAccountId $storageAccountId -Enabled $true -Timegrains PT1M

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $false            $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $false            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics for log categories only
#>
function Test-SetAzureRmDiagnosticSetting-LogCategory
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -StorageAccountId $storageAccountId -Enabled $true -Name $settingName1 -LogCategory TestLog1,TestLog2

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $false            $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		$actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -Enabled $false -Name $settingName1 -LogCategory TestLog1

		Assert-AreEqual $settingName1      $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $false            $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $false             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics for metric categories only
#>
function Test-SetAzureRmDiagnosticSetting-MetricCategory
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -StorageAccountId $storageAccountId -Enabled $true -Name $settingName1 -MetricCategory AllMetrics

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $false            $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $false            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		$actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -Enabled $false -Name $settingName1 -MetricCategory AllMetrics

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $false            $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $false            $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $false            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests setting diagnostics destinations
#>
function Test-SetAzureRmDiagnosticSetting-EnableDisableDestinations
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -StorageAccountId $storageAccountId -Enabled $true 

		Assert-AreEqual $settingName2     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		$actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName

		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName

		$actual = Set-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -StorageAccountId $null

		Assert-AreEqual $null             $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests adding diagnostics
#>
function Test-AddAzureRmDiagnosticSetting
{
    try 
    {
	    $actual = Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -StorageAccountId $storageAccountId -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName -RetentionInDays 10

		Assert-AreEqual $settingName2     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		Assert-AreEqual $true             $actual.Metrics[0].RetentionPolicy.Enabled 
		Assert-AreEqual 10                $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual 10                $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[1].RetentionPolicy.Enabled
		Assert-AreEqual 10                $actual.Logs[1].RetentionPolicy.Days
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests adding diagnostics specifying LogCategory
#>
function Test-AddAzureRmDiagnosticSetting-LogCategory
{
    try 
    {
	    $actual = Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -StorageAccountId $storageAccountId -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName -RetentionInDays 10 -LogCategory TestLog1

		Assert-AreEqual $settingName2     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $false            $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $false            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		Assert-AreEqual $false            $actual.Metrics[0].RetentionPolicy.Enabled 
		Assert-AreEqual $true             $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual 10                $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $false            $actual.Logs[1].RetentionPolicy.Enabled
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests adding diagnostics specifying MetricCategory
#>
function Test-AddAzureRmDiagnosticSetting-MetricCategory
{
    try 
    {
	    $actual = Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1 -StorageAccountId $storageAccountId -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName -RetentionInDays 10 -MetricCategory AllMetrics

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $false            $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $false            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		Assert-AreEqual $true             $actual.Metrics[0].RetentionPolicy.Enabled 
		Assert-AreEqual 10                $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual $false            $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual $false            $actual.Logs[1].RetentionPolicy.Enabled
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests adding diagnostics specifying LogCategory and MetricCategory
#>
function Test-AddAzureRmDiagnosticSetting-LogCategoryAndMetricCategory
{
    try 
    {
	    $actual = Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1 -StorageAccountId $storageAccountId -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName -RetentionInDays 10 -LogCategory TestLog1 -MetricCategory AllMetrics

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $false            $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		Assert-AreEqual $true             $actual.Metrics[0].RetentionPolicy.Enabled 
		Assert-AreEqual 10                $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual 10                $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $false            $actual.Logs[1].RetentionPolicy.Enabled
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests adding diagnostics specifying only storage
#>
function Test-AddAzureRmDiagnosticSetting-StorageOnly
{
    try 
    {
	    $actual = Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1 -StorageAccountId $storageAccountId -RetentionInDays 10 

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category

		Assert-AreEqual $true             $actual.Metrics[0].RetentionPolicy.Enabled 
		Assert-AreEqual 10                $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual 10                $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $true             $actual.Logs[1].RetentionPolicy.Enabled
		Assert-AreEqual 10                $actual.Logs[1].RetentionPolicy.Days
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests adding diagnostics specifying only eventhub
#>
function Test-AddAzureRmDiagnosticSetting-EventHubOnly
{
    try 
    {
	    $actual = Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1 -EventHubAuthorizationRuleId $eventHubId -EventHubName $eventHubName 

		Assert-AreEqual $settingName1     $actual.Name
		Assert-AreEqual $null             $actual.StorageAccountId
		Assert-AreEqual $eventHubId       $actual.ServiceBusRuleId
		Assert-AreEqual $eventHubId       $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $eventHubName     $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}

<#
.SYNOPSIS
Tests removing diagnostics
#>
function Test-RemoveAzureRmDiagnosticSetting
{
    try 
    {
		Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -StorageAccountId $storageAccountId
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
    finally
    {
        # No cleanup needed
    }
}

<#
.SYNOPSIS
Tests enabling and disabling diagnostics
#>
function Test-EnableDisableAzureRmDiagnosticSetting
{
    try 
    {
		Add-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2 -StorageAccountId $storageAccountId
		
	    Disable-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
		Enable-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2

		$actual = Get-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2

		Assert-AreEqual $settingName2     $actual.Name
		Assert-AreEqual $storageAccountId $actual.StorageAccountId
		Assert-AreEqual $null             $actual.ServiceBusRuleId
		Assert-AreEqual $null             $actual.EventHubAuthorizationRuleId
		Assert-AreEqual $null             $actual.EventHubName
		Assert-AreEqual 1                 $actual.Metrics.Count 
		Assert-AreEqual $true             $actual.Metrics[0].Enabled 
		Assert-AreEqual "00:01:00"        $actual.Metrics[0].Timegrain 
		Assert-AreEqual "AllMetrics"      $actual.Metrics[0].Category 
		Assert-AreEqual 2                 $actual.Logs.Count
		Assert-AreEqual $true             $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"        $actual.Logs[0].Category
		Assert-AreEqual $true             $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"        $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName1
		Remove-AzureRmDiagnosticSetting -ResourceId $resourceId -Name $settingName2
    }
}