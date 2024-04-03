using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace StratML.Contracts.AdministrativeInformation.ContractDefinition
{


    public partial class AdministrativeInformationDeployment : AdministrativeInformationDeploymentBase
    {
        public AdministrativeInformationDeployment() : base(BYTECODE) { }
        public AdministrativeInformationDeployment(string byteCode) : base(byteCode) { }
    }

    public class AdministrativeInformationDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162000a1438038062000a148339810160408190526200003391620000f0565b33806200005957604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b62000064816200008d565b50600184905560028390556003829055600462000082828262000266565b505050505062000332565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f805f806080858703121562000104575f80fd5b8451602080870151604088015160608901519397509095509350906001600160401b038082111562000134575f80fd5b818801915088601f83011262000148575f80fd5b8151818111156200015d576200015d620000dc565b604051601f8201601f19908116603f01168101908382118183101715620001885762000188620000dc565b816040528281528b86848701011115620001a0575f80fd5b5f93505b82841015620001c35784840186015181850187015292850192620001a4565b5f86848301015280965050505050505092959194509250565b600181811c90821680620001f157607f821691505b6020821081036200021057634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200026157805f5260205f20601f840160051c810160208510156200023d5750805b601f840160051c820191505b818110156200025e575f815560010162000249565b50505b505050565b81516001600160401b03811115620002825762000282620000dc565b6200029a81620002938454620001dc565b8462000216565b602080601f831160018114620002d0575f8415620002b85750858301515b5f19600386901b1c1916600185901b1785556200032a565b5f85815260208120601f198616915b828110156200030057888601518255948401946001909101908401620002df565b50858210156200031e57878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b6106d480620003405f395ff3fe608060405234801561000f575f80fd5b5060043610610090575f3560e01c8063812d0bc011610063578063812d0bc0146100d85780638da5cb5b146100ed578063c24a0f8b14610107578063e1272ecd14610110578063f2fde38b14610123575f80fd5b80630b97bc861461009457806311ec315e146100b057806367e828bf146100b9578063715018a6146100ce575b5f80fd5b61009d60015481565b6040519081526020015b60405180910390f35b61009d60035481565b6100c1610136565b6040516100a791906103f1565b6100d66101c2565b005b6100e06101d5565b6040516100a7919061040a565b5f546040516001600160a01b0390911681526020016100a7565b61009d60025481565b6100d661011e366004610470565b610293565b6100d6610131366004610537565b6102bd565b600480546101439061055d565b80601f016020809104026020016040519081016040528092919081815260200182805461016f9061055d565b80156101ba5780601f10610191576101008083540402835291602001916101ba565b820191905f5260205f20905b81548152906001019060200180831161019d57829003601f168201915b505050505081565b6101ca6102ff565b6101d35f61032b565b565b6101dd61037a565b6101e561037a565b3081526001546020820152600254604082015260035460608201526004805461020d9061055d565b80601f01602080910402602001604051908101604052809291908181526020018280546102399061055d565b80156102845780601f1061025b57610100808354040283529160200191610284565b820191905f5260205f20905b81548152906001019060200180831161026757829003601f168201915b50505050506080820152919050565b61029b6102ff565b60018490556002839055600382905560046102b682826105de565b5050505050565b6102c56102ff565b6001600160a01b0381166102f357604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b6102fc8161032b565b50565b5f546001600160a01b031633146101d35760405163118cdaa760e01b81523360048201526024016102ea565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b031681526020015f81526020015f81526020015f8152602001606081525090565b5f81518084525f5b818110156103d2576020818501810151868301820152016103b6565b505f602082860101526020601f19601f83011685010191505092915050565b602081525f61040360208301846103ae565b9392505050565b6020815260018060a01b0382511660208201526020820151604082015260408201516060820152606082015160808201525f608083015160a08084015261045460c08401826103ae565b949350505050565b634e487b7160e01b5f52604160045260245ffd5b5f805f8060808587031215610483575f80fd5b843593506020850135925060408501359150606085013567ffffffffffffffff808211156104af575f80fd5b818701915087601f8301126104c2575f80fd5b8135818111156104d4576104d461045c565b604051601f8201601f19908116603f011681019083821181831017156104fc576104fc61045c565b816040528281528a6020848701011115610514575f80fd5b826020860160208301375f60208483010152809550505050505092959194509250565b5f60208284031215610547575f80fd5b81356001600160a01b0381168114610403575f80fd5b600181811c9082168061057157607f821691505b60208210810361058f57634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156105d957805f5260205f20601f840160051c810160208510156105ba5750805b601f840160051c820191505b818110156102b6575f81556001016105c6565b505050565b815167ffffffffffffffff8111156105f8576105f861045c565b61060c81610606845461055d565b84610595565b602080601f83116001811461063f575f84156106285750858301515b5f19600386901b1c1916600185901b178555610696565b5f85815260208120601f198616915b8281101561066d5788860151825594840194600190910190840161064e565b508582101561068a57878501515f19600388901b60f8161c191681555b505060018460011b0185555b50505050505056fea2646970667358221220fc109b926d66e9a43bdbdf97e007b1e6f19cf525af41487f8af148e088d99b0d64736f6c63430008170033";
        public AdministrativeInformationDeploymentBase() : base(BYTECODE) { }
        public AdministrativeInformationDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "_startDate", 1)]
        public virtual BigInteger StartDate { get; set; }
        [Parameter("uint256", "_endDate", 2)]
        public virtual BigInteger EndDate { get; set; }
        [Parameter("uint256", "_publicationDate", 3)]
        public virtual BigInteger PublicationDate { get; set; }
        [Parameter("string", "_source", 4)]
        public virtual string Source { get; set; }
    }

    public partial class EndDateFunction : EndDateFunctionBase { }

    [Function("endDate", "uint256")]
    public class EndDateFunctionBase : FunctionMessage
    {

    }

    public partial class GetAdministrativeInformationResponseFunction : GetAdministrativeInformationResponseFunctionBase { }

    [Function("getAdministrativeInformationResponse", typeof(GetAdministrativeInformationResponseOutputDTO))]
    public class GetAdministrativeInformationResponseFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PublicationDateFunction : PublicationDateFunctionBase { }

    [Function("publicationDate", "uint256")]
    public class PublicationDateFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SourceFunction : SourceFunctionBase { }

    [Function("source", "string")]
    public class SourceFunctionBase : FunctionMessage
    {

    }

    public partial class StartDateFunction : StartDateFunctionBase { }

    [Function("startDate", "uint256")]
    public class StartDateFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdateAdministrativeInformationFunction : UpdateAdministrativeInformationFunctionBase { }

    [Function("updateAdministrativeInformation")]
    public class UpdateAdministrativeInformationFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_startDate", 1)]
        public virtual BigInteger StartDate { get; set; }
        [Parameter("uint256", "_endDate", 2)]
        public virtual BigInteger EndDate { get; set; }
        [Parameter("uint256", "_publicationDate", 3)]
        public virtual BigInteger PublicationDate { get; set; }
        [Parameter("string", "_source", 4)]
        public virtual string Source { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class OwnableInvalidOwnerError : OwnableInvalidOwnerErrorBase { }

    [Error("OwnableInvalidOwner")]
    public class OwnableInvalidOwnerErrorBase : IErrorDTO
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class OwnableUnauthorizedAccountError : OwnableUnauthorizedAccountErrorBase { }

    [Error("OwnableUnauthorizedAccount")]
    public class OwnableUnauthorizedAccountErrorBase : IErrorDTO
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class EndDateOutputDTO : EndDateOutputDTOBase { }

    [FunctionOutput]
    public class EndDateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetAdministrativeInformationResponseOutputDTO : GetAdministrativeInformationResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetAdministrativeInformationResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual AdministrativeInformationResponse ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PublicationDateOutputDTO : PublicationDateOutputDTOBase { }

    [FunctionOutput]
    public class PublicationDateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class SourceOutputDTO : SourceOutputDTOBase { }

    [FunctionOutput]
    public class SourceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StartDateOutputDTO : StartDateOutputDTOBase { }

    [FunctionOutput]
    public class StartDateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }




}
