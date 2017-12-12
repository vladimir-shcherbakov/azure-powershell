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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Xml;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmDiagnosticSetting", SupportsShouldProcess = true), OutputType(typeof(PSDiagnosticSettings))]
    public class SetRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        private const string DefaultSettingName = "service";
        public const string StorageAccountIdParamName = "StorageAccountId";
        public const string ServiceBusRuleIdParamName = "ServiceBusRuleId";
        public const string EventHubRuleIdParamName = "EventHubAuthorizationRuleId";
        public const string EventHubNameParamName = "EventHubName";
        public const string WorkspacetIdParamName = "WorkspaceId";
        public const string EnabledParamName = "Enabled";
        public const string NameParamName = "Name";

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus rule id")]
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the event hub authorization rule id parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The event hub rule id")]
        public string EventHubAuthorizationRuleId { get; set; }

        /// <summary>
        /// Gets or sets the event hub name parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The event name")]
        public string EventHubName { get; set; }

        /// <summary>
        /// Gets or sets the enable parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the diagnostics should be enabled or disabled")]
        [ValidateNotNullOrEmpty]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the name parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the log categories parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Deprecated. Use LogCategory.")]
        [ValidateNotNullOrEmpty]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the log categories parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The log categories")]
        [ValidateNotNullOrEmpty]
        public List<string> LogCategory { get; set; }

        /// <summary>
        /// Gets or sets the metric categories parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric categories")]
        [ValidateNotNullOrEmpty]
        public List<string> MetricCategory { get; set; }

        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The timegrains")]
        [ValidateNotNullOrEmpty]
        public List<string> Timegrains { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether retention should be enabled
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the retention should be enabled")]
        [ValidateNotNullOrEmpty]
        public bool? RetentionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the OMS workspace Id
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id of the Log Analytics workspace to send logs/metrics to")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the retention in days
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The retention in days.")]
        public int? RetentionInDays { get; set; }

        #endregion

        private bool isStorageParamPresent;

        private bool isServiceBusParamPresent;

        private bool isEventHubRuleParamPresent;

        private bool isEventHubNameParamPresent;

        private bool isWorkspaceParamPresent;

        private bool isEnabledParameterPresent;

        private bool isNameParameterPresent;

        protected override void ProcessRecordInternal()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.Name = DefaultSettingName;
            }

            HashSet<string> usedParams = new HashSet<string>(this.MyInvocation.BoundParameters.Keys, StringComparer.OrdinalIgnoreCase);

            this.isStorageParamPresent = usedParams.Contains(StorageAccountIdParamName);
            this.isServiceBusParamPresent = usedParams.Contains(ServiceBusRuleIdParamName);
            this.isEventHubRuleParamPresent = usedParams.Contains(EventHubRuleIdParamName);
            this.isEventHubNameParamPresent = usedParams.Contains(EventHubNameParamName);
            this.isWorkspaceParamPresent = usedParams.Contains(WorkspacetIdParamName);
            this.isEnabledParameterPresent = usedParams.Contains(EnabledParamName);
            this.isNameParameterPresent = usedParams.Contains(EnabledParamName);

            if (!this.isStorageParamPresent &&
                !this.isServiceBusParamPresent &&
                !this.isEventHubRuleParamPresent &&
                !this.isWorkspaceParamPresent &&
                !this.isEnabledParameterPresent)
            {
                throw new ArgumentException("No operation is specified");
            }

            DiagnosticSettingsResource properties = null;
            
            try
            {
                properties = this.MonitorManagementClient.DiagnosticSettings.GetAsync(
                    resourceUri: this.ResourceId,
                    name: this.Name,
                    cancellationToken: CancellationToken.None).Result;
            }
            catch (Exception)
            {
                properties = new DiagnosticSettingsResource();
                DiagnosticSettingsCommon.PopulateCategories(
                    this.ResourceId,
                    false,
                    properties,
                    this.MonitorManagementClient);
            }

            SetStorage(properties);
            
            SetEventHubRule(properties);

            SetWorkspace(properties);

            // Handling the renaming of Categories to LogCategory.
            if (this.LogCategory == null && this.Categories != null)
            {
                this.LogCategory = this.Categories;
            }

            if (this.LogCategory == null && 
                this.MetricCategory == null && 
                this.Timegrains == null)
            {
                SetAllLogsAndMetrics(properties);
            }
            else
            {
                if (this.LogCategory != null)
                {
                    SetSelectedLogCategoryList(properties);
                }

                if (this.MetricCategory != null)
                {
                    SetSelectedMetricCategoryList(properties);
                }

                if (this.Timegrains != null)
                {
                    SetSelectedTimegrains(properties);
                }
            }

            if (this.RetentionEnabled.HasValue)
            {
                SetRetention(properties);
            }

            DiagnosticSettingsResource putParameters = CopySettings(properties);

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

        private static DiagnosticSettingsResource CopySettings(DiagnosticSettingsResource properties)
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

        private void SetRetention(DiagnosticSettingsResource properties)
        {
            var retentionPolicy = new RetentionPolicy
            {
                Enabled = this.RetentionEnabled.Value,
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

        private void SetSelectedTimegrains(DiagnosticSettingsResource properties)
        {
            if (!this.isEnabledParameterPresent)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'Timegrains' parameter.");
            }

            foreach(MetricSettings metricSettings in properties.Metrics)
            {
                // Timegrain is a legacy concept since PT1M is the only 
                // avaialable time grain in the newest api.
                // It is safe to assume that when no timegrain is provided,
                // it means PT1M, so we can still work on the legacy case.
                if (metricSettings.TimeGrain == null)
                {
                    metricSettings.TimeGrain = TimeSpan.FromMinutes(1);
                }
            }

            if (this.Timegrains != null && this.Timegrains.Count > 0)
            {
                foreach (string timegrainString in this.Timegrains)
                {
                    TimeSpan timegrain = XmlConvert.ToTimeSpan(timegrainString);
                    MetricSettings metricSettings = properties.Metrics.FirstOrDefault(x => TimeSpan.Equals(x.TimeGrain, timegrain));

                    if (metricSettings == null)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Metric timegrain '{0}' is not available", timegrainString));
                    }
                    metricSettings.Enabled = this.Enabled;
                }
            }
        }

        private void SetSelectedLogCategoryList(DiagnosticSettingsResource properties)
        {
            if (!this.isEnabledParameterPresent)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'Categories' parameter.");
            }

            if (this.LogCategory != null && this.LogCategory.Count > 0)
            {
                if (properties.Logs == null)
                {
                    properties.Logs = new List<LogSettings>();
                }

                foreach (string category in this.LogCategory)
                {
                    LogSettings logSettings = properties.Logs.FirstOrDefault(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));

                    if (logSettings == null)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Log category '{0}' is not available", category));
                    }

                    logSettings.Enabled = this.Enabled;
                }
            }
        }

        private void SetSelectedMetricCategoryList(DiagnosticSettingsResource properties)
        {
            if (!this.isEnabledParameterPresent)
            {
                throw new ArgumentException("Parameter 'Enabled' is required by 'Categories' parameter.");
            }

            if (this.MetricCategory != null && this.MetricCategory.Count > 0)
            {
                if (properties.Metrics == null)
                {
                    properties.Metrics = new List<MetricSettings>();
                }

                foreach (string category in this.MetricCategory)
                {
                    MetricSettings metricSettings = properties.Metrics.FirstOrDefault(x => string.Equals(
                        x.Category,
                        category,
                        StringComparison.OrdinalIgnoreCase));

                    if (metricSettings == null)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Metric category '{0}' is not available", category));
                    }

                    metricSettings.Enabled = this.Enabled;
                }
            }
        }

        private void SetAllLogsAndMetrics(DiagnosticSettingsResource properties)
        {
            if (!this.isEnabledParameterPresent)
            {
                return;
            }

            if (properties.Logs != null)
            {
                foreach (LogSettings log in properties.Logs)
                {
                    log.Enabled = this.Enabled;
                }
            }

            if (properties.Metrics != null)
            {
                foreach (MetricSettings metric in properties.Metrics)
                {
                    metric.Enabled = this.Enabled;
                }
            }
        }

        private void SetWorkspace(DiagnosticSettingsResource properties)
        {
            if (this.isWorkspaceParamPresent)
            {
                properties.WorkspaceId = this.WorkspaceId;
            }
        }

        private void SetEventHubRule(DiagnosticSettingsResource properties)
        {
            if (this.isEventHubRuleParamPresent)
            {
                properties.EventHubAuthorizationRuleId = this.EventHubAuthorizationRuleId;
            }else if (this.isServiceBusParamPresent)
            {
                properties.EventHubAuthorizationRuleId = this.ServiceBusRuleId;
            }

            if (this.isEventHubNameParamPresent)
            {
                properties.EventHubName = this.EventHubName;
            }
        }


        private void SetStorage(DiagnosticSettingsResource properties)
        {
            if (this.isStorageParamPresent)
            {
                properties.StorageAccountId = this.StorageAccountId;
            }
        }
    }
}
