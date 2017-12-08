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

using Microsoft.Azure.Management.Monitor.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the PSMetricNoDetails and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public class PSMetric : Metric
    {
        /// <summary>
        /// Hidding timeseries from the previous Metrics cmdlets for backwards compatibility and to avoid introducing a breaking change
        /// </summary>
        private new IList<TimeSeriesElement> Timeseries { get; set; }

        /// <summary>
        /// Creating the Data metric value collection that was changed in the new API (multi-dim metrics)
        /// </summary>
        public PSMetricValuesCollection Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSMetric class.
        /// </summary>
        /// <param name="metric">The input Metric object</param>
        public PSMetric(Metric metric)
            : base(name: new PSLocalizableString(metric.Name), unit: metric.Unit, id: metric.Id, type: metric.Type, timeseries: metric.Timeseries)
        {
            // Assuming that previous version metrics will be mapped to the Timeseries[0] element
            this.Data = metric.Timeseries.Count > 0 ? new PSMetricValuesCollection(metric.Timeseries[0].Data) : null;
        }
    }
}
