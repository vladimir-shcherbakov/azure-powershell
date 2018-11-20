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
    public class LoadBalancerTests : NetworkTestRunner
    {
        public XunitTracingInterceptor _logger;

        public LoadBalancerTests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublic()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-Public");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicTcpReset()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicTcpReset");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicTcpReset");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalDynamic()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalDynamic");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalDynamic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalStatic()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalStatic");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalStatic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicNoInboundNATRule()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicNoInboundNATRule");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicNoInboundNATRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicPublicNoLbRule()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicNoLbRule");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicNoLbRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalUsingId()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalUsingId");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicUsingId()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicUsingId");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerChildResource()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerChildResource");
            TestRunner.RunTestScript("Test-LoadBalancerChildResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerSet()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerSet");
            TestRunner.RunTestScript("Test-LoadBalancerSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestCreateEmptyLoadBalancer()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CreateEmptyLoadBalancer");
            TestRunner.RunTestScript("Test-CreateEmptyLoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerNicAssociation()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancer-NicAssociation");
            TestRunner.RunTestScript("Test-LoadBalancer-NicAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerNicAssociationDuringCreate()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancer-NicAssociationDuringCreate");
            TestRunner.RunTestScript("Test-LoadBalancer-NicAssociationDuringCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatPoolConfigInternalLB()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerInboundNatPoolConfigCRUD-InternalLB");
            TestRunner.RunTestScript("Test-LoadBalancerInboundNatPoolConfigCRUD-InternalLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatPoolConfigCRUDPublicLB()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerInboundNatPoolConfigCRUD-PublicLB");
            TestRunner.RunTestScript("Test-LoadBalancerInboundNatPoolConfigCRUD-PublicLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerMultiVipPublic()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerMultiVip-Public");
            TestRunner.RunTestScript("Test-LoadBalancerMultiVip-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerMultiVipInternal()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerMultiVip-Internal");
            TestRunner.RunTestScript("Test-LoadBalancerMultiVip-Internal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerObjectAssignment()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-SetLoadBalancerObjectAssignment");
            TestRunner.RunTestScript("Test-SetLoadBalancerObjectAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicBasicSku()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicBasicSku");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalBasicSku()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalBasicSku");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicStandardSku()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicStandardSku");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalStandardSku()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalStandardSku");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalHighlyAvailableBasicSku()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalHighlyAvailableBasicSku");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalHighlyAvailableBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalHighlyAvailableStandardSku()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalHighlyAvailableStandardSku");
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalHighlyAvailableStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerZones()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerZones");
            TestRunner.RunTestScript("Test-LoadBalancerZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestCreateSubresourcesOnEmptyLoadBalancer()
        {
            //NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CreateSubresourcesOnEmptyLoadBalancer");
            TestRunner.RunTestScript("Test-CreateSubresourcesOnEmptyLoadBalancer");
        }
    }
}
