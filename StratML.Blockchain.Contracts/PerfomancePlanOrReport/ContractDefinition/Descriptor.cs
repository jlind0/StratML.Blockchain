using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class Descriptor : DescriptorBase { }

    public class DescriptorBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "value", 2)]
        public virtual string Value { get; set; }
    }
}
