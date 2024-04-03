using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Stakeholder.ContractDefinition
{
    public partial class StakeholderResponse : StakeholderResponseBase { }

    public class StakeholderResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual StakeholderResponseBase Base { get; set; }
        [Parameter("tuple[]", "roles", 2)]
        public virtual List<RoleResponseBase> Roles { get; set; }
    }
}
