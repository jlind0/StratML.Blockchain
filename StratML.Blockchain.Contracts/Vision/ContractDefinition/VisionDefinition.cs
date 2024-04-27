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

namespace StratML.Contracts.Vision.ContractDefinition
{


    public partial class VisionDeployment : VisionDeploymentBase
    {
        public VisionDeployment() : base(BYTECODE) { }
        public VisionDeployment(string byteCode) : base(byteCode) { }
    }

    public class VisionDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162000bac38038062000bac833981016040819052620000339162000100565b8133806200005a57604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b62000065816200009d565b50600180546001600160a01b0319166001600160a01b0392909216919091179055600362000094828262000278565b50505062000344565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f806040838503121562000112575f80fd5b82516001600160a01b038116811462000129575f80fd5b602084810151919350906001600160401b038082111562000148575f80fd5b818601915086601f8301126200015c575f80fd5b815181811115620001715762000171620000ec565b604051601f8201601f19908116603f011681019083821181831017156200019c576200019c620000ec565b816040528281528986848701011115620001b4575f80fd5b5f93505b82841015620001d75784840186015181850187015292850192620001b8565b5f8684830101528096505050505050509250929050565b600181811c908216806200020357607f821691505b6020821081036200022257634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200027357805f5260205f20601f840160051c810160208510156200024f5750805b601f840160051c820191505b8181101562000270575f81556001016200025b565b50505b505050565b81516001600160401b03811115620002945762000294620000ec565b620002ac81620002a58454620001ee565b8462000228565b602080601f831160018114620002e2575f8415620002ca5750858301515b5f19600386901b1c1916600185901b1785556200033c565b5f85815260208120601f198616915b828110156200031257888601518255948401946001909101908401620002f1565b50858210156200033057878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b61085a80620003525f395ff3fe608060405234801561000f575f80fd5b506004361061009b575f3560e01c8063beaacc0b11610063578063beaacc0b14610115578063c1f8bbc414610128578063c9b87ee31461013b578063ce8918811461015e578063f2fde38b14610173575f80fd5b8063380cbbd71461009f578063715018a6146100b45780637284e416146100bc5780637b103999146100da5780638da5cb5b14610105575b5f80fd5b6100b26100ad366004610540565b610186565b005b6100b261022b565b6100c461023e565b6040516100d191906105b0565b60405180910390f35b6001546100ed906001600160a01b031681565b6040516001600160a01b0390911681526020016100d1565b5f546001600160a01b03166100ed565b6100ed6101233660046105c2565b6102ca565b6100b26101363660046105ed565b6102f2565b61014e610149366004610540565b610327565b60405190151581526020016100d1565b6101666103cc565b6040516100d19190610698565b6100b2610181366004610540565b610486565b61018e6104c5565b5f5b6002548110156101dc57816001600160a01b0316600282815481106101b7576101b76106cc565b5f918252602090912001546001600160a01b0316036101d4575050565b600101610190565b50600280546001810182555f919091527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180546001600160a01b0319166001600160a01b0383161790555b50565b6102336104c5565b61023c5f6104f1565b565b6003805461024b906106e0565b80601f0160208091040260200160405190810160405280929190818152602001828054610277906106e0565b80156102c25780601f10610299576101008083540402835291602001916102c2565b820191905f5260205f20905b8154815290600101906020018083116102a557829003601f168201915b505050505081565b600281815481106102d9575f80fd5b5f918252602090912001546001600160a01b0316905081565b6102fb33610327565b61031757604051621607ef60ea1b815260040160405180910390fd5b60036103238282610764565b5050565b6001545f906001600160a01b0380841691160361034657506001919050565b5f546001600160a01b03166001600160a01b0316826001600160a01b03160361037157506001919050565b5f5b6002548110156103c457826001600160a01b03166002828154811061039a5761039a6106cc565b5f918252602090912001546001600160a01b0316036103bc5750600192915050565b600101610373565b505f92915050565b6040805180820182525f815260606020808301829052835180850190945283015230825260038054919291610400906106e0565b80601f016020809104026020016040519081016040528092919081815260200182805461042c906106e0565b80156104775780601f1061044e57610100808354040283529160200191610477565b820191905f5260205f20905b81548152906001019060200180831161045a57829003601f168201915b50505050506020820152919050565b61048e6104c5565b6001600160a01b0381166104bc57604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b610228816104f1565b5f546001600160a01b0316331461023c5760405163118cdaa760e01b81523360048201526024016104b3565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b5f60208284031215610550575f80fd5b81356001600160a01b0381168114610566575f80fd5b9392505050565b5f81518084525f5b8181101561059157602081850181015186830182015201610575565b505f602082860101526020601f19601f83011685010191505092915050565b602081525f610566602083018461056d565b5f602082840312156105d2575f80fd5b5035919050565b634e487b7160e01b5f52604160045260245ffd5b5f602082840312156105fd575f80fd5b813567ffffffffffffffff80821115610614575f80fd5b818401915084601f830112610627575f80fd5b813581811115610639576106396105d9565b604051601f8201601f19908116603f01168101908382118183101715610661576106616105d9565b81604052828152876020848701011115610679575f80fd5b826020860160208301375f928101602001929092525095945050505050565b602080825282516001600160a01b0316828201528201516040808301525f906106c4606084018261056d565b949350505050565b634e487b7160e01b5f52603260045260245ffd5b600181811c908216806106f457607f821691505b60208210810361071257634e487b7160e01b5f52602260045260245ffd5b50919050565b601f82111561075f57805f5260205f20601f840160051c8101602085101561073d5750805b601f840160051c820191505b8181101561075c575f8155600101610749565b50505b505050565b815167ffffffffffffffff81111561077e5761077e6105d9565b6107928161078c84546106e0565b84610718565b602080601f8311600181146107c5575f84156107ae5750858301515b5f19600386901b1c1916600185901b17855561081c565b5f85815260208120601f198616915b828110156107f3578886015182559484019460019091019084016107d4565b508582101561081057878501515f19600388901b60f8161c191681555b505060018460011b0185555b50505050505056fea2646970667358221220d5eec14e9f02c2d5b8c8d197a06cc35ec2359496fab4e25d9483d0d3ea5cde2364736f6c63430008170033";
        public VisionDeploymentBase() : base(BYTECODE) { }
        public VisionDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class GetVisionResponseFunction : GetVisionResponseFunctionBase { }

    [Function("getVisionResponse", typeof(GetVisionResponseOutputDTO))]
    public class GetVisionResponseFunctionBase : FunctionMessage
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

    public partial class UpdateVisionFunction : UpdateVisionFunctionBase { }

    [Function("updateVision")]
    public class UpdateVisionFunctionBase : FunctionMessage
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

    public partial class GetVisionResponseOutputDTO : GetVisionResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetVisionResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual VisionResponse ReturnValue1 { get; set; }
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
