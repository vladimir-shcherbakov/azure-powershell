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
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.Diagnostics;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Diagnostics
{
    public class DisableDiagnosticSettingCommandTests
    {
        private readonly DisableAzureRmDiagnosticSettingCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IDiagnosticSettingsOperations> insightsDiagnosticsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private const string ResourceId = "/subscriptions/123/resourcegroups/rg/providers/rp/resource/myresource";

        private string resourceIdIn;
        private string settingName;

        public DisableDiagnosticSettingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.insightsDiagnosticsOperationsMock = new Mock<IDiagnosticSettingsOperations>();
            this.insightsManagementClientMock = new Mock<MonitorManagementClient>();
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new DisableAzureRmDiagnosticSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            insightsDiagnosticsOperationsMock.Setup(f => f.DeleteWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()))
                   .Returns(Task.FromResult(new Rest.Azure.AzureOperationResponse
                   {
                       RequestId = "111-222"
                   }))
                   .Callback((string resourceId, string settingName, Dictionary<string, List<string>> headers, CancellationToken t) =>
                   {
                       this.resourceIdIn = resourceId;
                       this.settingName = settingName;
                   });

            var response = new Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResource>()
            {
                Body = new DiagnosticSettingsResource
                {
                    EventHubAuthorizationRuleId = "",
                    EventHubName = "myeventhub",
                    StorageAccountId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.storage/accounts/myaccount",
                    WorkspaceId = "",
                    Logs = new List<LogSettings>
                    {
                        new LogSettings
                        {
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 10,
                                Enabled = true
                            },
                            Category = "TestCategory1",
                            Enabled = true
                        },
                        new LogSettings
                        {
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 5,
                                Enabled = false
                            },
                            Category = "TestCategory2",
                            Enabled = false
                        }
                    },
                    Metrics = new List<MetricSettings>
                    {
                        new MetricSettings
                        {
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 7,
                                Enabled = false
                            },
                            TimeGrain = TimeSpan.FromMinutes(1),
                            Enabled = false
                        },
                        new MetricSettings
                        {
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 3,
                                Enabled = true
                            },
                            TimeGrain = TimeSpan.FromHours(1)
                        }
                    }
                }
            };

            insightsDiagnosticsOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(response))
                    .Callback((string resourceId, string name, Dictionary<string, List<string>> headers, CancellationToken cancellationToken) =>
                    {
                        this.resourceIdIn = resourceId;
                        this.settingName = name;
                    });

            insightsManagementClientMock.SetupGet(f => f.DiagnosticSettings).Returns(this.insightsDiagnosticsOperationsMock.Object);

            cmdlet.ResourceId = ResourceId;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableSettingTest()
        {
            cmdlet.Name = "MySetting";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(ResourceId, resourceIdIn);
            Assert.Equal("MySetting", settingName);
        }
    }
}