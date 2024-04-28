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
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162000cb038038062000cb0833981016040819052620000339162000112565b8433806200005a57604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b6200006581620000af565b50600180546001600160a01b0319166001600160a01b03929092169190911790556003849055600483905560058290556006620000a38282620002a6565b50505050505062000372565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f805f805f60a0868803121562000127575f80fd5b85516001600160a01b03811681146200013e575f80fd5b602087810151604089015160608a015160808b015194995091975095509350906001600160401b038082111562000173575f80fd5b818901915089601f83011262000187575f80fd5b8151818111156200019c576200019c620000fe565b604051601f8201601f19908116603f01168101908382118183101715620001c757620001c7620000fe565b816040528281528c86848701011115620001df575f80fd5b5f93505b82841015620002025784840186015181850187015292850192620001e3565b5f8684830101528096505050505050509295509295909350565b600181811c908216806200023157607f821691505b6020821081036200025057634e487b7160e01b5f52602260045260245ffd5b50919050565b601f821115620002a157805f5260205f20601f840160051c810160208510156200027d5750805b601f840160051c820191505b818110156200029e575f815560010162000289565b50505b505050565b81516001600160401b03811115620002c257620002c2620000fe565b620002da81620002d384546200021c565b8462000256565b602080601f83116001811462000310575f8415620002f85750858301515b5f19600386901b1c1916600185901b1785556200036a565b5f85815260208120601f198616915b8281101562000340578886015182559484019460019091019084016200031f565b50858210156200035e57878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b61093080620003805f395ff3fe608060405234801561000f575f80fd5b50600436106100cb575f3560e01c8063812d0bc011610088578063c24a0f8b11610063578063c24a0f8b14610189578063c9b87ee314610192578063e1272ecd146101b5578063f2fde38b146101c8575f80fd5b8063812d0bc0146101515780638da5cb5b14610166578063beaacc0b14610176575f80fd5b80630b97bc86146100cf57806311ec315e146100eb578063380cbbd7146100f457806367e828bf14610109578063715018a61461011e5780637b10399914610126575b5f80fd5b6100d860035481565b6040519081526020015b60405180910390f35b6100d860055481565b6101076101023660046105df565b6101db565b005b610111610280565b6040516100e2919061064f565b61010761030c565b600154610139906001600160a01b031681565b6040516001600160a01b0390911681526020016100e2565b61015961031f565b6040516100e29190610661565b5f546001600160a01b0316610139565b6101396101843660046106b3565b6103dd565b6100d860045481565b6101a56101a03660046105df565b610405565b60405190151581526020016100e2565b6101076101c33660046106de565b6104aa565b6101076101d63660046105df565b6104f1565b6101e3610530565b5f5b60025481101561023157816001600160a01b03166002828154811061020c5761020c6107a5565b5f918252602090912001546001600160a01b031603610229575050565b6001016101e5565b50600280546001810182555f919091527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180546001600160a01b0319166001600160a01b0383161790555b50565b6006805461028d906107b9565b80601f01602080910402602001604051908101604052809291908181526020018280546102b9906107b9565b80156103045780601f106102db57610100808354040283529160200191610304565b820191905f5260205f20905b8154815290600101906020018083116102e757829003601f168201915b505050505081565b610314610530565b61031d5f61055c565b565b6103276105ab565b61032f6105ab565b30815260035460208201526004546040820152600554606082015260068054610357906107b9565b80601f0160208091040260200160405190810160405280929190818152602001828054610383906107b9565b80156103ce5780601f106103a5576101008083540402835291602001916103ce565b820191905f5260205f20905b8154815290600101906020018083116103b157829003601f168201915b50505050506080820152919050565b600281815481106103ec575f80fd5b5f918252602090912001546001600160a01b0316905081565b6001545f906001600160a01b0380841691160361042457506001919050565b5f546001600160a01b03166001600160a01b0316826001600160a01b03160361044f57506001919050565b5f5b6002548110156104a257826001600160a01b031660028281548110610478576104786107a5565b5f918252602090912001546001600160a01b03160361049a5750600192915050565b600101610451565b505f92915050565b6104b333610405565b6104cf57604051621607ef60ea1b815260040160405180910390fd5b60038490556004839055600582905560066104ea828261083a565b5050505050565b6104f9610530565b6001600160a01b03811661052757604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b61027d8161055c565b5f546001600160a01b0316331461031d5760405163118cdaa760e01b815233600482015260240161051e565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b031681526020015f81526020015f81526020015f8152602001606081525090565b5f602082840312156105ef575f80fd5b81356001600160a01b0381168114610605575f80fd5b9392505050565b5f81518084525f5b8181101561063057602081850181015186830182015201610614565b505f602082860101526020601f19601f83011685010191505092915050565b602081525f610605602083018461060c565b6020815260018060a01b0382511660208201526020820151604082015260408201516060820152606082015160808201525f608083015160a0808401526106ab60c084018261060c565b949350505050565b5f602082840312156106c3575f80fd5b5035919050565b634e487b7160e01b5f52604160045260245ffd5b5f805f80608085870312156106f1575f80fd5b843593506020850135925060408501359150606085013567ffffffffffffffff8082111561071d575f80fd5b818701915087601f830112610730575f80fd5b813581811115610742576107426106ca565b604051601f8201601f19908116603f0116810190838211818310171561076a5761076a6106ca565b816040528281528a6020848701011115610782575f80fd5b826020860160208301375f60208483010152809550505050505092959194509250565b634e487b7160e01b5f52603260045260245ffd5b600181811c908216806107cd57607f821691505b6020821081036107eb57634e487b7160e01b5f52602260045260245ffd5b50919050565b601f82111561083557805f5260205f20601f840160051c810160208510156108165750805b601f840160051c820191505b818110156104ea575f8155600101610822565b505050565b815167ffffffffffffffff811115610854576108546106ca565b6108688161086284546107b9565b846107f1565b602080601f83116001811461089b575f84156108845750858301515b5f19600386901b1c1916600185901b1785556108f2565b5f85815260208120601f198616915b828110156108c9578886015182559484019460019091019084016108aa565b50858210156108e657878501515f19600388901b60f8161c191681555b505060018460011b0185555b50505050505056fea26469706673582212208fce5bc68cdc250b78f9b6849ad9e12d9b599db7d14bc2221f6144b20552d2cc64736f6c63430008170033";
        public AdministrativeInformationDeploymentBase() : base(BYTECODE) { }
        public AdministrativeInformationDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_registry", 1)]
        public virtual string Registry { get; set; }
        [Parameter("uint256", "_startDate", 2)]
        public virtual BigInteger StartDate { get; set; }
        [Parameter("uint256", "_endDate", 3)]
        public virtual BigInteger EndDate { get; set; }
        [Parameter("uint256", "_publicationDate", 4)]
        public virtual BigInteger PublicationDate { get; set; }
        [Parameter("string", "_source", 5)]
        public virtual string Source { get; set; }
    }

    public partial class AddSiblingFunction : AddSiblingFunctionBase { }

    [Function("addSibling")]
    public class AddSiblingFunctionBase : FunctionMessage
    {
        [Parameter("address", "sibling", 1)]
        public virtual string Sibling { get; set; }
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

    public partial class IsSiblingFunction : IsSiblingFunctionBase { }

    [Function("isSibling", "bool")]
    public class IsSiblingFunctionBase : FunctionMessage
    {
        [Parameter("address", "sibling", 1)]
        public virtual string Sibling { get; set; }
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

    public partial class RegistryFunction : RegistryFunctionBase { }

    [Function("registry", "address")]
    public class RegistryFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SiblingsFunction : SiblingsFunctionBase { }

    [Function("siblings", "address")]
    public class SiblingsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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

    public partial class AuthorizationErrorError : AuthorizationErrorErrorBase { }
    [Error("AuthorizationError")]
    public class AuthorizationErrorErrorBase : IErrorDTO
    {
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

    public partial class IsSiblingOutputDTO : IsSiblingOutputDTOBase { }

    [FunctionOutput]
    public class IsSiblingOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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

    public partial class RegistryOutputDTO : RegistryOutputDTOBase { }

    [FunctionOutput]
    public class RegistryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class SiblingsOutputDTO : SiblingsOutputDTOBase { }

    [FunctionOutput]
    public class SiblingsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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
