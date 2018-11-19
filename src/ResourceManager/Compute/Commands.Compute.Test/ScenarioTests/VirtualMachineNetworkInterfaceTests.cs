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
    public class VirtualMachineNetworkInterfaceTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public VirtualMachineNetworkInterfaceTests(ITestOutputHelper output)
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
        public void TestVirtualMachineSingleNetworkInterface()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SingleNetworkInterface");
            TestRunner.RunTestScript("Test-SingleNetworkInterface");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineMultipleNetworkInterface()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-MultipleNetworkInterface");
            TestRunner.RunTestScript("Test-MultipleNetworkInterface");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSingleNetworkInterfaceDnsSettings()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SingleNetworkInterfaceDnsSettings");
            TestRunner.RunTestScript("Test-SingleNetworkInterfaceDnsSettings");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddNetworkInterface()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AddNetworkInterface");
            TestRunner.RunTestScript("Test-AddNetworkInterface");
        }


#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEffectiveRoutesAndNsg()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-EffectiveRoutesAndNsg");
            TestRunner.RunTestScript("Test-EffectiveRoutesAndNsg");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSingleNetworkInterfaceWithAcceleratedNetworking()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SingleNetworkInterfaceWithAcceleratedNetworking");
            TestRunner.RunTestScript("Test-SingleNetworkInterfaceWithAcceleratedNetworking");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMNicWithAcceleratedNetworkingValidations()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VMNicWithAcceleratedNetworkingValidations");
            TestRunner.RunTestScript("Test-VMNicWithAcceleratedNetworkingValidations");
        }
    }
}
