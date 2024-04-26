using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Goal.ContractDefinition
{
    public partial class GoalResponse : GoalResponseBase { }

    public class GoalResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual GoalResponseBased Base { get; set; }
        [Parameter("tuple[]", "stakeholders", 2)]
        public virtual List<StakeholderResponseBased> Stakeholders { get; set; }
        [Parameter("tuple[]", "objectives", 3)]
        public virtual List<ObjectiveResponseBased> Objectives { get; set; }
    }
}
