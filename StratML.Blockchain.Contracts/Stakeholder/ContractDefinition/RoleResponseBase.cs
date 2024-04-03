using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Stakeholder.ContractDefinition
{
    public partial class RoleResponseBase : RoleResponseBaseBase { }

    public class RoleResponseBaseBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 2)]
        public virtual string Description { get; set; }
        [Parameter("uint8", "roleType", 3)]
        public virtual byte RoleType { get; set; }
        [Parameter("address[]", "stakeholders", 4)]
        public virtual List<string> Stakeholders { get; set; }
    }
}
