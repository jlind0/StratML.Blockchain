using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class RelationshipResponse : RelationshipResponseBase { }

    public class RelationshipResponseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("tuple[]", "references", 2)]
        public virtual List<Reference> References { get; set; }
        [Parameter("string", "name", 3)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 4)]
        public virtual string Description { get; set; }
        [Parameter("uint8", "relationshipType", 5)]
        public virtual byte RelationshipType { get; set; }
    }
}
