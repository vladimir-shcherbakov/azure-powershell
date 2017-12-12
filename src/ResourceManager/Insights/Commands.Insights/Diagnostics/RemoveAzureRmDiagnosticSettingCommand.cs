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
using System.Net;
using System.Threading;
using Microsoft.Azure.Commands.Insights.Diagnostics;

namespace Microsoft.Azure.Commands.Insights.LogProfiles
{
    /// <summary>
    /// Removes the log profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmDiagnosticSetting", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmDiagnosticSettingCommand : ManagementCmdletBase
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)] 
        public SwitchParameter PassThru { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(this.ResourceId, DiagnosticSettingsCommon.GetShouldProcessMessage("Remove", this.Name)))
            {
                Rest.Azure.AzureOperationResponse result = this.MonitorManagementClient.DiagnosticSettings.DeleteWithHttpMessagesAsync(
                resourceUri: this.ResourceId,
                name: Name,
                cancellationToken: CancellationToken.None).Result;

                var response = new AzureOperationResponse
                {
                    RequestId = result.RequestId,
                    StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK
                };

                WriteObject(response);
            }
        }
    }
}
