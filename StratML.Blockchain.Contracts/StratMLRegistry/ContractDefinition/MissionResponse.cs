using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.StratMLRegistry.ContractDefinition
{
    public partial class MissionResponse : MissionResponseBase { }

    public class MissionResponseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "description", 2)]
        public virtual string Description { get; set; }
    }
}