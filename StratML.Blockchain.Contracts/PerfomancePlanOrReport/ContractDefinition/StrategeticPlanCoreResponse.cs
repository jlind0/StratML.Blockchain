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
        public virtual StrategeticPlanCoreResponseBase Base { get; set; }
        [Parameter("tuple[]", "organizations", 2)]
        public virtual List<OrganizationResponseBase> Organizations { get; set; }
        [Parameter("tuple[]", "goals", 3)]
        public virtual List<GoalResponseBase> Goals { get; set; }
    }
}
