// <auto-generated>
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// 
// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.
// 
// For documentation on code generator please visit
//   https://aka.ms/nrp-code-generation
// Please contact wanrpdev@microsoft.com if you need to make changes to this file.
// </auto-generated>

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteTable", SupportsShouldProcess = true), OutputType(typeof(PSRouteTable))]
    public class SetAzureRouteTableCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The route table")]
        public PSRouteTable RouteTable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.RouteTables.Get(this.RouteTable.ResourceGroupName, this.RouteTable.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if(!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vRouteTableModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RouteTable>(this.RouteTable);
            vRouteTableModel.Tags = TagsConversionHelper.CreateTagDictionary(this.RouteTable.Tag, validate: true);

            // Execute the PUT RouteTable call
            this.NetworkClient.NetworkManagementClient.RouteTables.CreateOrUpdate(this.RouteTable.ResourceGroupName, this.RouteTable.Name, vRouteTableModel);

            var getRouteTable = this.NetworkClient.NetworkManagementClient.RouteTables.Get(this.RouteTable.ResourceGroupName, this.RouteTable.Name);
            var psRouteTable = NetworkResourceManagerProfile.Mapper.Map<PSRouteTable>(getRouteTable);
            psRouteTable.ResourceGroupName = this.RouteTable.ResourceGroupName;
            psRouteTable.Tag = TagsConversionHelper.CreateTagHashtable(getRouteTable.Tags);
            WriteObject(psRouteTable, true);
        }
    }
}
