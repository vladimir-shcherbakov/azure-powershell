﻿// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentTests : ResourceTestRunner
    {
        public DeploymentTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Need to implement storage client mock.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateDeployment()
        {
            TestRunner.RunTestScript("Test-ValidateDeployment");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestNewDeploymentFromTemplateFile()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromTemplateFile");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNestedDeploymentFromTemplateFile()
        {
            TestRunner.RunTestScript("Test-NestedDeploymentFromTemplateFile");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestCrossResourceGroupDeploymentFromTemplateFile()
        {
            TestRunner.RunTestScript("Test-CrossResourceGroupDeploymentFromTemplateFile");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveDeploymentTemplateFile()
        {
            TestRunner.RunTestScript("Test-SaveDeploymentTemplateFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNestedErrorsDisplayed()
        {
            TestRunner.RunTestScript("Test-NestedErrorsDisplayed");
        }

        [Fact(Skip = "Fix acquisition of TenantId in KeyVault Test.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithKeyVaultReference()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithKeyVaultReference");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithComplexPramaters()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithComplexPramaters");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestNewDeploymentWithParameterObject()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithParameterObject");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestNewDeploymentWithDynamicParameters()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithDynamicParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithInvalidParameters()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithInvalidParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithKeyVaultReferenceInParameterObject()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithKeyVaultReferenceInParameterObject");
        }
    }
}
