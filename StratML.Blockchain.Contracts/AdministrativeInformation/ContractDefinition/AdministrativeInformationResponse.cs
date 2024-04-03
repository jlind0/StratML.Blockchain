using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.AdministrativeInformation.ContractDefinition
{
    public partial class AdministrativeInformationResponse : AdministrativeInformationResponseBase { }

    public class AdministrativeInformationResponseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("uint256", "startDate", 2)]
        public virtual BigInteger StartDate { get; set; }
        [Parameter("uint256", "endDate", 3)]
        public virtual BigInteger EndDate { get; set; }
        [Parameter("uint256", "publicationDate", 4)]
        public virtual BigInteger PublicationDate { get; set; }
        [Parameter("string", "source", 5)]
        public virtual string Source { get; set; }
    }
}
