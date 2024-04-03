using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{
    public partial class OrganizationResponse : OrganizationResponseBase { }

    public class OrganizationResponseBase 
    {
        [Parameter("tuple", "base", 1)]
        public virtual OrganizationResponseBase Base { get; set; }
        [Parameter("tuple[]", "stakeholders", 2)]
        public virtual List<StakeholderResponse> Stakeholders { get; set; }
    }
}
