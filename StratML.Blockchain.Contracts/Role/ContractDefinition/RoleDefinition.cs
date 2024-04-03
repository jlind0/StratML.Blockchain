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

namespace StratML.Contracts.Role.ContractDefinition
{


    public partial class RoleDeployment : RoleDeploymentBase
    {
        public RoleDeployment() : base(BYTECODE) { }
        public RoleDeployment(string byteCode) : base(byteCode) { }
    }

    public class RoleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162001c6b38038062001c6b8339810160408190526200003391620002a8565b8333806200005a57604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b62000065816200018a565b50600180546001600160a01b0319166001600160a01b039290921691909117905560036200009484826200045a565b506004620000a383826200045a565b505f5b815181101562000129576005828281518110620000c757620000c762000526565b6020026020010151908060018154018082558091505060019003905f5260205f2090602091828204019190069091909190916101000a81548160ff021916908360018111156200011b576200011b6200053a565b0217905550600101620000a6565b50604051631fc3bfb960e11b81523060048201526001600160a01b03851690633f877f72906024015f604051808303815f87803b15801562000169575f80fd5b505af11580156200017c573d5f803e3d5ffd5b50505050505050506200054e565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b604051601f8201601f191681016001600160401b0381118282101715620002185762000218620001d9565b604052919050565b5f82601f83011262000230575f80fd5b81516001600160401b038111156200024c576200024c620001d9565b602062000262601f8301601f19168201620001ed565b828152858284870101111562000276575f80fd5b5f5b838110156200029557858101830151828201840152820162000278565b505f928101909101919091529392505050565b5f805f8060808587031215620002bc575f80fd5b84516001600160a01b0381168114620002d3575f80fd5b602086810151919550906001600160401b0380821115620002f2575f80fd5b6200030089838a0162000220565b9550604088015191508082111562000316575f80fd5b6200032489838a0162000220565b945060608801519150808211156200033a575f80fd5b818801915088601f8301126200034e575f80fd5b815181811115620003635762000363620001d9565b8060051b915062000376848301620001ed565b818152918301840191848101908b84111562000390575f80fd5b938501935b83851015620003c0578451925060028310620003af575f80fd5b828252938501939085019062000395565b989b979a50959850505050505050565b600181811c90821680620003e557607f821691505b6020821081036200040457634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200045557805f5260205f20601f840160051c81016020851015620004315750805b601f840160051c820191505b8181101562000452575f81556001016200043d565b50505b505050565b81516001600160401b03811115620004765762000476620001d9565b6200048e81620004878454620003d0565b846200040a565b602080601f831160018114620004c4575f8415620004ac5750858301515b5f19600386901b1c1916600185901b1785556200051e565b5f85815260208120601f198616915b82811015620004f457888601518255948401946001909101908401620004d3565b50858210156200051257878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b634e487b7160e01b5f52603260045260245ffd5b634e487b7160e01b5f52602160045260245ffd5b61170f806200055c5f395ff3fe608060405234801561000f575f80fd5b50600436106100fb575f3560e01c8063bcb0c2d711610093578063d4694d0411610063578063d4694d0414610203578063e5c42fd114610218578063f2fde38b1461022b578063fde081741461023e575f80fd5b8063bcb0c2d7146101a5578063beaacc0b146101b8578063c9b87ee3146101cb578063d258111a146101ee575f80fd5b80637b103999116100ce5780637b10399914610142578063887ac2601461016d5780638da5cb5b1461018057806396c61cb214610190575f80fd5b806306fdde03146100ff578063380cbbd71461011d578063715018a6146101325780637284e4161461013a575b5f80fd5b610107610253565b6040516101149190610e85565b60405180910390f35b61013061012b366004610eb2565b6102df565b005b610130610384565b610107610397565b600154610155906001600160a01b031681565b6040516001600160a01b039091168152602001610114565b61013061017b366004610fd7565b6103a4565b5f546001600160a01b0316610155565b6101986105ff565b60405161011491906110e7565b6101306101b3366004610eb2565b610684565b6101556101c636600461112f565b6107a2565b6101de6101d9366004610eb2565b6107ca565b6040519015158152602001610114565b6101f661086f565b6040516101149190611236565b61020b610a87565b6040516101149190611248565b610130610226366004610eb2565b610ae6565b610130610239366004610eb2565b610bd1565b610246610c10565b604051610114919061125a565b6003805461026090611330565b80601f016020809104026020016040519081016040528092919081815260200182805461028c90611330565b80156102d75780601f106102ae576101008083540402835291602001916102d7565b820191905f5260205f20905b8154815290600101906020018083116102ba57829003601f168201915b505050505081565b6102e7610d47565b5f5b60025481101561033557816001600160a01b03166002828154811061031057610310611362565b5f918252602090912001546001600160a01b03160361032d575050565b6001016102e9565b50600280546001810182555f919091527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180546001600160a01b0319166001600160a01b0383161790555b50565b61038c610d47565b6103955f610d73565b565b6004805461026090611330565b6103ad336107ca565b6103c957604051621607ef60ea1b815260040160405180910390fd5b5f836040516020016103db9190611376565b6040516020818303038152906040528051906020012060036040516020016104039190611391565b60405160208183030381529060405280519060200120141590505f6003805461042b90611330565b80601f016020809104026020016040519081016040528092919081815260200182805461045790611330565b80156104a25780601f10610479576101008083540402835291602001916104a2565b820191905f5260205f20905b81548152906001019060200180831161048557829003601f168201915b5050505050905084600390816104b8919061144c565b5060046104c5858261144c565b505f5b6005548110156105135760058054806104e3576104e361150c565b5f8281526020908190205f19909201908104909101805460ff601f84166101000a021916905590556001016104c8565b505f5b835181101561059157600584828151811061053357610533611362565b6020026020010151908060018154018082558091505060019003905f5260205f2090602091828204019190069091909190916101000a81548160ff02191690836001811115610584576105846110b9565b0217905550600101610516565b5081156105f85760015460405163166d8cbd60e01b81526001600160a01b039091169063166d8cbd906105ca9030908590600401611520565b5f604051808303815f87803b1580156105e1575f80fd5b505af11580156105f3573d5f803e3d5ffd5b505050505b5050505050565b6060600580548060200260200160405190810160405280929190818152602001828054801561067a57602002820191905f5260205f20905f905b82829054906101000a900460ff166001811115610658576106586110b9565b8152602060019283018181049485019490930390920291018084116106395790505b5050505050905090565b61068d336107ca565b6106a957604051621607ef60ea1b815260040160405180910390fd5b5f5b60065481101561079e57816001600160a01b0316600682815481106106d2576106d2611362565b5f918252602090912001546001600160a01b03160361079657600680546106fb9060019061154b565b8154811061070b5761070b611362565b5f91825260209091200154600680546001600160a01b03909216918390811061073657610736611362565b905f5260205f20015f6101000a8154816001600160a01b0302191690836001600160a01b0316021790555060068054806107725761077261150c565b5f8281526020902081015f1990810180546001600160a01b03191690550190555050565b6001016106ab565b5050565b600281815481106107b1575f80fd5b5f918252602090912001546001600160a01b0316905081565b6001545f906001600160a01b038084169116036107e957506001919050565b5f546001600160a01b03166001600160a01b0316826001600160a01b03160361081457506001919050565b5f5b60025481101561086757826001600160a01b03166002828154811061083d5761083d611362565b5f918252602090912001546001600160a01b03160361085f5750600192915050565b600101610816565b505f92915050565b610877610dc2565b61087f610dc2565b3081526003805461088f90611330565b80601f01602080910402602001604051908101604052809291908181526020018280546108bb90611330565b80156109065780601f106108dd57610100808354040283529160200191610906565b820191905f5260205f20905b8154815290600101906020018083116108e957829003601f168201915b505050505081602001819052506004805461092090611330565b80601f016020809104026020016040519081016040528092919081815260200182805461094c90611330565b80156109975780601f1061096e57610100808354040283529160200191610997565b820191905f5260205f20905b81548152906001019060200180831161097a57829003601f168201915b505050506040808401929092525060058054825160208083028201810190945281815292830182828015610a1757602002820191905f5260205f20905f905b82829054906101000a900460ff1660018111156109f5576109f56110b9565b8152602060019283018181049485019490930390920291018084116109d65790505b505050505081606001819052506006805480602002602001604051908101604052809291908181526020018280548015610a7857602002820191905f5260205f20905b81546001600160a01b03168152600190910190602001808311610a5a575b50505050506080820152919050565b6060600680548060200260200160405190810160405280929190818152602001828054801561067a57602002820191905f5260205f20905b81546001600160a01b03168152600190910190602001808311610abf575050505050905090565b610aef336107ca565b610b0b57604051621607ef60ea1b815260040160405180910390fd5b5f5b600654811015610b5957816001600160a01b031660068281548110610b3457610b34611362565b5f918252602090912001546001600160a01b031603610b51575050565b600101610b0d565b50600680546001810182555f9182527ff652222313e28459528d920b65115c16c04f3efc82aaedc97be59f3f377c0d3f0180546001600160a01b0319166001600160a01b03841690811790915560405190917fd9b802c55a7d0aabbc6554676754b5b4aabc8edf1d540b77812f81f6d4409ea191a250565b610bd9610d47565b6001600160a01b038116610c0757604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b61038181610d73565b610c18610df9565b610c20610df9565b610c2861086f565b815260065467ffffffffffffffff811115610c4557610c45610ecd565b604051908082528060200260200182016040528015610c7e57816020015b610c6b610e19565b815260200190600190039081610c635790505b5060208201525f5b600654811015610d41575f60068281548110610ca457610ca4611362565b5f918252602082200154604080516315e865c560e31b815290516001600160a01b039092169350839263af432e28926004808401938290030181865afa158015610cf0573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f19168201604052610d1791908101906115f3565b83602001518381518110610d2d57610d2d611362565b602090810291909101015250600101610c86565b50919050565b5f546001600160a01b031633146103955760405163118cdaa760e01b8152336004820152602401610bfe565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b03168152602001606081526020016060815260200160608152602001606081525090565b6040518060400160405280610e0c610dc2565b8152602001606081525090565b604080516080810182525f808252606060208301529091820190610e0c565b5f5b83811015610e52578181015183820152602001610e3a565b50505f910152565b5f8151808452610e71816020860160208601610e38565b601f01601f19169290920160200192915050565b602081525f610e976020830184610e5a565b9392505050565b6001600160a01b0381168114610381575f80fd5b5f60208284031215610ec2575f80fd5b8135610e9781610e9e565b634e487b7160e01b5f52604160045260245ffd5b6040516080810167ffffffffffffffff81118282101715610f0457610f04610ecd565b60405290565b604051601f8201601f1916810167ffffffffffffffff81118282101715610f3357610f33610ecd565b604052919050565b5f67ffffffffffffffff821115610f5457610f54610ecd565b50601f01601f191660200190565b5f82601f830112610f71575f80fd5b8135610f84610f7f82610f3b565b610f0a565b818152846020838601011115610f98575f80fd5b816020850160208301375f918101602001919091529392505050565b5f67ffffffffffffffff821115610fcd57610fcd610ecd565b5060051b60200190565b5f805f60608486031215610fe9575f80fd5b833567ffffffffffffffff80821115611000575f80fd5b61100c87838801610f62565b9450602091508186013581811115611022575f80fd5b61102e88828901610f62565b945050604086013581811115611042575f80fd5b86019050601f81018713611054575f80fd5b8035611062610f7f82610fb4565b81815260059190911b82018301908381019089831115611080575f80fd5b928401925b828410156110aa5783356002811061109b575f80fd5b82529284019290840190611085565b80955050505050509250925092565b634e487b7160e01b5f52602160045260245ffd5b5f600282106110de576110de6110b9565b50815260200190565b602080825282518282018190525f9190848201906040850190845b81811015611123576111158385516110cd565b938501939250600101611102565b50909695505050505050565b5f6020828403121561113f575f80fd5b5035919050565b5f815180845260208085019450602084015f5b8381101561117e5781516001600160a01b031687529582019590820190600101611159565b509495945050505050565b60018060a01b0381511682525f60208083015160a060208601526111b060a0860182610e5a565b9050604084015185820360408701526111c98282610e5a565b606086810151888303918901919091528051808352602091820194505f93509101905b80831015611211576111ff8285516110cd565b915084840193506001830192506111ec565b5060808601519350868103608088015261122b8185611146565b979650505050505050565b602081525f610e976020830184611189565b602081525f610e976020830184611146565b5f602080835260608451604080848701526112786060870183611189565b84880151601f19888303810160408a015281518084529294509086019184870190600581901b860188015f5b828110156113205787820385018452855180516001600160a01b031683528a81015160808c8501819052906112db82860182610e5a565b91505088820151600381106112f2576112f26110b9565b848a0152908a01518382038b8501529061130c8183611146565b978c0197958c0195935050506001016112a4565b509b9a5050505050505050505050565b600181811c9082168061134457607f821691505b602082108103610d4157634e487b7160e01b5f52602260045260245ffd5b634e487b7160e01b5f52603260045260245ffd5b5f8251611387818460208701610e38565b9190910192915050565b5f80835461139e81611330565b600182811680156113b657600181146113cb576113f7565b60ff19841687528215158302870194506113f7565b875f526020805f205f5b858110156113ee5781548a8201529084019082016113d5565b50505082870194505b50929695505050505050565b601f82111561144757805f5260205f20601f840160051c810160208510156114285750805b601f840160051c820191505b818110156105f8575f8155600101611434565b505050565b815167ffffffffffffffff81111561146657611466610ecd565b61147a816114748454611330565b84611403565b602080601f8311600181146114ad575f84156114965750858301515b5f19600386901b1c1916600185901b178555611504565b5f85815260208120601f198616915b828110156114db578886015182559484019460019091019084016114bc565b50858210156114f857878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b634e487b7160e01b5f52603160045260245ffd5b6001600160a01b03831681526040602082018190525f9061154390830184610e5a565b949350505050565b8181038181111561156a57634e487b7160e01b5f52601160045260245ffd5b92915050565b80516003811061157e575f80fd5b919050565b5f82601f830112611592575f80fd5b815160206115a2610f7f83610fb4565b8083825260208201915060208460051b8701019350868411156115c3575f80fd5b602086015b848110156115e85780516115db81610e9e565b83529183019183016115c8565b509695505050505050565b5f6020808385031215611604575f80fd5b825167ffffffffffffffff8082111561161b575f80fd5b908401906080828703121561162e575f80fd5b611636610ee1565b825161164181610e9e565b81528284015182811115611653575f80fd5b8301601f81018813611663575f80fd5b8051611671610f7f82610f3b565b8181528987838501011115611684575f80fd5b61169382888301898601610e38565b83870152506116a6905060408401611570565b604082015260608301519350818411156116be575f80fd5b6116ca87858501611583565b6060820152969550505050505056fea26469706673582212203bef141404be47fecbd2d3a869575dd073bda6199932a3e8188580ceebbfa9d564736f6c63430008170033";
        public RoleDeploymentBase() : base(BYTECODE) { }
        public RoleDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_registry", 1)]
        public virtual string Registry { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 3)]
        public virtual string Description { get; set; }
        [Parameter("uint8[]", "_roleTypes", 4)]
        public virtual List<byte> RoleTypes { get; set; }
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

    public partial class GetRoleFunction : GetRoleFunctionBase { }

    [Function("getRole", typeof(GetRoleOutputDTO))]
    public class GetRoleFunctionBase : FunctionMessage
    {

    }

    public partial class GetRoleBaseFunction : GetRoleBaseFunctionBase { }

    [Function("getRoleBase", typeof(GetRoleBaseOutputDTO))]
    public class GetRoleBaseFunctionBase : FunctionMessage
    {

    }

    public partial class GetRoleTypesFunction : GetRoleTypesFunctionBase { }

    [Function("getRoleTypes", "uint8[]")]
    public class GetRoleTypesFunctionBase : FunctionMessage
    {

    }

    public partial class GetStakeholderAddressesFunction : GetStakeholderAddressesFunctionBase { }

    [Function("getStakeholderAddresses", "address[]")]
    public class GetStakeholderAddressesFunctionBase : FunctionMessage
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

    public partial class UpdateRoleFunction : UpdateRoleFunctionBase { }

    [Function("updateRole")]
    public class UpdateRoleFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 2)]
        public virtual string Description { get; set; }
        [Parameter("uint8[]", "_roleTypes", 3)]
        public virtual List<byte> RoleTypes { get; set; }
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





    public partial class DescriptionOutputDTO : DescriptionOutputDTOBase { }

    [FunctionOutput]
    public class DescriptionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetRoleOutputDTO : GetRoleOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual RoleResponse ReturnValue1 { get; set; }
    }

    public partial class GetRoleBaseOutputDTO : GetRoleBaseOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleBaseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual RoleResponseBase ReturnValue1 { get; set; }
    }

    public partial class GetRoleTypesOutputDTO : GetRoleTypesOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8[]", "", 1)]
        public virtual List<byte> ReturnValue1 { get; set; }
    }

    public partial class GetStakeholderAddressesOutputDTO : GetStakeholderAddressesOutputDTOBase { }

    [FunctionOutput]
    public class GetStakeholderAddressesOutputDTOBase : IFunctionOutputDTO 
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
