using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class StrategeticPlanCoreResponse : StrategeticPlanCoreResponseBase { }

    public class StrategeticPlanCoreResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual StrategeticPlanCoreResponseBased Base { get; set; }
        [Parameter("tuple[]", "organizations", 2)]
        public virtual List<OrganizationResponseBased> Organizations { get; set; }
        [Parameter("tuple[]", "goals", 3)]
        public virtual List<GoalResponseBased> Goals { get; set; }
    }
}
