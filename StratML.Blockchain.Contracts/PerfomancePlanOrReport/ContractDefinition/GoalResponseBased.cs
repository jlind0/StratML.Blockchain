using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class GoalResponseBased : GoalResponseBasedBase { }

    public class GoalResponseBasedBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 3)]
        public virtual string Description { get; set; }
        [Parameter("string", "sequenceIndicator", 4)]
        public virtual string SequenceIndicator { get; set; }
        [Parameter("address[]", "stakeholders", 5)]
        public virtual List<string> Stakeholders { get; set; }
        [Parameter("string", "otherInformation", 6)]
        public virtual string OtherInformation { get; set; }
        [Parameter("address[]", "objectives", 7)]
        public virtual List<string> Objectives { get; set; }
    }
}
