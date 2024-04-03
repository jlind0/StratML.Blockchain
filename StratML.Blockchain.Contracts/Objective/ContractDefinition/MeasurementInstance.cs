using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Objective.ContractDefinition
{
    public partial class MeasurementInstance : MeasurementInstanceBase { }

    public class MeasurementInstanceBase 
    {
        [Parameter("tuple[]", "actualResults", 1)]
        public virtual List<ActualResult> ActualResults { get; set; }
        [Parameter("tuple[]", "targetResults", 2)]
        public virtual List<TargetResult> TargetResults { get; set; }
    }
}
