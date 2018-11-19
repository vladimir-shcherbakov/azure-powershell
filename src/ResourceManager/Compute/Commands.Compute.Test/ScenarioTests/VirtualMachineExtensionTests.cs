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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class VirtualMachineExtensionTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public VirtualMachineExtensionTests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineExtensionUsingHashTable");
            TestRunner.RunTestScript("Test-VirtualMachineExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionUsingHashTable()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineExtensionUsingHashTable");
            TestRunner.RunTestScript("Test-VirtualMachineExtensionUsingHashTable");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtension");
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionWrongStorage()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtensionWrongStorage");
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionWrongStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionSecureExecution()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtensionSecureExecution");
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionSecureExecution");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCustomScriptExtensionFileUri()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCustomScriptExtensionFileUri");
            TestRunner.RunTestScript("Test-VirtualMachineCustomScriptExtensionFileUri");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineAccessExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineAccessExtension");
            TestRunner.RunTestScript("Test-VirtualMachineAccessExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "TODO: only works for live mode")]
#endif
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAzureDiskEncryptionExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtension");
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePass()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtensionSinglePass");
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionSinglePass");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePassRemove()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove");
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDiskEncryptionExtensionSinglePassDisableAndRemove()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove");
            TestRunner.RunTestScript("Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineBginfoExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineBginfoExtension");
            TestRunner.RunTestScript("Test-VirtualMachineBginfoExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineExtensionWithSwitch()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineExtensionWithSwitch");
            TestRunner.RunTestScript("Test-VirtualMachineExtensionWithSwitch");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineADDomainExtension");
            TestRunner.RunTestScript("Test-VirtualMachineADDomainExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineADDomainExtensionDomainJoin()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineADDomainExtensionDomainJoin");
            TestRunner.RunTestScript("Test-VirtualMachineADDomainExtensionDomainJoin");
        }
    }
}
