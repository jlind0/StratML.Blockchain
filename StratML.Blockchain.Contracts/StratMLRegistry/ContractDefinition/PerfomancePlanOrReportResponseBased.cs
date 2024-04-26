using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.StratMLRegistry.ContractDefinition
{
    public partial class PerfomancePlanOrReportResponseBased : PerfomancePlanOrReportResponseBasedBase { }

    public class PerfomancePlanOrReportResponseBasedBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 3)]
        public virtual string Description { get; set; }
        [Parameter("string", "otherInformation", 4)]
        public virtual string OtherInformation { get; set; }
        [Parameter("tuple", "strategeticPlanCore", 5)]
        public virtual StrategeticPlanCoreResponseBased StrategeticPlanCore { get; set; }
        [Parameter("tuple", "administrativeInformation", 6)]
        public virtual AdministrativeInformationResponse AdministrativeInformation { get; set; }
        [Parameter("tuple", "submitter", 7)]
        public virtual ContactInformationResponse Submitter { get; set; }
        [Parameter("uint8", "reportType", 8)]
        public virtual byte ReportType { get; set; }
    }
}
