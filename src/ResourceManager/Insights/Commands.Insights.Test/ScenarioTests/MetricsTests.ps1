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

<#
.SYNOPSIS
Tests getting metrics values for a particular resource.
#>
function Test-GetMetrics
{
    # Setup
    # private const string ResourceGroupName = "Rac46PostSwapRG";
    # private const string ResourceUri = "/subscriptions/{0}/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Web/sites/alertruleTest";
	$resourceUri = '/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest'

    try 
    {
        # Test
        $actual = Get-AzureRmMetric -timeGrain 00:01:00 -ResourceId $resourceUri -StartTime 2017-08-18T21:51:07.7385445Z -EndTime 2017-08-18T22:51:07.7385445Z -Aggrega Total -MetricNames CpuTime, Requests
 
        # Assert TODO add more asserts, do not assume that the output is known
		Assert-NotNull $actual
		Assert-True { $actual.Count -gt 0 }
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting metrics definitions.
#>
function Test-GetMetricDefinitions
{
    # Setup
    $resourceUri = '/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest'

    try 
    {
	    $actual = Get-AzureRmMetricDefinition -ResourceId $resourceUri 

        # Assert TODO add more asserts
		Assert-NotNull $actual
		Assert-True { $actual.Count -gt 0 }
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
