using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Network.Test.ScenarioTests
{
    public class NetworkTestRunner
    {
        protected readonly ITestRunner TestRunner;

         protected NetworkTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestFx.TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"Common.ps1",
                })
                .WithExtraRmModules (helper => new[]
                {
                    helper.GetRMModulePath("AzureRM.Insights.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                    helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    helper.GetRMModulePath("AzureRM.ContainerInstance.psd1"),
                    helper.GetRMModulePath("AzureRM.OperationalInsights.psd1"),
#if !NETSTANDARD
                    helper.RMStorageDataPlaneModule,                    
                    helper.GetRMModulePath("AzureRM.Storage.psd1"),
#else
                    helper.RMStorageModule,
#endif
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1",
                })
                .WithNewRecordMatcherArguments (
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Compute", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Storage", null},
                    }
                )
                .Build();
        }
    }
}
