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

namespace StratML.Contracts.Stakeholder.ContractDefinition
{


    public partial class StakeholderDeployment : StakeholderDeploymentBase
    {
        public StakeholderDeployment() : base(BYTECODE) { }
        public StakeholderDeployment(string byteCode) : base(byteCode) { }
    }

    public class StakeholderDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b50604051620017c6380380620017c68339810160408190526200003391620003c7565b33806200005a57604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b6200006581620001e1565b50600162000074848262000522565b506002805483919060ff191660018383811115620000965762000096620005ee565b02179055508051620000b090600390602084019062000230565b505f5b8151811015620001d7575f828281518110620000d357620000d362000602565b60209081029190910101516040513060248201526001600160a01b039091169060440160408051601f198184030181529181526020820180516001600160e01b031663e5c42fd160e01b179052516200012d919062000616565b5f60405180830381855af49150503d805f811462000167576040519150601f19603f3d011682016040523d82523d5f602084013e6200016c565b606091505b5050905080620001cd5760405162461bcd60e51b815260206004820152602560248201527f44656c656761746563616c6c20746f206164645374616b65686f6c6465722066604482015264185a5b195960da1b606482015260840162000051565b50600101620000b3565b5050505062000633565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b828054828255905f5260205f2090810192821562000286579160200282015b828111156200028657825182546001600160a01b0319166001600160a01b039091161782556020909201916001909101906200024f565b506200029492915062000298565b5090565b5b8082111562000294575f815560010162000299565b634e487b7160e01b5f52604160045260245ffd5b604051601f8201601f191681016001600160401b0381118282101715620002ed57620002ed620002ae565b604052919050565b5f5b8381101562000311578181015183820152602001620002f7565b50505f910152565b80516003811062000328575f80fd5b919050565b5f82601f8301126200033d575f80fd5b815160206001600160401b038211156200035b576200035b620002ae565b8160051b6200036c828201620002c2565b928352848101820192828101908785111562000386575f80fd5b83870192505b84831015620003bc5782516001600160a01b0381168114620003ac575f80fd5b825291830191908301906200038c565b979650505050505050565b5f805f60608486031215620003da575f80fd5b83516001600160401b0380821115620003f1575f80fd5b818601915086601f83011262000405575f80fd5b8151818111156200041a576200041a620002ae565b6200042f601f8201601f1916602001620002c2565b81815288602083860101111562000444575f80fd5b62000457826020830160208701620002f5565b95506200046990506020870162000319565b935060408601519150808211156200047f575f80fd5b506200048e868287016200032d565b9150509250925092565b600181811c90821680620004ad57607f821691505b602082108103620004cc57634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200051d57805f5260205f20601f840160051c81016020851015620004f95750805b601f840160051c820191505b818110156200051a575f815560010162000505565b50505b505050565b81516001600160401b038111156200053e576200053e620002ae565b62000556816200054f845462000498565b84620004d2565b602080601f8311600181146200058c575f8415620005745750858301515b5f19600386901b1c1916600185901b178555620005e6565b5f85815260208120601f198616915b82811015620005bc578886015182559484019460019091019084016200059b565b5085821015620005da57878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b634e487b7160e01b5f52602160045260245ffd5b634e487b7160e01b5f52603260045260245ffd5b5f825162000629818460208701620002f5565b9190910192915050565b61118580620006415f395ff3fe608060405234801561000f575f80fd5b5060043610610090575f3560e01c80638da5cb5b116100635780638da5cb5b146100eb578063b70336741461010f578063bfda4a4914610124578063d5c809eb14610137578063f2fde38b1461014a575f80fd5b806306fdde03146100945780635a4bc7c1146100b257806371061398146100cc578063715018a6146100e1575b5f80fd5b61009c61015d565b6040516100a99190610af3565b60405180910390f35b6002546100bf9060ff1681565b6040516100a99190610b34565b6100d46101e9565b6040516100a99190610b8b565b6100e9610249565b005b5f546001600160a01b03165b6040516001600160a01b0390911681526020016100a9565b61011761025c565b6040516100a99190610b9d565b6100f7610132366004610cb3565b610666565b6100e9610145366004610df5565b61068e565b6100e9610158366004610ea2565b610921565b6001805461016a90610ebd565b80601f016020809104026020016040519081016040528092919081815260200182805461019690610ebd565b80156101e15780601f106101b8576101008083540402835291602001916101e1565b820191905f5260205f20905b8154815290600101906020018083116101c457829003601f168201915b505050505081565b6060600380548060200260200160405190810160405280929190818152602001828054801561023f57602002820191905f5260205f20905b81546001600160a01b03168152600190910190602001808311610221575b5050505050905090565b61025161095e565b61025a5f61098a565b565b6102646109d9565b61026c6109d9565b6001805461027990610ebd565b80601f01602080910402602001604051908101604052809291908181526020018280546102a590610ebd565b80156102f05780601f106102c7576101008083540402835291602001916102f0565b820191905f5260205f20905b8154815290600101906020018083116102d357829003601f168201915b50508451939093525050600280548351602001925060ff169081111561031857610318610b0c565b9081600281111561032b5761032b610b0c565b905250600380546040805160208084028201810190925282815292919083018282801561037f57602002820191905f5260205f20905b81546001600160a01b03168152600190910190602001808311610361575b50508451604001939093525050600354905067ffffffffffffffff8111156103a9576103a9610cca565b6040519080825280602002602001820160405280156103e257816020015b6103cf6109f9565b8152602001906001900390816103c75790505b5060208201525f5b600354811015610660575f6003828154811061040857610408610eef565b5f918252602082200154604080516306fdde0360e01b815290516001600160a01b03909216935083926306fdde03926004808401938290030181865afa158015610454573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f1916820160405261047b9190810190610f03565b8360200151838151811061049157610491610eef565b60200260200101515f0181905250806001600160a01b0316637284e4166040518163ffffffff1660e01b81526004015f60405180830381865afa1580156104da573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f191682016040526105019190810190610f03565b8360200151838151811061051757610517610eef565b602002602001015160200181905250806001600160a01b031663d33fd7286040518163ffffffff1660e01b8152600401602060405180830381865afa158015610562573d5f803e3d5ffd5b505050506040513d601f19601f820116820180604052508101906105869190610f75565b8360200151838151811061059c5761059c610eef565b60200260200101516040019060018111156105b9576105b9610b0c565b908160018111156105cc576105cc610b0c565b81525050806001600160a01b031663d4694d046040518163ffffffff1660e01b81526004015f60405180830381865afa15801561060b573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f191682016040526106329190810190610f93565b8360200151838151811061064857610648610eef565b602090810291909101015160600152506001016103ea565b50919050565b60038181548110610675575f80fd5b5f918252602090912001546001600160a01b0316905081565b61069661095e565b60016106a28482611074565b506002805483919060ff1916600183838111156106c1576106c1610b0c565b02179055505f5b6003548110156107eb575f600382815481106106e6576106e6610eef565b5f918252602090912001546040513060248201526001600160a01b039091169060440160408051601f198184030181529181526020820180516001600160e01b031663bcb0c2d760e01b1790525161073e9190611134565b5f60405180830381855af49150503d805f8114610776576040519150601f19603f3d011682016040523d82523d5f602084013e61077b565b606091505b50509050806107e25760405162461bcd60e51b815260206004820152602860248201527f44656c656761746563616c6c20746f2072656d6f76655374616b65686f6c64656044820152671c8819985a5b195960c21b60648201526084015b60405180910390fd5b506001016106c8565b505f5b8151811015610907575f82828151811061080a5761080a610eef565b60209081029190910101516040513060248201526001600160a01b039091169060440160408051601f198184030181529181526020820180516001600160e01b031663e5c42fd160e01b179052516108629190611134565b5f60405180830381855af49150503d805f811461089a576040519150601f19603f3d011682016040523d82523d5f602084013e61089f565b606091505b50509050806108fe5760405162461bcd60e51b815260206004820152602560248201527f44656c656761746563616c6c20746f206164645374616b65686f6c6465722066604482015264185a5b195960da1b60648201526084016107d9565b506001016107ee565b50805161091b906003906020840190610a16565b50505050565b61092961095e565b6001600160a01b03811661095257604051631e4fbdf760e01b81525f60048201526024016107d9565b61095b8161098a565b50565b5f546001600160a01b0316331461025a5760405163118cdaa760e01b81523360048201526024016107d9565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b60405180604001604052806109ec610a79565b8152602001606081525090565b60408051608081018252606080825260208201529081015f6109ec565b828054828255905f5260205f20908101928215610a69579160200282015b82811115610a6957825182546001600160a01b0319166001600160a01b03909116178255602090920191600190910190610a34565b50610a75929150610a92565b5090565b604080516060808201909252908152602081015f6109ec565b5b80821115610a75575f8155600101610a93565b5f5b83811015610ac0578181015183820152602001610aa8565b50505f910152565b5f8151808452610adf816020860160208601610aa6565b601f01601f19169290920160200192915050565b602081525f610b056020830184610ac8565b9392505050565b634e487b7160e01b5f52602160045260245ffd5b60038110610b3057610b30610b0c565b9052565b60208101610b428284610b20565b92915050565b5f815180845260208085019450602084015f5b83811015610b805781516001600160a01b031687529582019590820190600101610b5b565b509495945050505050565b602081525f610b056020830184610b48565b5f602080835260608451604080848701528151606080880152610bc360c0880182610ac8565b9050848301516080610bd860808a0183610b20565b60408501519450605f198984030160a08a0152610bf58386610b48565b878b0151601f198b8303810160408d015281518084529297509089019450925085880190600581901b870189015f5b82811015610ca2578589830301845286518051868452610c4687850182610ac8565b90508c8201518482038e860152610c5d8282610ac8565b9150508982015160028110610c7457610c74610b0c565b848b0152908b01518382038c85015290610c8e8183610b48565b988d0198958d019593505050600101610c24565b509c9b505050505050505050505050565b5f60208284031215610cc3575f80fd5b5035919050565b634e487b7160e01b5f52604160045260245ffd5b604051601f8201601f1916810167ffffffffffffffff81118282101715610d0757610d07610cca565b604052919050565b5f67ffffffffffffffff821115610d2857610d28610cca565b50601f01601f191660200190565b803560038110610d44575f80fd5b919050565b5f67ffffffffffffffff821115610d6257610d62610cca565b5060051b60200190565b6001600160a01b038116811461095b575f80fd5b5f82601f830112610d8f575f80fd5b81356020610da4610d9f83610d49565b610cde565b8083825260208201915060208460051b870101935086841115610dc5575f80fd5b602086015b84811015610dea578035610ddd81610d6c565b8352918301918301610dca565b509695505050505050565b5f805f60608486031215610e07575f80fd5b833567ffffffffffffffff80821115610e1e575f80fd5b818601915086601f830112610e31575f80fd5b8135610e3f610d9f82610d0f565b818152886020838601011115610e53575f80fd5b816020850160208301375f602083830101528096505050610e7660208701610d36565b93506040860135915080821115610e8b575f80fd5b50610e9886828701610d80565b9150509250925092565b5f60208284031215610eb2575f80fd5b8135610b0581610d6c565b600181811c90821680610ed157607f821691505b60208210810361066057634e487b7160e01b5f52602260045260245ffd5b634e487b7160e01b5f52603260045260245ffd5b5f60208284031215610f13575f80fd5b815167ffffffffffffffff811115610f29575f80fd5b8201601f81018413610f39575f80fd5b8051610f47610d9f82610d0f565b818152856020838501011115610f5b575f80fd5b610f6c826020830160208601610aa6565b95945050505050565b5f60208284031215610f85575f80fd5b815160028110610b05575f80fd5b5f6020808385031215610fa4575f80fd5b825167ffffffffffffffff811115610fba575f80fd5b8301601f81018513610fca575f80fd5b8051610fd8610d9f82610d49565b81815260059190911b82018301908381019087831115610ff6575f80fd5b928401925b8284101561101d57835161100e81610d6c565b82529284019290840190610ffb565b979650505050505050565b601f82111561106f57805f5260205f20601f840160051c8101602085101561104d5750805b601f840160051c820191505b8181101561106c575f8155600101611059565b50505b505050565b815167ffffffffffffffff81111561108e5761108e610cca565b6110a28161109c8454610ebd565b84611028565b602080601f8311600181146110d5575f84156110be5750858301515b5f19600386901b1c1916600185901b17855561112c565b5f85815260208120601f198616915b82811015611103578886015182559484019460019091019084016110e4565b508582101561112057878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b5f8251611145818460208701610aa6565b919091019291505056fea26469706673582212203aad9444d9b60d018431d4a9fa1f6c5894179198a2241cef68104944e1ac88a264736f6c63430008170033";
        public StakeholderDeploymentBase() : base(BYTECODE) { }
        public StakeholderDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint8", "_stakeholderType", 2)]
        public virtual byte StakeholderType { get; set; }
        [Parameter("address[]", "_roles", 3)]
        public virtual List<string> Roles { get; set; }
    }

    public partial class GetRolesFunction : GetRolesFunctionBase { }

    [Function("getRoles", "address[]")]
    public class GetRolesFunctionBase : FunctionMessage
    {

    }

    public partial class GetStakeholderFunction : GetStakeholderFunctionBase { }

    [Function("getStakeholder", typeof(GetStakeholderOutputDTO))]
    public class GetStakeholderFunctionBase : FunctionMessage
    {

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

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class RolesFunction : RolesFunctionBase { }

    [Function("roles", "address")]
    public class RolesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class StakeholderTypeFunction : StakeholderTypeFunctionBase { }

    [Function("stakeholderType", "uint8")]
    public class StakeholderTypeFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdateStakeholderFunction : UpdateStakeholderFunctionBase { }

    [Function("updateStakeholder")]
    public class UpdateStakeholderFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint8", "_stakeholderType", 2)]
        public virtual byte StakeholderType { get; set; }
        [Parameter("address[]", "_newRoles", 3)]
        public virtual List<string> NewRoles { get; set; }
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

    public partial class GetRolesOutputDTO : GetRolesOutputDTOBase { }

    [FunctionOutput]
    public class GetRolesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetStakeholderOutputDTO : GetStakeholderOutputDTOBase { }

    [FunctionOutput]
    public class GetStakeholderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual StakeholderResponse ReturnValue1 { get; set; }
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



    public partial class RolesOutputDTO : RolesOutputDTOBase { }

    [FunctionOutput]
    public class RolesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StakeholderTypeOutputDTO : StakeholderTypeOutputDTOBase { }

    [FunctionOutput]
    public class StakeholderTypeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }




}
