using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Goal.ContractDefinition
{
    public partial class StakeholderResponseBased : StakeholderResponseBasedBase { }

    public class StakeholderResponseBasedBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("uint8", "stakeholderType", 3)]
        public virtual byte StakeholderType { get; set; }
        [Parameter("address[]", "roles", 4)]
        public virtual List<string> Roles { get; set; }
    }
}
