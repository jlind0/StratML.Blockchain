using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class Value : ValueBase { }

    public class ValueBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 2)]
        public virtual string Description { get; set; }
    }
}
