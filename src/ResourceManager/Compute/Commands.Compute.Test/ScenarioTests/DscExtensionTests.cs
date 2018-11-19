using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class DscExtensionTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public DscExtensionTests(ITestOutputHelper output)
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
        public void TestGetAzureRmVMDscExtension()
        {
            //ComputeTestController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmVMDscExtension");
            TestRunner.RunTestScript("Test-GetAzureRmVMDscExtension");
        }
    }
}
