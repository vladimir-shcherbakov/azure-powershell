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
using Microsoft.Azure.Commands.Insights.Diagnostics;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ServiceDiagnosticSettings
    /// </summary>
    public class PSDiagnosticSettings : DiagnosticSettingsResource
    {
        /// <summary>
        /// Deprecated. Use EventHubAuthorizationRuleId instead.
        /// </summary>
        public string ServiceBusRuleId;

        /// <summary>
        /// Initializes a new instance of the PSServiceDiagnosticSettings class.
        /// </summary>
        public PSDiagnosticSettings(DiagnosticSettingsResource diagnosticSettings)
            : base(
                name: diagnosticSettings.Name,
                id: diagnosticSettings.Id, 
                type: diagnosticSettings.Type,
                metrics: null, 
                logs: null)
        {
            this.StorageAccountId = diagnosticSettings.StorageAccountId;
            this.EventHubAuthorizationRuleId = diagnosticSettings.EventHubAuthorizationRuleId;
            this.ServiceBusRuleId = diagnosticSettings.EventHubAuthorizationRuleId;
            this.EventHubName = diagnosticSettings.EventHubName;
            this.Metrics = new List<MetricSettings>();
            foreach (MetricSettings metricSettings in diagnosticSettings.Metrics)
            {
                this.Metrics.Add(new PSMetricSettings(metricSettings));
            }

            this.Logs = new List<LogSettings>();
            foreach (LogSettings logSettings in diagnosticSettings.Logs)
            {
                this.Logs.Add(new PSLogSettings(logSettings));
            }

            this.WorkspaceId = diagnosticSettings.WorkspaceId;
        }
    }
}
