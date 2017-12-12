// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    public static class DiagnosticSettingsCommon
    {
        private const string MetricCategoryType = "Metrics";
        private const string LogCategoryType = "Logs";

        public static DiagnosticSettingsResource CopySettings(DiagnosticSettingsResource properties)
        {
            // Location is marked as required, but the get operation returns Location as null. So use an empty string instead of null to avoid validation errors
            var putParameters = new DiagnosticSettingsResource(
                name: properties.Name,
                id: properties.Id,
                type: properties.Type)
            {
                Logs = properties.Logs,
                Metrics = properties.Metrics,
                StorageAccountId = properties.StorageAccountId,
                WorkspaceId = properties.WorkspaceId,
                EventHubAuthorizationRuleId = properties.EventHubAuthorizationRuleId,
                EventHubName = properties.EventHubName
            };

            return putParameters;
        }

        public static void PopulateCategories(
            string resourceId,
            bool isEnabled,
            DiagnosticSettingsResource putParameters, 
            IMonitorManagementClient managementClient)
        {
            DiagnosticSettingsCategoryResourceCollection definedCategories = managementClient.DiagnosticSettingsCategory.ListAsync(
                            resourceUri: resourceId,
                            cancellationToken: CancellationToken.None).Result;

            foreach (var category in definedCategories.Value)
            {
                if (category.CategoryType == CategoryType.Metrics)
                {
                    if (putParameters.Metrics == null)
                    {
                        putParameters.Metrics = new List<MetricSettings>();
                    }

                    putParameters.Metrics.Add(new MetricSettings
                    {
                        Category = category.Name,
                        Enabled = isEnabled
                    });
                }
                else if (category.CategoryType == CategoryType.Logs)
                {
                    if (putParameters.Logs == null)
                    {
                        putParameters.Logs = new List<LogSettings>();
                    }

                    putParameters.Logs.Add(new LogSettings
                    {
                        Category = category.Name,
                        Enabled = isEnabled
                    });
                }
            }
        }

        public static string GetShouldProcessMessage(string operation, string diagnosticSettingsName)
        {
            return string.Format("{0} diagnostic settings '{1}'", operation, diagnosticSettingsName);
        }
    }
}
