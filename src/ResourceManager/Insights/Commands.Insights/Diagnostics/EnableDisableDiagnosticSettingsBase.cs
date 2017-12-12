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

using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    public abstract class EnableDisableDiagnosticSettingsBase : ManagementCmdletBase
    {
        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        protected void Process(bool enable)
        {
            DiagnosticSettingsResource getResponse = this.MonitorManagementClient.DiagnosticSettings.GetAsync(
                resourceUri: this.ResourceId,
                name: this.Name,
                cancellationToken: CancellationToken.None).Result;

            if (getResponse.Logs != null)
            {
                foreach (LogSettings log in getResponse.Logs)
                {
                    log.Enabled = enable;
                }
            }

            if (getResponse.Metrics != null)
            {
                foreach (LogSettings log in getResponse.Logs)
                {
                    log.Enabled = enable;
                }
            }

            var putParameters = DiagnosticSettingsCommon.CopySettings(getResponse);

            if (ShouldProcess(this.ResourceId, DiagnosticSettingsCommon.GetShouldProcessMessage(enable ? "Enable" : "Disable", this.Name)))
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
    }
}
