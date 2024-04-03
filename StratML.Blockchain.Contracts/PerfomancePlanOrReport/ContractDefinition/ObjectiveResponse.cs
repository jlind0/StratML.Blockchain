using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class ObjectiveResponse : ObjectiveResponseBase { }

    public class ObjectiveResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual ObjectiveResponseBase Base { get; set; }
        [Parameter("tuple[]", "stakeholders", 2)]
        public virtual List<StakeholderResponse> Stakeholders { get; set; }
    }
}
