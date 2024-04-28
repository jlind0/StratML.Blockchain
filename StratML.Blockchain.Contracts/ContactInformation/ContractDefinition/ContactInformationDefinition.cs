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

namespace StratML.Contracts.ContactInformation.ContractDefinition
{


    public partial class ContactInformationDeployment : ContactInformationDeploymentBase
    {
        public ContactInformationDeployment() : base(BYTECODE) { }
        public ContactInformationDeployment(string byteCode) : base(byteCode) { }
    }

    public class ContactInformationDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162000fb738038062000fb78339810160408190526200003391620001dd565b8433806200005a57604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b6200006581620000cd565b50600180546001600160a01b0319166001600160a01b0392909216919091179055600362000094858262000338565b506004620000a3848262000338565b506005620000b2838262000338565b506006620000c1828262000338565b50505050505062000404565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f82601f83011262000140575f80fd5b81516001600160401b03808211156200015d576200015d6200011c565b604051601f8301601f19908116603f011681019082821181831017156200018857620001886200011c565b8160405283815260209250866020858801011115620001a5575f80fd5b5f91505b83821015620001c85785820183015181830184015290820190620001a9565b5f602085830101528094505050505092915050565b5f805f805f60a08688031215620001f2575f80fd5b85516001600160a01b038116811462000209575f80fd5b60208701519095506001600160401b038082111562000226575f80fd5b6200023489838a0162000130565b955060408801519150808211156200024a575f80fd5b6200025889838a0162000130565b945060608801519150808211156200026e575f80fd5b6200027c89838a0162000130565b9350608088015191508082111562000292575f80fd5b50620002a18882890162000130565b9150509295509295909350565b600181811c90821680620002c357607f821691505b602082108103620002e257634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200033357805f5260205f20601f840160051c810160208510156200030f5750805b601f840160051c820191505b8181101562000330575f81556001016200031b565b50505b505050565b81516001600160401b038111156200035457620003546200011c565b6200036c81620003658454620002ae565b84620002e8565b602080601f831160018114620003a2575f84156200038a5750858301515b5f19600386901b1c1916600185901b178555620003fc565b5f85815260208120601f198616915b82811015620003d257888601518255948401946001909101908401620003b1565b5085821015620003f057878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b610ba580620004125f395ff3fe608060405234801561000f575f80fd5b50600436106100cb575f3560e01c80638da5cb5b11610088578063beaacc0b11610063578063beaacc0b1461017d578063c9b87ee314610190578063ee51ae55146101b3578063f2fde38b146101bb575f80fd5b80638da5cb5b14610150578063a14aba2114610160578063b38fee9214610175575f80fd5b8063380cbbd7146100cf578063715018a6146100e4578063747f3380146100ec5780637853512c1461010a5780637b10399914610112578063809913471461013d575b5f80fd5b6100e26100dd3660046107af565b6101ce565b005b6100e2610273565b6100f4610286565b604051610101919061081f565b60405180910390f35b6100f4610312565b600154610125906001600160a01b031681565b6040516001600160a01b039091168152602001610101565b6100e261014b3660046108ce565b61031f565b5f546001600160a01b0316610125565b61016861037e565b6040516101019190610974565b6100f46105d7565b61012561018b366004610a03565b6105e4565b6101a361019e3660046107af565b61060c565b6040519015158152602001610101565b6100f46106b1565b6100e26101c93660046107af565b6106be565b6101d66106fd565b5f5b60025481101561022457816001600160a01b0316600282815481106101ff576101ff610a1a565b5f918252602090912001546001600160a01b03160361021c575050565b6001016101d8565b50600280546001810182555f919091527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180546001600160a01b0319166001600160a01b0383161790555b50565b61027b6106fd565b6102845f610729565b565b6005805461029390610a2e565b80601f01602080910402602001604051908101604052809291908181526020018280546102bf90610a2e565b801561030a5780601f106102e15761010080835404028352916020019161030a565b820191905f5260205f20905b8154815290600101906020018083116102ed57829003601f168201915b505050505081565b6003805461029390610a2e565b6103283361060c565b61034457604051621607ef60ea1b815260040160405180910390fd5b60036103508582610aaf565b50600461035d8482610aaf565b50600561036a8382610aaf565b5060066103778282610aaf565b5050505050565b610386610778565b61038e610778565b3081526003805461039e90610a2e565b80601f01602080910402602001604051908101604052809291908181526020018280546103ca90610a2e565b80156104155780601f106103ec57610100808354040283529160200191610415565b820191905f5260205f20905b8154815290600101906020018083116103f857829003601f168201915b505050505081602001819052506004805461042f90610a2e565b80601f016020809104026020016040519081016040528092919081815260200182805461045b90610a2e565b80156104a65780601f1061047d576101008083540402835291602001916104a6565b820191905f5260205f20905b81548152906001019060200180831161048957829003601f168201915b50505050508160400181905250600580546104c090610a2e565b80601f01602080910402602001604051908101604052809291908181526020018280546104ec90610a2e565b80156105375780601f1061050e57610100808354040283529160200191610537565b820191905f5260205f20905b81548152906001019060200180831161051a57829003601f168201915b505050505081606001819052506006805461055190610a2e565b80601f016020809104026020016040519081016040528092919081815260200182805461057d90610a2e565b80156105c85780601f1061059f576101008083540402835291602001916105c8565b820191905f5260205f20905b8154815290600101906020018083116105ab57829003601f168201915b50505050506080820152919050565b6004805461029390610a2e565b600281815481106105f3575f80fd5b5f918252602090912001546001600160a01b0316905081565b6001545f906001600160a01b0380841691160361062b57506001919050565b5f546001600160a01b03166001600160a01b0316826001600160a01b03160361065657506001919050565b5f5b6002548110156106a957826001600160a01b03166002828154811061067f5761067f610a1a565b5f918252602090912001546001600160a01b0316036106a15750600192915050565b600101610658565b505f92915050565b6006805461029390610a2e565b6106c66106fd565b6001600160a01b0381166106f457604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b61027081610729565b5f546001600160a01b031633146102845760405163118cdaa760e01b81523360048201526024016106eb565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b03168152602001606081526020016060815260200160608152602001606081525090565b5f602082840312156107bf575f80fd5b81356001600160a01b03811681146107d5575f80fd5b9392505050565b5f81518084525f5b81811015610800576020818501810151868301820152016107e4565b505f602082860101526020601f19601f83011685010191505092915050565b602081525f6107d560208301846107dc565b634e487b7160e01b5f52604160045260245ffd5b5f82601f830112610854575f80fd5b813567ffffffffffffffff8082111561086f5761086f610831565b604051601f8301601f19908116603f0116810190828211818310171561089757610897610831565b816040528381528660208588010111156108af575f80fd5b836020870160208301375f602085830101528094505050505092915050565b5f805f80608085870312156108e1575f80fd5b843567ffffffffffffffff808211156108f8575f80fd5b61090488838901610845565b95506020870135915080821115610919575f80fd5b61092588838901610845565b9450604087013591508082111561093a575f80fd5b61094688838901610845565b9350606087013591508082111561095b575f80fd5b5061096887828801610845565b91505092959194509250565b602080825282516001600160a01b03168282015282015160a060408301525f906109a160c08401826107dc565b90506040840151601f19808584030160608601526109bf83836107dc565b925060608601519150808584030160808601526109dc83836107dc565b925060808601519150808584030160a0860152506109fa82826107dc565b95945050505050565b5f60208284031215610a13575f80fd5b5035919050565b634e487b7160e01b5f52603260045260245ffd5b600181811c90821680610a4257607f821691505b602082108103610a6057634e487b7160e01b5f52602260045260245ffd5b50919050565b601f821115610aaa57805f5260205f20601f840160051c81016020851015610a8b5750805b601f840160051c820191505b81811015610377575f8155600101610a97565b505050565b815167ffffffffffffffff811115610ac957610ac9610831565b610add81610ad78454610a2e565b84610a66565b602080601f831160018114610b10575f8415610af95750858301515b5f19600386901b1c1916600185901b178555610b67565b5f85815260208120601f198616915b82811015610b3e57888601518255948401946001909101908401610b1f565b5085821015610b5b57878501515f19600388901b60f8161c191681555b505060018460011b0185555b50505050505056fea26469706673582212202e0a927de63988542519c0670b9ca39e672cde5292288e4f49a5a2d490c319f364736f6c63430008170033";
        public ContactInformationDeploymentBase() : base(BYTECODE) { }
        public ContactInformationDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_registry", 1)]
        public virtual string Registry { get; set; }
        [Parameter("string", "_givenName", 2)]
        public virtual string GivenName { get; set; }
        [Parameter("string", "_surname", 3)]
        public virtual string Surname { get; set; }
        [Parameter("string", "_phoneNumber", 4)]
        public virtual string PhoneNumber { get; set; }
        [Parameter("string", "_emailAddress", 5)]
        public virtual string EmailAddress { get; set; }
    }

    public partial class AddSiblingFunction : AddSiblingFunctionBase { }

    [Function("addSibling")]
    public class AddSiblingFunctionBase : FunctionMessage
    {
        [Parameter("address", "sibling", 1)]
        public virtual string Sibling { get; set; }
    }

    public partial class EmailAddressFunction : EmailAddressFunctionBase { }

    [Function("emailAddress", "string")]
    public class EmailAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetContactInformationResponseFunction : GetContactInformationResponseFunctionBase { }

    [Function("getContactInformationResponse", typeof(GetContactInformationResponseOutputDTO))]
    public class GetContactInformationResponseFunctionBase : FunctionMessage
    {

    }

    public partial class GivenNameFunction : GivenNameFunctionBase { }

    [Function("givenName", "string")]
    public class GivenNameFunctionBase : FunctionMessage
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

    public partial class PhoneNumberFunction : PhoneNumberFunctionBase { }

    [Function("phoneNumber", "string")]
    public class PhoneNumberFunctionBase : FunctionMessage
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

    public partial class SurnameFunction : SurnameFunctionBase { }

    [Function("surname", "string")]
    public class SurnameFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdateContactInformationFunction : UpdateContactInformationFunctionBase { }

    [Function("updateContactInformation")]
    public class UpdateContactInformationFunctionBase : FunctionMessage
    {
        [Parameter("string", "_givenName", 1)]
        public virtual string GivenName { get; set; }
        [Parameter("string", "_surname", 2)]
        public virtual string Surname { get; set; }
        [Parameter("string", "_phoneNumber", 3)]
        public virtual string PhoneNumber { get; set; }
        [Parameter("string", "_emailAddress", 4)]
        public virtual string EmailAddress { get; set; }
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



    public partial class EmailAddressOutputDTO : EmailAddressOutputDTOBase { }

    [FunctionOutput]
    public class EmailAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetContactInformationResponseOutputDTO : GetContactInformationResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetContactInformationResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual ContactInformationResponse ReturnValue1 { get; set; }
    }

    public partial class GivenNameOutputDTO : GivenNameOutputDTOBase { }

    [FunctionOutput]
    public class GivenNameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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

    public partial class PhoneNumberOutputDTO : PhoneNumberOutputDTOBase { }

    [FunctionOutput]
    public class PhoneNumberOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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

    public partial class SurnameOutputDTO : SurnameOutputDTOBase { }

    [FunctionOutput]
    public class SurnameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
