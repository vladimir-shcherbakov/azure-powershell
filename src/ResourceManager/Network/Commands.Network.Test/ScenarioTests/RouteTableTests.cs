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

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class RouteTableTests : NetworkTestRunner
    {
        public XunitTracingInterceptor _logger;

        public RouteTableTests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestEmptyRouteTable()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-EmptyRouteTable");
            TestRunner.RunTestScript("Test-EmptyRouteTable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestRouteTableCRUD()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-RouteTableCRUD");
            TestRunner.RunTestScript("Test-RouteTableCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestRouteTableSubnetRef()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-RouteTableSubnetRef");
            TestRunner.RunTestScript("Test-RouteTableSubnetRef");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestRouteTableRouteCRUD()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-RouteTableRouteCRUD");
            TestRunner.RunTestScript("Test-RouteTableRouteCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestRouteHopTypeTest()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-RouteHopTypeTest");
            TestRunner.RunTestScript("Test-RouteHopTypeTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestRouteWithDisableBgpRoutePropagation()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-RouteTableWithDisableBgpRoutePropagation");
            TestRunner.RunTestScript("Test-RouteTableWithDisableBgpRoutePropagation");
        }
    }
}
