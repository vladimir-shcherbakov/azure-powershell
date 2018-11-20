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

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class NetworkInterfaceTests : NetworkTestRunner
    {
        public XunitTracingInterceptor _logger;

        public NetworkInterfaceTests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceCRUD()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceCRUD");
            TestRunner.RunTestScript("Test-NetworkInterfaceCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceCRUDUsingId()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceCRUDUsingId");
            TestRunner.RunTestScript("Test-NetworkInterfaceCRUDUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceCRUDStaticAllocation()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceCRUDStaticAllocation");
            TestRunner.RunTestScript("Test-NetworkInterfaceCRUDStaticAllocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceNoPublicIpAddress()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceNoPublicIpAddress");
            TestRunner.RunTestScript("Test-NetworkInterfaceNoPublicIpAddress");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceSet()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceSet");
            TestRunner.RunTestScript("Test-NetworkInterfaceSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceIDns()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceIDns");
            TestRunner.RunTestScript("Test-NetworkInterfaceIDns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceEnableIPForwarding()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceEnableIPForwarding");
            TestRunner.RunTestScript("Test-NetworkInterfaceEnableIPForwarding");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceExpandResource()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceExpandResource");
            TestRunner.RunTestScript("Test-NetworkInterfaceExpandResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceIpv6()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceIpv6");
            TestRunner.RunTestScript("Test-NetworkInterfaceIpv6");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceWithIpConfiguration()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceWithIpConfiguration");
            TestRunner.RunTestScript("Test-NetworkInterfaceWithIpConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceWithAcceleratedNetworking()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceWithAcceleratedNetworking");
            TestRunner.RunTestScript("Test-NetworkInterfaceWithAcceleratedNetworking");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceTapConfigurationCRUD()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, string.Format("Test-NetworkInterfaceTapConfigurationCRUD"));
            TestRunner.RunTestScript("Test-NetworkInterfaceTapConfigurationCRUD");
        }
    }
}
