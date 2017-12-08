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

using System.Collections.Generic;
using System.Xml;
using Microsoft.Azure.Commands.Insights.Metrics;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class GetAzureRmMetricTests
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        private readonly GetAzureRmMetricCommand cmdlet;
        private readonly Mock<MonitorClient> MonitorClientMock;
        private readonly Mock<IMetricsOperations> insightsMetricOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Microsoft.Rest.Azure.AzureOperationResponse<Response> response;
        private string resourceId;
        private ODataQuery<MetadataValue> filter;
        private string timespan;
        private TimeSpan? interval;
        private string metric;
        private string aggregation;
        private ResultType resultType;

        public GetAzureRmMetricTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsMetricOperationsMock = new Mock<IMetricsOperations>();
            MonitorClientMock = new Mock<MonitorClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorClient = MonitorClientMock.Object
            };

            response = new Microsoft.Rest.Azure.AzureOperationResponse<Response>()
            {
                Body = this.GetMetricCollection(ResourceUri)
            };

            insightsMetricOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<ODataQuery<MetadataValue>>(), It.IsAny<string>(), It.IsAny<TimeSpan?>(), It.IsAny<string>(), It.IsAny<string>(), It.Is<ResultType>(v => v == ResultType.Data), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response))
                .Callback((string r, ODataQuery<MetadataValue> s, string ts, TimeSpan? i, string m, string a, ResultType rt, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceId = r;
                    filter = s;
                    timespan = ts;
                    interval = i;
                    metric = m;
                    aggregation = a;
                    resultType = rt;
                });

            MonitorClientMock.SetupGet(f => f.Metrics).Returns(this.insightsMetricOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMetricsCommandParametersProcessing()
        {
            // Testting defaults and required parameters
            cmdlet.ResourceId = ResourceUri;

            cmdlet.ExecuteCmdlet();
            Assert.Null(filter);
            Assert.Null(metric);
            Assert.Null(aggregation);
            Assert.Null(interval);
            Assert.NotNull(timespan);
            Assert.Equal(ResourceUri, resourceId);
            Assert.Equal(ResultType.Data, resultType);

            cmdlet.MetricName = new[] { "CpuTime" };
            cmdlet.ExecuteCmdlet();
            Assert.Null(filter);
            Assert.Equal("CpuTime", metric);
            Assert.Null(aggregation);
            Assert.Null(interval);
            Assert.NotNull(timespan);
            Assert.Equal(ResourceUri, resourceId);
            Assert.Equal(ResultType.Data, resultType);

            cmdlet.AggregationType = AggregationType.Total;
            cmdlet.ExecuteCmdlet();
            Assert.Null(filter);
            Assert.Equal("CpuTime", metric);
            Assert.Equal(AggregationType.Total.ToString(), aggregation);
            Assert.Null(interval);
            Assert.NotNull(timespan);
            Assert.Equal(ResourceUri, resourceId);
            Assert.Equal(ResultType.Data, resultType);

            var endDate = DateTime.UtcNow.AddMinutes(-1);
            cmdlet.EndTime = endDate;

            cmdlet.ExecuteCmdlet();
            Assert.Null(filter);
            Assert.Equal("CpuTime", metric);
            Assert.Equal(AggregationType.Total.ToString(), aggregation);
            Assert.Null(interval);
            Assert.NotNull(timespan);
            Assert.True(timespan.Contains("/" + endDate.ToUniversalTime().ToString("O")));
            Assert.Equal(ResourceUri, resourceId);
            Assert.Equal(ResultType.Data, resultType);
        }

        private Response GetMetricCollection(string resourceId)
        {
            return new Response
            {
                Timespan = "2017-08-10T22:19:35Z/2017-08-10T23:19:35Z",
                Cost = 0,
                Interval = TimeSpan.FromMinutes(1),
                Value = new List<Metric>
                {
                    new Metric
                    {
                        Id = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest/providers/Microsoft.Insights/metrics/CpuTime",
                        Type = "Microsoft.Insights/metrics",
                        Name = new LocalizableString {LocalizedValue = "CPU Time", Value = "CpuTime"},
                        Unit = Unit.Seconds,
                        Timeseries = new List<TimeSeriesElement>
                        {
                            new TimeSeriesElement
                            {
                                Data = new List<MetricValue>
                                {
                                    new MetricValue
                                    {
                                        TimeStamp = DateTime.Parse("2017-08-10T22:19:00Z"),
                                        Total = 0.0
                                    },
                                    new MetricValue
                                    {
                                        TimeStamp = DateTime.Parse("2017-08-10T22:20:00Z"),
                                        Total = 0.0
                                    },
                                    new MetricValue
                                    {
                                        TimeStamp = DateTime.Parse("2017-08-10T22:21:00Z"),
                                        Total = 0.0
                                    }
                                },
                                Metadatavalues = new List<MetadataValue>()
                            }
                        }
                    }
                }
            };
        }
    }
}
