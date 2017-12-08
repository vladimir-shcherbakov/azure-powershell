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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.Metrics
{
    /// <summary>
    /// Get the list of metric definition for a resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmMetric"), OutputType(typeof(PSMetric[]))]
    public class GetAzureRmMetricCommand : MonitorClientCmdletBase
    {
        internal const string GetAzureRmAMetricParamGroup = "GetWithDefaultParameters";
        internal const string GetAzureRmAMetricFullParamGroup = "GetWithFullParameters";

        /// <summary>
        /// Default value of the timerange to search for metrics
        /// </summary>
        public static readonly TimeSpan DefaultTimeRange = TimeSpan.FromHours(1);

        /// <summary>
        /// Gets or sets the ResourceId parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The time grain of the query.")]
        [ValidateNotNullOrEmpty]
        public TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the aggregation type parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The aggregation type of the query")]
        [ValidateNotNullOrEmpty]
        public AggregationType? AggregationType { get; set; }

        /// <summary>
        /// Gets or sets the starttime parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The start time of the query")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end time of the query")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the metricnames parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric names of the query")]
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric names of the query")]
        [ValidateNotNullOrEmpty]
        [Alias("MetricNames")]
        public string[] MetricName { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public SwitchParameter DetailedOutput { get; set; }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "Get-AzureRmMetric",
                topic: "Parameter deprecation", 
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");

            // All the changes in this are intended to maintain this cmdlet behaving like in the previous version
            bool fullDetails = this.DetailedOutput.IsPresent;
            TimeSpan? interval = this.TimeGrain == default(TimeSpan) ? (TimeSpan?)null : this.TimeGrain;

            if (this.EndTime == default(DateTime))
            {
                this.EndTime = DateTime.UtcNow;
            }

            // StartTime defaults to EndTime - DefaultTimeRange  (NOTE: EndTime defaults to Now)
            if (this.StartTime == default(DateTime))
            {
                this.StartTime = this.EndTime.Subtract(DefaultTimeRange);
            }

            string timespan = string.Concat(this.StartTime.ToUniversalTime().ToString("O"), "/", this.EndTime.ToUniversalTime().ToString("O"));

            // If fullDetails is present full details of the records are displayed, otherwise only a summary of the records is displayed
            var response = this.MonitorClient.Metrics.List(
                resourceUri: this.ResourceId,
                timespan: timespan,
                interval: interval,
                metric: this.MetricName == null ? null : string.Join(",", this.MetricName),
                aggregation: this.AggregationType.HasValue ? this.AggregationType.Value.ToString() : null,
                resultType: ResultType.Data);

            var records = response.Value.Select(e => fullDetails ? new PSMetric(e) : new PSMetricNoDetails(e)).ToArray();
            WriteObject(sendToPipeline: records, enumerateCollection: true);
        }
    }
}
