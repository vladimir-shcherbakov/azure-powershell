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
    public partial class VirtualMachineScaleSetTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public VirtualMachineScaleSetTests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSet()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSet");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSet_ManagedDisks()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSet-ManagedDisks");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSet-ManagedDisks");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetReimageUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetReimageUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetReimageUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetLB()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetLB");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetNextLink()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetNextLink");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetNextLink");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetBootDiagnostics()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetBootDiagnostics");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetBootDiagnostics");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetIdentity()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetIdentity");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetIdentity");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetUserIdentity()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetUserIdentity");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetUserIdentity");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetNetworking()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetNetworking");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetNetworking");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetRollingUpgrade()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetRollingUpgrade");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetRollingUpgrade");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetPriority()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetPriority");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetPriority");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetWriteAcceleratorUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetWriteAcceleratorUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetWriteAcceleratorUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetForceUDWalk()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetForceUDWalk");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetForceUDWalk");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetRedeploy()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetRedeploy");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetRedeploy");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetVMUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetVMUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetVMUpdate");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineScaleSetAutoRollback()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineScaleSetAutoRollback");
            TestRunner.RunTestScript("Test-VirtualMachineScaleSetAutoRollback");
        }
    }
}
