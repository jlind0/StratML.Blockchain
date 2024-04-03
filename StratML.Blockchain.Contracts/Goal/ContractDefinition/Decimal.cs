using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Goal.ContractDefinition
{
    public partial class Decimal : DecimalBase { }

    public class DecimalBase 
    {
        [Parameter("int64", "value", 1)]
        public virtual long Value { get; set; }
        [Parameter("uint256", "precision", 2)]
        public virtual BigInteger Precision { get; set; }
    }
}
