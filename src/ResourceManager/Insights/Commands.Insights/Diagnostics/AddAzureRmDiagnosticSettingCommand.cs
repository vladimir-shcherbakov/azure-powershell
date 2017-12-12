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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmDiagnosticSetting", SupportsShouldProcess = true), OutputType(typeof(PSDiagnosticSettings))]
    public class AddAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        private const string DefaultSettingName = "service";

        private const string RetentionInDaysParamName = "RetentionInDays";
        private bool isRetentionDefined;

        private const string ParameterSetWithStorageAndWithEventHub = "ParameterSetWithStorageAndWithEventHub";
        private const string ParameterSetWithoutStorageAndWithEventHub = "ParameterSetWithoutStorageAndWithEventHub";
        private const string ParameterSetWithStorageAndWithoutEventHub = "ParameterSetWithStorageAndWithoutEventHub";
        private const string ParameterSetWithoutStorageAndWithoutEventHub = "ParameterSetWithoutStorageAndWithoutEventHub";

        #region Parameters declarations

        private const string ResourceIdDescription = "The resource id";

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ResourceIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ResourceIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ResourceIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithoutEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ResourceIdDescription)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        private const string StorageAccountIdDescription = "The storage account id";

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = StorageAccountIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = StorageAccountIdDescription)]
        public string StorageAccountId { get; set; }

        private const string EventHubAuthorizationRuleIdDescription = "The event hub rule id";

        /// <summary>
        /// Gets or sets the event hub authorization rule id parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = EventHubAuthorizationRuleIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = EventHubAuthorizationRuleIdDescription)]
        public string EventHubAuthorizationRuleId { get; set; }

        private const string EventHubNameDescription = "The event name";

        /// <summary>
        /// Gets or sets the event hub name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = EventHubNameDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = EventHubNameDescription)]
        public string EventHubName { get; set; }

        private const string NameDescription = "The Name";

        /// <summary>
        /// Gets or sets the name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = NameDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = NameDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = NameDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithoutEventHub, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = NameDescription)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        private const string LogCategoryDescription = "The log categories";

        /// <summary>
        /// Gets or sets the log categories parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = LogCategoryDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = LogCategoryDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = LogCategoryDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = LogCategoryDescription)]
        [ValidateNotNullOrEmpty]
        public List<string> LogCategory { get; set; }

        private const string MetricCategoryDescription = "The metric categories";

        /// <summary>
        /// Gets or sets the metric categories parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = MetricCategoryDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = MetricCategoryDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = MetricCategoryDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = MetricCategoryDescription)]
        [ValidateNotNullOrEmpty]
        public List<string> MetricCategory { get; set; }

        private const string WorkspaceIdDescription = "The resource Id of the Log Analytics workspace to send logs/metrics to";

        /// <summary>
        /// Gets or sets the OMS workspace Id
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = WorkspaceIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = WorkspaceIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = WorkspaceIdDescription)]
        [Parameter(ParameterSetName = ParameterSetWithoutStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = WorkspaceIdDescription)]
        public string WorkspaceId { get; set; }

        private const string RetentionInDaysDescription = "The retention in days.";

        /// <summary>
        /// Gets or sets the retention in days
        /// </summary>
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = RetentionInDaysDescription)]
        [Parameter(ParameterSetName = ParameterSetWithStorageAndWithoutEventHub, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = RetentionInDaysDescription)]
        public int? RetentionInDays { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.Name = DefaultSettingName;
            }

            DiagnosticSettingsResource putParameters = new DiagnosticSettingsResource
            {
                Logs = new List<LogSettings>(),
                Metrics = new List<MetricSettings>(),
                StorageAccountId = this.StorageAccountId,
                EventHubAuthorizationRuleId = this.EventHubAuthorizationRuleId,
                EventHubName = this.EventHubName,
                WorkspaceId = this.WorkspaceId
            };

            if (this.LogCategory == null && this.MetricCategory == null)
            {
                DiagnosticSettingsCommon.PopulateCategories(
                    this.ResourceId, 
                    true,
                    putParameters, 
                    this.MonitorManagementClient);
            }
            else
            {
                if (this.LogCategory != null)
                {
                    foreach(string category in this.LogCategory)
                    {
                        putParameters.Logs.Add(new LogSettings
                        {
                            Category = category,
                            Enabled = true
                        });
                    }
                }

                if (this.MetricCategory != null)
                {
                    foreach (string category in this.MetricCategory)
                    {
                        putParameters.Metrics.Add(new MetricSettings
                        {
                            Category = category,
                            Enabled = true
                        });
                    }
                }
            }

            HashSet<string> usedParams = new HashSet<string>(this.MyInvocation.BoundParameters.Keys, StringComparer.OrdinalIgnoreCase);

            this.isRetentionDefined = usedParams.Contains(RetentionInDaysParamName);

            if (this.isRetentionDefined)
            {
                EnableRetention(putParameters);
            }

            if (ShouldProcess(this.ResourceId, DiagnosticSettingsCommon.GetShouldProcessMessage("Create or update", this.Name)))
            {
                DiagnosticSettingsResource result = this.MonitorManagementClient.DiagnosticSettings.CreateOrUpdateAsync(
                    resourceUri: this.ResourceId,
                    parameters: putParameters,
                    name: this.Name,
                    cancellationToken: CancellationToken.None).Result;
                WriteObject(new PSDiagnosticSettings(result));
            }
            else
            {
                WriteObject(new PSDiagnosticSettings(putParameters));
            }
        }

        private void EnableRetention(DiagnosticSettingsResource properties)
        {
            var retentionPolicy = new RetentionPolicy
            {
                Enabled = true,
                Days = this.RetentionInDays.Value
            };

            if (properties.Logs != null)
            {
                foreach (LogSettings logSettings in properties.Logs)
                {
                    logSettings.RetentionPolicy = retentionPolicy;
                }
            }

            if (properties.Metrics != null)
            {
                foreach (MetricSettings metricSettings in properties.Metrics)
                {
                    metricSettings.RetentionPolicy = retentionPolicy;
                }
            }
        }
    }
}
