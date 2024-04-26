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

namespace StratML.Contracts.Organization.ContractDefinition
{


    public partial class OrganizationDeployment : OrganizationDeploymentBase
    {
        public OrganizationDeployment() : base(BYTECODE) { }
        public OrganizationDeployment(string byteCode) : base(byteCode) { }
    }

    public class OrganizationDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162001b9738038062001b978339810160408190526200003391620001cd565b8333806200005a57604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b6200006581620000bd565b50600180546001600160a01b0319166001600160a01b0392909216919091179055600362000094848262000302565b506004620000a3838262000302565b506005620000b2828262000302565b5050505050620003ce565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f82601f83011262000130575f80fd5b81516001600160401b03808211156200014d576200014d6200010c565b604051601f8301601f19908116603f011681019082821181831017156200017857620001786200010c565b816040528381526020925086602085880101111562000195575f80fd5b5f91505b83821015620001b8578582018301518183018401529082019062000199565b5f602085830101528094505050505092915050565b5f805f8060808587031215620001e1575f80fd5b84516001600160a01b0381168114620001f8575f80fd5b60208601519094506001600160401b038082111562000215575f80fd5b620002238883890162000120565b9450604087015191508082111562000239575f80fd5b620002478883890162000120565b935060608701519150808211156200025d575f80fd5b506200026c8782880162000120565b91505092959194509250565b600181811c908216806200028d57607f821691505b602082108103620002ac57634e487b7160e01b5f52602260045260245ffd5b50919050565b601f821115620002fd57805f5260205f20601f840160051c81016020851015620002d95750805b601f840160051c820191505b81811015620002fa575f8155600101620002e5565b50505b505050565b81516001600160401b038111156200031e576200031e6200010c565b62000336816200032f845462000278565b84620002b2565b602080601f8311600181146200036c575f8415620003545750858301515b5f19600386901b1c1916600185901b178555620003c6565b5f85815260208120601f198616915b828110156200039c578886015182559484019460019091019084016200037b565b5085821015620003ba57878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b6117bb80620003dc5f395ff3fe608060405234801561000f575f80fd5b50600436106100f0575f3560e01c80638da5cb5b11610093578063beaacc0b11610063578063beaacc0b146101cc578063c9b87ee3146101df578063e5c42fd114610202578063f2fde38b14610215575f80fd5b80638da5cb5b1461017f578063b3fb6fb91461018f578063b6992247146101a4578063bcb0c2d7146101b9575f80fd5b8063715018a6116100ce578063715018a61461012f5780637284e416146101375780637b1039991461013f578063879bcf691461016a575f80fd5b806306fdde03146100f4578063380cbbd7146101125780635b9841a014610127575b5f80fd5b6100fc610228565b6040516101099190610e0f565b60405180910390f35b610125610120366004610e3c565b6102b4565b005b6100fc610359565b610125610366565b6100fc610379565b600154610152906001600160a01b031681565b6040516001600160a01b039091168152602001610109565b610172610386565b6040516101099190610fd0565b5f546001600160a01b0316610152565b610197610808565b6040516101099190610fe2565b6101ac610939565b6040516101099190611199565b6101256101c7366004610e3c565b610999565b6101526101da3660046111e5565b610ab7565b6101f26101ed366004610e3c565b610adf565b6040519015158152602001610109565b610125610210366004610e3c565b610b84565b610125610223366004610e3c565b610c6f565b60038054610235906111fc565b80601f0160208091040260200160405190810160405280929190818152602001828054610261906111fc565b80156102ac5780601f10610283576101008083540402835291602001916102ac565b820191905f5260205f20905b81548152906001019060200180831161028f57829003601f168201915b505050505081565b6102bc610cae565b5f5b60025481101561030a57816001600160a01b0316600282815481106102e5576102e561122e565b5f918252602090912001546001600160a01b031603610302575050565b6001016102be565b50600280546001810182555f919091527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180546001600160a01b0319166001600160a01b0383161790555b50565b60058054610235906111fc565b61036e610cae565b6103775f610cda565b565b60048054610235906111fc565b61038e610d29565b610396610d29565b308152600380546103a6906111fc565b80601f01602080910402602001604051908101604052809291908181526020018280546103d2906111fc565b801561041d5780601f106103f45761010080835404028352916020019161041d565b820191905f5260205f20905b81548152906001019060200180831161040057829003601f168201915b5050505050816020018190525060048054610437906111fc565b80601f0160208091040260200160405190810160405280929190818152602001828054610463906111fc565b80156104ae5780601f10610485576101008083540402835291602001916104ae565b820191905f5260205f20905b81548152906001019060200180831161049157829003601f168201915b50505050508160400181905250600580546104c8906111fc565b80601f01602080910402602001604051908101604052809291908181526020018280546104f4906111fc565b801561053f5780601f106105165761010080835404028352916020019161053f565b820191905f5260205f20905b81548152906001019060200180831161052257829003601f168201915b5050505050606082015260065467ffffffffffffffff81111561056457610564611242565b60405190808252806020026020018201604052801561059d57816020015b61058a610d60565b8152602001906001900390816105825790505b5060808201525f5b600654811015610802575f600682815481106105c3576105c361122e565b5f91825260209091200154600680546001600160a01b03909216925090839081106105f0576105f061122e565b5f91825260209091200154608084015180516001600160a01b03909216918490811061061e5761061e61122e565b60200260200101515f01906001600160a01b031690816001600160a01b031681525050806001600160a01b03166306fdde036040518163ffffffff1660e01b81526004015f60405180830381865afa15801561067c573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f191682016040526106a3919081019061135f565b836080015183815181106106b9576106b961122e565b602002602001015160200181905250806001600160a01b0316635a4bc7c16040518163ffffffff1660e01b8152600401602060405180830381865afa158015610704573d5f803e3d5ffd5b505050506040513d601f19601f8201168201806040525081019061072891906113a4565b8360800151838151811061073e5761073e61122e565b602002602001015160400190600281111561075b5761075b610e57565b9081600281111561076e5761076e610e57565b81525050806001600160a01b031663710613986040518163ffffffff1660e01b81526004015f60405180830381865afa1580156107ad573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f191682016040526107d49190810190611460565b836080015183815181106107ea576107ea61122e565b602090810291909101015160600152506001016105a5565b50919050565b610810610d88565b610818610d88565b610820610386565b815260065467ffffffffffffffff81111561083d5761083d611242565b60405190808252806020026020018201604052801561087657816020015b610863610d9b565b81526020019060019003908161085b5790505b5060208201525f5b600654811015610802575f6006828154811061089c5761089c61122e565b5f91825260208220015460408051632dc0cd9d60e21b815290516001600160a01b039092169350839263b7033674926004808401938290030181865afa1580156108e8573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f1916820160405261090f919081019061162d565b836020015183815181106109255761092561122e565b60209081029190910101525060010161087e565b6060600680548060200260200160405190810160405280929190818152602001828054801561098f57602002820191905f5260205f20905b81546001600160a01b03168152600190910190602001808311610971575b5050505050905090565b6109a233610adf565b6109be57604051621607ef60ea1b815260040160405180910390fd5b5f5b600654811015610ab357816001600160a01b0316600682815481106109e7576109e761122e565b5f918252602090912001546001600160a01b031603610aab5760068054610a109060019061174c565b81548110610a2057610a2061122e565b5f91825260209091200154600680546001600160a01b039092169183908110610a4b57610a4b61122e565b905f5260205f20015f6101000a8154816001600160a01b0302191690836001600160a01b031602179055506006805480610a8757610a87611771565b5f8281526020902081015f1990810180546001600160a01b03191690550190555050565b6001016109c0565b5050565b60028181548110610ac6575f80fd5b5f918252602090912001546001600160a01b0316905081565b6001545f906001600160a01b03808416911603610afe57506001919050565b5f546001600160a01b03166001600160a01b0316826001600160a01b031603610b2957506001919050565b5f5b600254811015610b7c57826001600160a01b031660028281548110610b5257610b5261122e565b5f918252602090912001546001600160a01b031603610b745750600192915050565b600101610b2b565b505f92915050565b610b8d33610adf565b610ba957604051621607ef60ea1b815260040160405180910390fd5b5f5b600654811015610bf757816001600160a01b031660068281548110610bd257610bd261122e565b5f918252602090912001546001600160a01b031603610bef575050565b600101610bab565b50600680546001810182555f9182527ff652222313e28459528d920b65115c16c04f3efc82aaedc97be59f3f377c0d3f0180546001600160a01b0319166001600160a01b03841690811790915560405190917fd9b802c55a7d0aabbc6554676754b5b4aabc8edf1d540b77812f81f6d4409ea191a250565b610c77610cae565b6001600160a01b038116610ca557604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b61035681610cda565b5f546001600160a01b031633146103775760405163118cdaa760e01b8152336004820152602401610c9c565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b03168152602001606081526020016060815260200160608152602001606081525090565b604080516080810182525f8082526060602083015290918201905b8152602001606081525090565b6040518060400160405280610d7b610d29565b6040518060600160405280610dae610d60565b815260200160608152602001606081525090565b5f5b83811015610ddc578181015183820152602001610dc4565b50505f910152565b5f8151808452610dfb816020860160208601610dc2565b601f01601f19169290920160200192915050565b602081525f610e216020830184610de4565b9392505050565b6001600160a01b0381168114610356575f80fd5b5f60208284031215610e4c575f80fd5b8135610e2181610e28565b634e487b7160e01b5f52602160045260245ffd5b5f815180845260208085019450602084015f5b83811015610ea35781516001600160a01b031687529582019590820190600101610e7e565b509495945050505050565b60018060a01b0381511682525f602082015160806020850152610ed46080850182610de4565b9050604083015160038110610eeb57610eeb610e57565b8060408601525060608301518482036060860152610f098282610e6b565b95945050505050565b60018060a01b0381511682525f60208083015160a082860152610f3860a0860182610de4565b905060408401518582036040870152610f518282610de4565b91505060608401518582036060870152610f6b8282610de4565b915050608084015185820360808701528181518084528484019150848160051b85010185840193505f5b82811015610fc357601f19868303018452610fb1828651610eae565b94870194938701939150600101610f95565b5098975050505050505050565b602081525f610e216020830184610f12565b602081525f825160406020840152610ffd6060840182610f12565b602085810151858303601f19016040870152805180845292935081019181840191600582901b8501015f5b8281101561118d57601f19868303018452845180516060845261104e6060850182610eae565b60208381015186830387830152805180845292935081019181840191600582901b8501015f5b8281101561115457858203601f19018452845180516001600160a01b0316835260208082015160a0918501829052906110af90850182610de4565b9050604082015184820360408601526110c88282610de4565b606084810151878303918801919091528051808352602091820194505f93509101905b8083101561111d5783516002811061110557611105610e57565b825260209384019360019390930192909101906110eb565b506080840151935085810360808701526111378185610e6b565b955050505050602085019450602084019350600181019050611074565b5060408601519550878103604089015261116e8187610de4565b9750505050505050602085019450602084019350600181019050611028565b50979650505050505050565b602080825282518282018190525f9190848201906040850190845b818110156111d95783516001600160a01b0316835292840192918401916001016111b4565b50909695505050505050565b5f602082840312156111f5575f80fd5b5035919050565b600181811c9082168061121057607f821691505b60208210810361080257634e487b7160e01b5f52602260045260245ffd5b634e487b7160e01b5f52603260045260245ffd5b634e487b7160e01b5f52604160045260245ffd5b60405160a0810167ffffffffffffffff8111828210171561127957611279611242565b60405290565b6040516060810167ffffffffffffffff8111828210171561127957611279611242565b6040516080810167ffffffffffffffff8111828210171561127957611279611242565b604051601f8201601f1916810167ffffffffffffffff811182821017156112ee576112ee611242565b604052919050565b5f82601f830112611305575f80fd5b815167ffffffffffffffff81111561131f5761131f611242565b611332601f8201601f19166020016112c5565b818152846020838601011115611346575f80fd5b611357826020830160208701610dc2565b949350505050565b5f6020828403121561136f575f80fd5b815167ffffffffffffffff811115611385575f80fd5b611357848285016112f6565b80516003811061139f575f80fd5b919050565b5f602082840312156113b4575f80fd5b610e2182611391565b5f67ffffffffffffffff8211156113d6576113d6611242565b5060051b60200190565b805161139f81610e28565b5f82601f8301126113fa575f80fd5b8151602061140f61140a836113bd565b6112c5565b8083825260208201915060208460051b870101935086841115611430575f80fd5b602086015b8481101561145557805161144881610e28565b8352918301918301611435565b509695505050505050565b5f60208284031215611470575f80fd5b815167ffffffffffffffff811115611486575f80fd5b611357848285016113eb565b5f82601f8301126114a1575f80fd5b815160206114b161140a836113bd565b8083825260208201915060208460051b8701019350868411156114d2575f80fd5b602086015b84811015611455578051600281106114ed575f80fd5b83529183019183016114d7565b5f82601f830112611509575f80fd5b8151602061151961140a836113bd565b82815260059290921b84018101918181019086841115611537575f80fd5b8286015b8481101561145557805167ffffffffffffffff8082111561155a575f80fd5b9088019060a0828b03601f1901811315611572575f80fd5b61157a611256565b6115858885016113e0565b815260408085015184811115611599575f80fd5b6115a78e8b838901016112f6565b8a84015250606080860151858111156115be575f80fd5b6115cc8f8c838a01016112f6565b83850152506080915081860151858111156115e5575f80fd5b6115f38f8c838a0101611492565b8285015250508285015192508383111561160b575f80fd5b6116198d8a858801016113eb565b90820152865250505091830191830161153b565b5f6020828403121561163d575f80fd5b815167ffffffffffffffff80821115611654575f80fd5b9083019060608286031215611667575f80fd5b61166f61127f565b82518281111561167d575f80fd5b83016080818803121561168e575f80fd5b6116966112a2565b81516116a181610e28565b81526020820151848111156116b4575f80fd5b6116c0898285016112f6565b6020830152506116d260408301611391565b60408201526060820151848111156116e8575f80fd5b6116f4898285016113eb565b60608301525082525060208301518281111561170e575f80fd5b61171a878286016114fa565b602083015250604083015182811115611731575f80fd5b61173d878286016112f6565b60408301525095945050505050565b8181038181111561176b57634e487b7160e01b5f52601160045260245ffd5b92915050565b634e487b7160e01b5f52603160045260245ffdfea264697066735822122028f4ca674dd9dd120e11fd68a9c81098fe80697bf736b7e31d116995c209c9d564736f6c63430008170033";
        public OrganizationDeploymentBase() : base(BYTECODE) { }
        public OrganizationDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_registry", 1)]
        public virtual string Registry { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 3)]
        public virtual string Description { get; set; }
        [Parameter("string", "_acryonym", 4)]
        public virtual string Acryonym { get; set; }
    }

    public partial class AcryonymFunction : AcryonymFunctionBase { }

    [Function("acryonym", "string")]
    public class AcryonymFunctionBase : FunctionMessage
    {

    }

    public partial class AddSiblingFunction : AddSiblingFunctionBase { }

    [Function("addSibling")]
    public class AddSiblingFunctionBase : FunctionMessage
    {
        [Parameter("address", "sibling", 1)]
        public virtual string Sibling { get; set; }
    }

    public partial class AddStakeholderFunction : AddStakeholderFunctionBase { }

    [Function("addStakeholder")]
    public class AddStakeholderFunctionBase : FunctionMessage
    {
        [Parameter("address", "_stakeholderAddress", 1)]
        public virtual string StakeholderAddress { get; set; }
    }

    public partial class DescriptionFunction : DescriptionFunctionBase { }

    [Function("description", "string")]
    public class DescriptionFunctionBase : FunctionMessage
    {

    }

    public partial class GetOrganizationResponseFunction : GetOrganizationResponseFunctionBase { }

    [Function("getOrganizationResponse", typeof(GetOrganizationResponseOutputDTO))]
    public class GetOrganizationResponseFunctionBase : FunctionMessage
    {

    }

    public partial class GetOrganizationResponseBasedFunction : GetOrganizationResponseBasedFunctionBase { }

    [Function("getOrganizationResponseBased", typeof(GetOrganizationResponseBasedOutputDTO))]
    public class GetOrganizationResponseBasedFunctionBase : FunctionMessage
    {

    }

    public partial class GetStakeholdersFunction : GetStakeholdersFunctionBase { }

    [Function("getStakeholders", "address[]")]
    public class GetStakeholdersFunctionBase : FunctionMessage
    {

    }

    public partial class IsSiblingFunction : IsSiblingFunctionBase { }

    [Function("isSibling", "bool")]
    public class IsSiblingFunctionBase : FunctionMessage
    {
        [Parameter("address", "sibling", 1)]
        public virtual string Sibling { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

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

    public partial class RemoveStakeholderFunction : RemoveStakeholderFunctionBase { }

    [Function("removeStakeholder")]
    public class RemoveStakeholderFunctionBase : FunctionMessage
    {
        [Parameter("address", "_stakeholderAddress", 1)]
        public virtual string StakeholderAddress { get; set; }
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

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class StakeholderAddedEventDTO : StakeholderAddedEventDTOBase { }

    [Event("StakeholderAdded")]
    public class StakeholderAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "stakeholderAddress", 1, true )]
        public virtual string StakeholderAddress { get; set; }
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

    public partial class AcryonymOutputDTO : AcryonymOutputDTOBase { }

    [FunctionOutput]
    public class AcryonymOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class DescriptionOutputDTO : DescriptionOutputDTOBase { }

    [FunctionOutput]
    public class DescriptionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetOrganizationResponseOutputDTO : GetOrganizationResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetOrganizationResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual OrganizationResponse ReturnValue1 { get; set; }
    }

    public partial class GetOrganizationResponseBasedOutputDTO : GetOrganizationResponseBasedOutputDTOBase { }

    [FunctionOutput]
    public class GetOrganizationResponseBasedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual OrganizationResponseBased ReturnValue1 { get; set; }
    }

    public partial class GetStakeholdersOutputDTO : GetStakeholdersOutputDTOBase { }

    [FunctionOutput]
    public class GetStakeholdersOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class IsSiblingOutputDTO : IsSiblingOutputDTOBase { }

    [FunctionOutput]
    public class IsSiblingOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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
