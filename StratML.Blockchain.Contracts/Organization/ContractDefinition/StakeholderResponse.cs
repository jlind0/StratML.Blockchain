using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Organization.ContractDefinition
{
    public partial class StakeholderResponse : StakeholderResponseBase { }

    public class StakeholderResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual StakeholderResponseBased Base { get; set; }
        [Parameter("tuple[]", "roles", 2)]
        public virtual List<RoleResponseBased> Roles { get; set; }
        [Parameter("string", "description", 3)]
        public virtual string Description { get; set; }
    }
}
