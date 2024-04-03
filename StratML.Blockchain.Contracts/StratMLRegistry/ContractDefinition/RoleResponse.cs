using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.StratMLRegistry.ContractDefinition
{
    public partial class RoleResponse : RoleResponseBase { }

    public class RoleResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual RoleResponseBase Base { get; set; }
        [Parameter("tuple[]", "stakeholders", 2)]
        public virtual List<StakeholderResponseBase> Stakeholders { get; set; }
    }
}
