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
    public partial class VirtualMachineTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public VirtualMachineTests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, @"Test-VirtualMachine $null");
            TestRunner.RunTestScript(@"Test-VirtualMachine $null");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine_Managed()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, @"Test-VirtualMachine $null $true");
            TestRunner.RunTestScript(@"Test-VirtualMachine $null $true");
        }

#if NETSTANDARD
        [Fact(Skip = "Get-Location in Common.ps1 is not working correctly for NETSTANDARD")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePiping()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePiping");
            TestRunner.RunTestScript("Test-VirtualMachinePiping");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineUpdateWithoutNic()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineUpdateWithoutNic");
            TestRunner.RunTestScript("Test-VirtualMachineUpdateWithoutNic");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxVirtualMachine()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-LinuxVirtualMachine");
            TestRunner.RunTestScript("Test-LinuxVirtualMachine");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithVMAgentAutoUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithVMAgentAutoUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineWithVMAgentAutoUpdate");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageList()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineImageList");
            TestRunner.RunTestScript("Test-VirtualMachineImageList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineList()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineList");
            TestRunner.RunTestScript("Test-VirtualMachineList");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSizeAndUsage()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineSizeAndUsage");
            TestRunner.RunTestScript("Test-VirtualMachineSizeAndUsage");
        }

#if NETSTANDARD
        [Fact(Skip = "Get-Location in Common.ps1 is not working correctly for NETSTANDARD")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCapture()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCapture");
            TestRunner.RunTestScript("Test-VirtualMachineCapture");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCaptureNegative()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineCaptureNegative");
            TestRunner.RunTestScript("Test-VirtualMachineCaptureNegative");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDisk()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineDataDisk");
            TestRunner.RunTestScript("Test-VirtualMachineDataDisk");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDiskNegative()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineDataDiskNegative");
            TestRunner.RunTestScript("Test-VirtualMachineDataDiskNegative");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePIRv2()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePIRv2");
            TestRunner.RunTestScript("Test-VirtualMachinePIRv2");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePlan");
            TestRunner.RunTestScript("Test-VirtualMachinePlan");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan2()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePlan2");
            TestRunner.RunTestScript("Test-VirtualMachinePlan2");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineTags()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineTags");
            TestRunner.RunTestScript("Test-VirtualMachineTags");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageCmdletOutputFormat()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VMImageCmdletOutputFormat");
            TestRunner.RunTestScript("Test-VMImageCmdletOutputFormat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMSizeFromAllLocations()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-GetVMSizeFromAllLocations");
            TestRunner.RunTestScript("Test-GetVMSizeFromAllLocations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineListWithPaging()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineListWithPaging");
            TestRunner.RunTestScript("Test-VirtualMachineListWithPaging");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithDifferentStorageResource()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithDifferentStorageResource");
            TestRunner.RunTestScript("Test-VirtualMachineWithDifferentStorageResource");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithPremiumStorageAccount()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithPremiumStorageAccount");
            TestRunner.RunTestScript("Test-VirtualMachineWithPremiumStorageAccount");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithEmptyAuc()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithEmptyAuc");
            TestRunner.RunTestScript("Test-VirtualMachineWithEmptyAuc");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "CRP needs to re-record the test")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithBYOL()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWithBYOL");
            TestRunner.RunTestScript("Test-VirtualMachineWithBYOL");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineRedeploy()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineRedeploy");
            TestRunner.RunTestScript("Test-VirtualMachineRedeploy");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetStatus()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineGetStatus");
            TestRunner.RunTestScript("Test-VirtualMachineGetStatus");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDiskConversion()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineManagedDiskConversion");
            TestRunner.RunTestScript("Test-VirtualMachineManagedDiskConversion");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePerformanceMaintenance()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachinePerformanceMaintenance");
            TestRunner.RunTestScript("Test-VirtualMachinePerformanceMaintenance");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentity()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineIdentity");
            TestRunner.RunTestScript("Test-VirtualMachineIdentity");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentityUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineIdentityUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineIdentityUpdate");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWriteAcceleratorUpdate()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineWriteAcceleratorUpdate");
            TestRunner.RunTestScript("Test-VirtualMachineWriteAcceleratorUpdate");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDisk()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VirtualMachineManagedDisk");
            TestRunner.RunTestScript("Test-VirtualMachineManagedDisk");
        }
    }
}
