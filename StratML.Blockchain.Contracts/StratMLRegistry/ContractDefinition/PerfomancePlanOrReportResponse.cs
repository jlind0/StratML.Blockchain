using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.StratMLRegistry.ContractDefinition
{
    public partial class PerfomancePlanOrReportResponse : PerfomancePlanOrReportResponseBase { }

    public class PerfomancePlanOrReportResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual PerfomancePlanOrReportResponseBased Base { get; set; }
        [Parameter("tuple", "strategeticPlanCore", 2)]
        public virtual StrategeticPlanCoreResponse StrategeticPlanCore { get; set; }
    }
}
