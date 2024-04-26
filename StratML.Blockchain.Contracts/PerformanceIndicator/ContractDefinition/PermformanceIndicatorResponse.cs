using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.PerformanceIndicator.ContractDefinition
{
    public partial class PermformanceIndicatorResponse : PermformanceIndicatorResponseBase { }

    public class PermformanceIndicatorResponseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "seqeunceIndicator", 2)]
        public virtual string SeqeunceIndicator { get; set; }
        [Parameter("string", "measurementDimension", 3)]
        public virtual string MeasurementDimension { get; set; }
        [Parameter("string", "unitOfMeasurement", 4)]
        public virtual string UnitOfMeasurement { get; set; }
        [Parameter("tuple[]", "relationships", 5)]
        public virtual List<RelationshipResponse> Relationships { get; set; }
        [Parameter("tuple[]", "measurementInstances", 6)]
        public virtual List<MeasurementInstance> MeasurementInstances { get; set; }
        [Parameter("string", "otherInformation", 7)]
        public virtual string OtherInformation { get; set; }
        [Parameter("uint8", "vauleChangeStage", 8)]
        public virtual byte VauleChangeStage { get; set; }
        [Parameter("uint8", "perfomanceIndicator", 9)]
        public virtual byte PerfomanceIndicator { get; set; }
    }
}
