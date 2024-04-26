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

namespace StratML.Contracts.Mission.ContractDefinition
{


    public partial class MissionDeployment : MissionDeploymentBase
    {
        public MissionDeployment() : base(BYTECODE) { }
        public MissionDeployment(string byteCode) : base(byteCode) { }
    }

    public class MissionDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162000bac38038062000bac833981016040819052620000339162000100565b8133806200005a57604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b62000065816200009d565b50600180546001600160a01b0319166001600160a01b0392909216919091179055600362000094828262000278565b50505062000344565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f806040838503121562000112575f80fd5b82516001600160a01b038116811462000129575f80fd5b602084810151919350906001600160401b038082111562000148575f80fd5b818601915086601f8301126200015c575f80fd5b815181811115620001715762000171620000ec565b604051601f8201601f19908116603f011681019083821181831017156200019c576200019c620000ec565b816040528281528986848701011115620001b4575f80fd5b5f93505b82841015620001d75784840186015181850187015292850192620001b8565b5f8684830101528096505050505050509250929050565b600181811c908216806200020357607f821691505b6020821081036200022257634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200027357805f5260205f20601f840160051c810160208510156200024f5750805b601f840160051c820191505b8181101562000270575f81556001016200025b565b50505b505050565b81516001600160401b03811115620002945762000294620000ec565b620002ac81620002a58454620001ee565b8462000228565b602080601f831160018114620002e2575f8415620002ca5750858301515b5f19600386901b1c1916600185901b1785556200033c565b5f85815260208120601f198616915b828110156200031257888601518255948401946001909101908401620002f1565b50858210156200033057878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b61085a80620003525f395ff3fe608060405234801561000f575f80fd5b506004361061009b575f3560e01c80638da5cb5b116100635780638da5cb5b1461011a578063beaacc0b1461012a578063c4dd3e191461013d578063c9b87ee314610150578063f2fde38b14610173575f80fd5b8063338a17941461009f578063380cbbd7146100bd578063715018a6146100d25780637284e416146100da5780637b103999146100ef575b5f80fd5b6100a7610186565b6040516100b49190610583565b60405180910390f35b6100d06100cb3660046105b7565b610240565b005b6100d06102e5565b6100e26102f8565b6040516100b491906105e4565b600154610102906001600160a01b031681565b6040516001600160a01b0390911681526020016100b4565b5f546001600160a01b0316610102565b6101026101383660046105f6565b610384565b6100d061014b366004610621565b6103ac565b61016361015e3660046105b7565b6103e1565b60405190151581526020016100b4565b6100d06101813660046105b7565b610486565b6040805180820182525f8152606060208083018290528351808501909452830152308252600380549192916101ba906106cc565b80601f01602080910402602001604051908101604052809291908181526020018280546101e6906106cc565b80156102315780601f1061020857610100808354040283529160200191610231565b820191905f5260205f20905b81548152906001019060200180831161021457829003601f168201915b50505050506020820152919050565b6102486104c5565b5f5b60025481101561029657816001600160a01b03166002828154811061027157610271610704565b5f918252602090912001546001600160a01b03160361028e575050565b60010161024a565b50600280546001810182555f919091527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180546001600160a01b0319166001600160a01b0383161790555b50565b6102ed6104c5565b6102f65f6104f1565b565b60038054610305906106cc565b80601f0160208091040260200160405190810160405280929190818152602001828054610331906106cc565b801561037c5780601f106103535761010080835404028352916020019161037c565b820191905f5260205f20905b81548152906001019060200180831161035f57829003601f168201915b505050505081565b60028181548110610393575f80fd5b5f918252602090912001546001600160a01b0316905081565b6103b5336103e1565b6103d157604051621607ef60ea1b815260040160405180910390fd5b60036103dd8282610764565b5050565b6001545f906001600160a01b0380841691160361040057506001919050565b5f546001600160a01b03166001600160a01b0316826001600160a01b03160361042b57506001919050565b5f5b60025481101561047e57826001600160a01b03166002828154811061045457610454610704565b5f918252602090912001546001600160a01b0316036104765750600192915050565b60010161042d565b505f92915050565b61048e6104c5565b6001600160a01b0381166104bc57604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b6102e2816104f1565b5f546001600160a01b031633146102f65760405163118cdaa760e01b81523360048201526024016104b3565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b5f81518084525f5b8181101561056457602081850181015186830182015201610548565b505f602082860101526020601f19601f83011685010191505092915050565b602080825282516001600160a01b0316828201528201516040808301525f906105af6060840182610540565b949350505050565b5f602082840312156105c7575f80fd5b81356001600160a01b03811681146105dd575f80fd5b9392505050565b602081525f6105dd6020830184610540565b5f60208284031215610606575f80fd5b5035919050565b634e487b7160e01b5f52604160045260245ffd5b5f60208284031215610631575f80fd5b813567ffffffffffffffff80821115610648575f80fd5b818401915084601f83011261065b575f80fd5b81358181111561066d5761066d61060d565b604051601f8201601f19908116603f011681019083821181831017156106955761069561060d565b816040528281528760208487010111156106ad575f80fd5b826020860160208301375f928101602001929092525095945050505050565b600181811c908216806106e057607f821691505b6020821081036106fe57634e487b7160e01b5f52602260045260245ffd5b50919050565b634e487b7160e01b5f52603260045260245ffd5b601f82111561075f57805f5260205f20601f840160051c8101602085101561073d5750805b601f840160051c820191505b8181101561075c575f8155600101610749565b50505b505050565b815167ffffffffffffffff81111561077e5761077e61060d565b6107928161078c84546106cc565b84610718565b602080601f8311600181146107c5575f84156107ae5750858301515b5f19600386901b1c1916600185901b17855561081c565b5f85815260208120601f198616915b828110156107f3578886015182559484019460019091019084016107d4565b508582101561081057878501515f19600388901b60f8161c191681555b505060018460011b0185555b50505050505056fea2646970667358221220e1d0f9e201168ea26e5ed10d5073482acce31f52e1fbb1f8e341785e84460f4764736f6c63430008170033";
        public MissionDeploymentBase() : base(BYTECODE) { }
        public MissionDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_registry", 1)]
        public virtual string Registry { get; set; }
        [Parameter("string", "_description", 2)]
        public virtual string Description { get; set; }
    }

    public partial class AddSiblingFunction : AddSiblingFunctionBase { }

    [Function("addSibling")]
    public class AddSiblingFunctionBase : FunctionMessage
    {
        [Parameter("address", "sibling", 1)]
        public virtual string Sibling { get; set; }
    }

    public partial class DescriptionFunction : DescriptionFunctionBase { }

    [Function("description", "string")]
    public class DescriptionFunctionBase : FunctionMessage
    {

    }

    public partial class GetMissionResponseFunction : GetMissionResponseFunctionBase { }

    [Function("getMissionResponse", typeof(GetMissionResponseOutputDTO))]
    public class GetMissionResponseFunctionBase : FunctionMessage
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

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdateMissionFunction : UpdateMissionFunctionBase { }

    [Function("updateMission")]
    public class UpdateMissionFunctionBase : FunctionMessage
    {
        [Parameter("string", "_description", 1)]
        public virtual string Description { get; set; }
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



    public partial class DescriptionOutputDTO : DescriptionOutputDTOBase { }

    [FunctionOutput]
    public class DescriptionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetMissionResponseOutputDTO : GetMissionResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetMissionResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual MissionResponse ReturnValue1 { get; set; }
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




}
