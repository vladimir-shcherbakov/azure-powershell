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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class AzureRmDiagnosticSettingTests : RMTestBase
    {
        public AzureRmDiagnosticSettingTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            //ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmDiagnosticSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmDiagnosticSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmDiagnosticSettingList()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmDiagnosticSetting-List");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSetting");
        }

        [Fact] //(Skip = "TODO: fixing this test after introducing Swagger specs")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingWithRetention()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSettingWithRetention");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingCategoriesOnly()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSetting-CategoriesOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingTimeGrainsOnly()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSetting-TimegrainsOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingLogCategory()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSetting-LogCategory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingMetricCategory()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSetting-MetricCategory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingEnableDisableDestinations()
        {
            TestsController.NewInstance.RunPsTest("Test-SetAzureRmDiagnosticSetting-EnableDisableDestinations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmDiagnosticSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmDiagnosticSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmDiagnosticSettingLogCategory()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmDiagnosticSetting-LogCategory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmDiagnosticSettingMetricCategory()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmDiagnosticSetting-MetricCategory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmDiagnosticSettingLogCategoryAndMetricCategory()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmDiagnosticSetting-LogCategoryAndMetricCategory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmDiagnosticSettingStorageOnly()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmDiagnosticSetting-StorageOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmDiagnosticSettingEventHubOnly()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmDiagnosticSetting-EventHubOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmDiagnosticSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-RemoveAzureRmDiagnosticSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableDisableAzureRmDiagnosticSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-EnableDisableAzureRmDiagnosticSetting");
        }
    }
}