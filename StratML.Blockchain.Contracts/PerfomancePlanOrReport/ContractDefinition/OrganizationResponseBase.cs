using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class OrganizationResponseBase : OrganizationResponseBaseBase { }

    public class OrganizationResponseBaseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 3)]
        public virtual string Description { get; set; }
        [Parameter("string", "acryonym", 4)]
        public virtual string Acryonym { get; set; }
        [Parameter("tuple[]", "stakeholders", 5)]
        public virtual List<StakeholderResponseBase> Stakeholders { get; set; }
    }
}
