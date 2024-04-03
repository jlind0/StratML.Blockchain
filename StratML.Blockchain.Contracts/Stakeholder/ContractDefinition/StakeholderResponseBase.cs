using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Stakeholder.ContractDefinition
{
    public partial class StakeholderResponseBase : StakeholderResponseBaseBase { }

    public class StakeholderResponseBaseBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint8", "stakeholderType", 2)]
        public virtual byte StakeholderType { get; set; }
        [Parameter("address[]", "roles", 3)]
        public virtual List<string> Roles { get; set; }
    }
}
