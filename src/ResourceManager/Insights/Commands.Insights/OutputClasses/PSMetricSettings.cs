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
using System.Text;
using System.Xml;
using Microsoft.Azure.Commands.Insights.Diagnostics;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the MetricSettings
    /// </summary>
    public class PSMetricSettings : MetricSettings
    {
        /// <summary>
        /// Initializes a new instance of the PSMetricSettings class.
        /// </summary>
        public PSMetricSettings(MetricSettings metricSettings)
        {
            this.Enabled = metricSettings.Enabled;
            this.TimeGrain = metricSettings.TimeGrain;
            this.Category = metricSettings.Category;

            if (!this.TimeGrain.HasValue)
            {
                // Backward compatibility. The new API returns not timegrains.
                // Moving forward all metrics are generated with 1min timegrain,
                // so we can assume 1min timegrain when none are returned.
                this.TimeGrain = TimeSpan.FromMinutes(1);
            }

            this.RetentionPolicy = metricSettings.RetentionPolicy;
        }

        /// <summary>
        /// A string representation of the PSMetricSettings
        /// </summary>
        /// <returns>A string representation of the PSMetricSettings</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Enabled         : " + Enabled);
            output.AppendLine("TimeGrain       : " + XmlConvert.ToString(TimeGrain.Value));
            output.Append("RetentionPolicy : " + RetentionPolicy.ToString());
            return output.ToString();
        }
    }
}
