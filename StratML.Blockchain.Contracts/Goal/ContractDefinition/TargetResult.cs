using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Goal.ContractDefinition
{
    public partial class TargetResult : TargetResultBase { }

    public class TargetResultBase 
    {
        [Parameter("uint256", "startDate", 1)]
        public virtual BigInteger StartDate { get; set; }
        [Parameter("uint256", "endDate", 2)]
        public virtual BigInteger EndDate { get; set; }
        [Parameter("tuple", "numberOfUnits", 3)]
        public virtual Decimal NumberOfUnits { get; set; }
        [Parameter("tuple", "descriptor", 4)]
        public virtual Descriptor Descriptor { get; set; }
        [Parameter("string", "description", 5)]
        public virtual string Description { get; set; }
    }
}
