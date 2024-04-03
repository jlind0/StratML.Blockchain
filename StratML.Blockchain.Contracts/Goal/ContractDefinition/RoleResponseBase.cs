using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.Goal.ContractDefinition
{
    public partial class RoleResponseBase : RoleResponseBaseBase { }

    public class RoleResponseBaseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 3)]
        public virtual string Description { get; set; }
        [Parameter("uint8[]", "roleTypes", 4)]
        public virtual List<byte> RoleTypes { get; set; }
        [Parameter("address[]", "stakeholders", 5)]
        public virtual List<string> Stakeholders { get; set; }
    }
}
