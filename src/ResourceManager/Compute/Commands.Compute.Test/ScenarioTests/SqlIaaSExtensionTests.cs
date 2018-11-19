using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class SqlIaaSExtensionTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public SqlIaaSExtensionTests(ITestOutputHelper output)
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
        public void TestSqlIaaSExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerExtension");
            TestRunner.RunTestScript("Test-SetAzureRmVMSqlServerExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip ="CRP needs to re-record the test")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSAKVExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerAKVExtension");
            TestRunner.RunTestScript("Test-SetAzureRmVMSqlServerAKVExtension");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSExtensionWith2016Image()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerExtensionWith2016Image");
            TestRunner.RunTestScript("Test-SetAzureRmVMSqlServerExtensionWith2016Image");
        }
    }
}
