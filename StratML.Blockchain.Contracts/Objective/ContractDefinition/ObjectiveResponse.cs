using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Objective.ContractDefinition
{
    public partial class ObjectiveResponse : ObjectiveResponseBase { }

    public class ObjectiveResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual ObjectiveResponseBased Base { get; set; }
        [Parameter("tuple[]", "stakeholders", 2)]
        public virtual List<StakeholderResponseBased> Stakeholders { get; set; }
    }
}
