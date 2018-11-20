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
    public class NetworkWatcherAPITests : NetworkTestRunner
    {
        public XunitTracingInterceptor _logger;

        public NetworkWatcherAPITests(ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestGetTopology()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-GetTopology");
            TestRunner.RunTestScript("Test-GetTopology");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestGetSecurityGroupView()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-GetSecurityGroupView");
            TestRunner.RunTestScript("Test-GetSecurityGroupView");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestGetNextHop()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-GetNextHop");
            TestRunner.RunTestScript("Test-GetNextHop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestVerifyIPFlow()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VerifyIPFlow");
            TestRunner.RunTestScript("Test-VerifyIPFlow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestPacketCapture()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PacketCapture");
            TestRunner.RunTestScript("Test-PacketCapture");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestTroubleshoot()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-Troubleshoot");
            TestRunner.RunTestScript("Test-Troubleshoot");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestFlowLog()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-FlowLog");
            TestRunner.RunTestScript("Test-FlowLog");
        }

#if NETSTANDARD
        [Fact(Skip = "This test only applies to desktop")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestConnectivityCheck()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ConnectivityCheck");
            TestRunner.RunTestScript("Test-ConnectivityCheck");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestReachabilityReport()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ReachabilityReport");
            TestRunner.RunTestScript("Test-ReachabilityReport");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestProvidersList()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ProvidersList");
            TestRunner.RunTestScript("Test-ProvidersList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestConnectionMonitor()
        {
//            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ConnectionMonitor");
            TestRunner.RunTestScript("Test-ConnectionMonitor");
        }
    }
}
