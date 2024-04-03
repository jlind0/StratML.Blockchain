using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerformanceIndicator.ContractDefinition
{
    public partial class Reference : ReferenceBase { }

    public class ReferenceBase 
    {
        [Parameter("uint8", "entityType", 1)]
        public virtual byte EntityType { get; set; }
        [Parameter("address", "identifier", 2)]
        public virtual string Identifier { get; set; }
    }
}
