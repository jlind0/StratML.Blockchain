using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class StrategeticPlanCoreResponseBase : StrategeticPlanCoreResponseBaseBase { }

    public class StrategeticPlanCoreResponseBaseBase 
    {
        [Parameter("address[]", "organizations", 1)]
        public virtual List<string> Organizations { get; set; }
        [Parameter("tuple", "vision", 2)]
        public virtual VisionResponse Vision { get; set; }
        [Parameter("tuple", "mission", 3)]
        public virtual MissionResponse Mission { get; set; }
        [Parameter("tuple[]", "values", 4)]
        public virtual List<Value> Values { get; set; }
        [Parameter("address[]", "goals", 5)]
        public virtual List<string> Goals { get; set; }
    }
}
