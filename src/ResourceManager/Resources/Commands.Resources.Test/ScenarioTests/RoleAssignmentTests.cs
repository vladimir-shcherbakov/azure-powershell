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


using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleAssignmentTests : TestManagerBuilder
    {
        public XunitTracingInterceptor _logger;

        public RoleAssignmentTests(ITestOutputHelper output) : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaClassicAdmins()
        {
            TestManager.RunTestScript("Test-RaClassicAdmins");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeletedPrincipals()
        {
            TestManager.RunTestScript("Test-RaDeletedPrincipals");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void RaPropertiesValidation() {
            TestManager.RunTestScript("Test-RaPropertiesValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaNegativeScenarios()
        {
            TestManager.RunTestScript("Test-RaNegativeScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByScope()
        {
            TestManager.RunTestScript("Test-RaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeleteByPSRoleAssignment()
        {
            TestManager.RunTestScript("Test-RaDeleteByPSRoleAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResourceGroup()
        {
            TestManager.RunTestScript("Test-RaByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResource()
        {
            TestManager.RunTestScript("Test-RaByResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaValidateInputParameters()
        {
            TestManager.RunTestScript("Test-RaValidateInputParameters Get-AzureRmRoleAssignment");
            TestManager.RunTestScript("Test-RaValidateInputParameters New-AzureRmRoleAssignment");
            TestManager.RunTestScript("Test-RaValidateInputParameters Remove-AzureRmRoleAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByServicePrincipal()
        {
            TestManager.RunTestScript("Test-RaByServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaById()
        {
            TestManager.RunTestScript("Test-RaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeletionByScope()
        {
            TestManager.RunTestScript("Test-RaDeletionByScope");
        }

        [Fact(Skip = "Need AD team to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeletionByScopeAtRootScope()
        {
            TestManager.RunTestScript("Test-RaDeletionByScopeAtRootScope");
        }

        [Fact(Skip = "Need AD team to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDelegation()
        {
            TestManager.RunTestScript("Test-RaDelegation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByUpn()
        {
            TestManager.RunTestScript("Test-RaByUpn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaGetByScope()
        {
            TestManager.RunTestScript("Test-RaGetByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaGetByUPNWithExpandPrincipalGroups()
        {
            TestManager.RunTestScript("Test-RaGetByUPNWithExpandPrincipalGroups");
        }

        [Fact(Skip = "Fix the flaky test and token error and then re-record the test. Token from admin user is being used even when trying to use newly created user.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaUserPermissions()
        {
            User newUser = null;
            ResourceGroup resourceGroup = null;
            string roleAssignmentId = "A807281A-2F74-44B9-B862-C0D3683ADCC9";
            string userName = null;
            string userPass = null;
            string userPermission = "*/read";
            string roleDefinitionName = "Reader";
            string newUserObjectId = null;

            var controllerAdmin = ResourcesController.NewInstance;

            try
            {
                // Generate new user under admin account
                controllerAdmin.RunPsTestWorkflow(
                    _logger,
                    // scriptBuilder
                    () =>
                    {
                        userName = TestUtilities.GenerateName("aduser");
                        userPass = TestUtilities.GenerateName("adpass") + "0#$";

                        var upn = userName + "@" + controllerAdmin.UserDomain;

                        var parameter = new UserCreateParameters
                        {
                            UserPrincipalName = upn,
                            DisplayName = userName,
                            AccountEnabled = true,
                            MailNickname = userName + "test",
                            PasswordProfile = new PasswordProfile
                            {
                                ForceChangePasswordNextLogin = false,
                                Password = userPass
                            }
                        };

                        newUser = controllerAdmin.GraphClient.Users.Create(parameter);
                        newUserObjectId = newUser.ObjectId;

                        resourceGroup = controllerAdmin.ResourceManagementClient.ResourceGroups
                                            .List()
                                            .First();

                    // Wait to allow newly created object changes to propagate
                    TestMockSupport.Delay(20000);

                        return new[]
                        {
                        string.Format(
                            "CreateRoleAssignment '{0}' '{1}' '{2}' '{3}'",
                                roleAssignmentId,
                                newUserObjectId,
                                roleDefinitionName,
                                resourceGroup.Name)
                        };
                    },
                    // cleanup
                    null,
                    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                    MethodBase.GetCurrentMethod().Name + "_Setup");

                // login as different user and run the test
                var controllerUser = ResourcesController.NewInstance;
                controllerUser.RunPsTestWorkflow(
                    _logger,
                    // scriptBuilder
                    () =>
                    {
                    // Wait to allow for the role assignment to propagate
                    TestMockSupport.Delay(20000);

                        return new[]
                        {
                        string.Format(
                            "Test-RaUserPermissions '{0}' '{1}'",
                            resourceGroup.Name,
                            userPermission)
                        };
                    },
                    // cleanup
                    null,
                    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                    MethodBase.GetCurrentMethod().Name + "_Test");
            }
            finally
            {
                // remove created user and assignment
                controllerAdmin = ResourcesController.NewInstance;
                controllerAdmin.RunPsTestWorkflow(
                    // scriptBuilder
                    null,
                    // initialize
                    null,
                    // cleanup
                    () =>
                    {
                        if (newUser != null)
                        {
                            controllerAdmin.GraphClient.Users.Delete(newUser.ObjectId);
                        }

                        if (resourceGroup != null)
                        {
                            controllerAdmin.AuthorizationManagementClient.RoleAssignments.Delete(resourceGroup.Id, roleAssignmentId).ToString();
                        }
                    },
                    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                    MethodBase.GetCurrentMethod().Name + "_Cleanup");
            }
        }
    }
}
