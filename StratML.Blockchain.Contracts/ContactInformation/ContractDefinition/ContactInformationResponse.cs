using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace StratML.Contracts.ContactInformation.ContractDefinition
{
    public partial class ContactInformationResponse : ContactInformationResponseBase { }

    public class ContactInformationResponseBase 
    {
        [Parameter("address", "identifier", 1)]
        public virtual string Identifier { get; set; }
        [Parameter("string", "givenName", 2)]
        public virtual string GivenName { get; set; }
        [Parameter("string", "surname", 3)]
        public virtual string Surname { get; set; }
        [Parameter("string", "phoneNumber", 4)]
        public virtual string PhoneNumber { get; set; }
        [Parameter("string", "emailAddress", 5)]
        public virtual string EmailAddress { get; set; }
    }
}
