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

namespace StratML.Contracts.Relationship.ContractDefinition
{


    public partial class RelationshipDeployment : RelationshipDeploymentBase
    {
        public RelationshipDeployment() : base(BYTECODE) { }
        public RelationshipDeployment(string byteCode) : base(byteCode) { }
    }

    public class RelationshipDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b506040516200113d3803806200113d8339810160408190526200003391620001c3565b33806200005957604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b6200006481620000b3565b506001620000738482620002ca565b506002620000828382620002ca565b506003805482919060ff19166001836002811115620000a557620000a562000396565b0217905550505050620003aa565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f82601f83011262000126575f80fd5b81516001600160401b038082111562000143576200014362000102565b604051601f8301601f19908116603f011681019082821181831017156200016e576200016e62000102565b81604052838152602092508660208588010111156200018b575f80fd5b5f91505b83821015620001ae57858201830151818301840152908201906200018f565b5f602085830101528094505050505092915050565b5f805f60608486031215620001d6575f80fd5b83516001600160401b0380821115620001ed575f80fd5b620001fb8783880162000116565b9450602086015191508082111562000211575f80fd5b50620002208682870162000116565b92505060408401516003811062000235575f80fd5b809150509250925092565b600181811c908216806200025557607f821691505b6020821081036200027457634e487b7160e01b5f52602260045260245ffd5b50919050565b601f821115620002c557805f5260205f20601f840160051c81016020851015620002a15750805b601f840160051c820191505b81811015620002c2575f8155600101620002ad565b50505b505050565b81516001600160401b03811115620002e657620002e662000102565b620002fe81620002f7845462000240565b846200027a565b602080601f83116001811462000334575f84156200031c5750858301515b5f19600386901b1c1916600185901b1785556200038e565b5f85815260208120601f198616915b82811015620003645788860151825594840194600190910190840162000343565b50858210156200038257878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b634e487b7160e01b5f52602160045260245ffd5b610d8580620003b85f395ff3fe608060405234801561000f575f80fd5b50600436106100a6575f3560e01c8063715018a61161006e578063715018a61461011d57806371c11167146101255780637284e4161461013a5780637a6337fa146101425780638da5cb5b14610157578063f2fde38b14610171575f80fd5b806306fdde03146100aa578063207a96c6146100c857806323bab50b146100dd57806349bf7df5146100f0578063544ab05f1461010a575b5f80fd5b6100b2610184565b6040516100bf91906108b1565b60405180910390f35b6100db6100d6366004610967565b610210565b005b6100db6100eb3660046109f8565b61025b565b6003546100fd9060ff1681565b6040516100bf9190610a39565b6100db610118366004610a4d565b61037f565b6100db6104af565b61012d6104c2565b6040516100bf9190610ab7565b6100b26106c4565b61014a6106d1565b6040516100bf9190610b6e565b5f546040516001600160a01b0390911681526020016100bf565b6100db61017f3660046109f8565b61076b565b6001805461019190610bb6565b80601f01602080910402602001604051908101604052809291908181526020018280546101bd90610bb6565b80156102085780601f106101df57610100808354040283529160200191610208565b820191905f5260205f20905b8154815290600101906020018083116101eb57829003601f168201915b505050505081565b6102186107ad565b60016102248482610c3a565b5060026102318382610c3a565b506003805482919060ff1916600183600281111561025157610251610a11565b0217905550505050565b6102636107ad565b5f5b60045481101561037b57816001600160a01b03166004828154811061028c5761028c610cfa565b5f9182526020909120015461010090046001600160a01b03160361037357600480546102ba90600190610d0e565b815481106102ca576102ca610cfa565b905f5260205f2001600482815481106102e5576102e5610cfa565b5f9182526020909120825491018054909160ff1690829060ff1916600183600581111561031457610314610a11565b021790555090548154610100600160a81b031916610100918290046001600160a01b0316909102179055600480548061034f5761034f610d2d565b5f8281526020902081015f1990810180546001600160a81b03191690550190555050565b600101610265565b5050565b6103876107ad565b5f5b6004548110156103db57816001600160a01b0316600482815481106103b0576103b0610cfa565b5f9182526020909120015461010090046001600160a01b0316036103d357505050565b600101610389565b50600460405180604001604052808460058111156103fb576103fb610a11565b81526001600160a01b0384166020918201528254600181810185555f94855291909320825193018054929390929091839160ff19169083600581111561044357610443610a11565b0217905550602091909101518154610100600160a81b0319166101006001600160a01b039283160217909155604051908216907f042b7cb8ce065e7fe93f80e02c6be61d194f13e750c3c2a4be0f408076e66baf906104a3908590610d41565b60405180910390a25050565b6104b76107ad565b6104c05f6107d9565b565b6104ca610828565b6104d2610828565b308152600180546104e290610bb6565b80601f016020809104026020016040519081016040528092919081815260200182805461050e90610bb6565b80156105595780601f1061053057610100808354040283529160200191610559565b820191905f5260205f20905b81548152906001019060200180831161053c57829003601f168201915b505050505081604001819052506002805461057390610bb6565b80601f016020809104026020016040519081016040528092919081815260200182805461059f90610bb6565b80156105ea5780601f106105c1576101008083540402835291602001916105ea565b820191905f5260205f20905b8154815290600101906020018083116105cd57829003601f168201915b50505050506060820152600354608082019060ff16600281111561061057610610610a11565b9081600281111561062357610623610a11565b815250506004805480602002602001604051908101604052809291908181526020015f905b828210156106b6575f84815260209020604080518082019091529083018054829060ff16600581111561067d5761067d610a11565b600581111561068e5761068e610a11565b8152905461010090046001600160a01b03166020918201529082526001929092019101610648565b505050506020820152919050565b6002805461019190610bb6565b60606004805480602002602001604051908101604052809291908181526020015f905b82821015610762575f84815260209020604080518082019091529083018054829060ff16600581111561072957610729610a11565b600581111561073a5761073a610a11565b8152905461010090046001600160a01b031660209182015290825260019290920191016106f4565b50505050905090565b6107736107ad565b6001600160a01b0381166107a157604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b6107aa816107d9565b50565b5f546001600160a01b031633146104c05760405163118cdaa760e01b8152336004820152602401610798565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b031681526020016060815260200160608152602001606081526020015f600281111561086957610869610a11565b905290565b5f81518084525f5b8181101561089257602081850181015186830182015201610876565b505f602082860101526020601f19601f83011685010191505092915050565b602081525f6108c3602083018461086e565b9392505050565b634e487b7160e01b5f52604160045260245ffd5b5f82601f8301126108ed575f80fd5b813567ffffffffffffffff80821115610908576109086108ca565b604051601f8301601f19908116603f01168101908282118183101715610930576109306108ca565b81604052838152866020858801011115610948575f80fd5b836020870160208301375f602085830101528094505050505092915050565b5f805f60608486031215610979575f80fd5b833567ffffffffffffffff80821115610990575f80fd5b61099c878388016108de565b945060208601359150808211156109b1575f80fd5b506109be868287016108de565b9250506040840135600381106109d2575f80fd5b809150509250925092565b80356001600160a01b03811681146109f3575f80fd5b919050565b5f60208284031215610a08575f80fd5b6108c3826109dd565b634e487b7160e01b5f52602160045260245ffd5b60038110610a3557610a35610a11565b9052565b60208101610a478284610a25565b92915050565b5f8060408385031215610a5e575f80fd5b823560068110610a6c575f80fd5b9150610a7a602084016109dd565b90509250929050565b60068110610a3557610a35610a11565b610a9e828251610a83565b6020908101516001600160a01b03169082015260400190565b602080825282516001600160a01b0316828201528281015160a06040840152805160c084018190525f9291820190839060e08601905b80831015610b1257610b00828551610a93565b91508484019350600183019250610aed565b5060408701519350601f19925082868203016060870152610b33818561086e565b93505050606085015181858403016080860152610b50838261086e565b925050506080840151610b6660a0850182610a25565b509392505050565b602080825282518282018190525f9190848201906040850190845b81811015610baa57610b9c838551610a93565b938501939250600101610b89565b50909695505050505050565b600181811c90821680610bca57607f821691505b602082108103610be857634e487b7160e01b5f52602260045260245ffd5b50919050565b601f821115610c3557805f5260205f20601f840160051c81016020851015610c135750805b601f840160051c820191505b81811015610c32575f8155600101610c1f565b50505b505050565b815167ffffffffffffffff811115610c5457610c546108ca565b610c6881610c628454610bb6565b84610bee565b602080601f831160018114610c9b575f8415610c845750858301515b5f19600386901b1c1916600185901b178555610cf2565b5f85815260208120601f198616915b82811015610cc957888601518255948401946001909101908401610caa565b5085821015610ce657878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b634e487b7160e01b5f52603260045260245ffd5b81810381811115610a4757634e487b7160e01b5f52601160045260245ffd5b634e487b7160e01b5f52603160045260245ffd5b60208101610a478284610a8356fea2646970667358221220add0119cde20899ad685289a48afa33d91eb7f7ec9f01d44d4369c2115291f8c64736f6c63430008170033";
        public RelationshipDeploymentBase() : base(BYTECODE) { }
        public RelationshipDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 2)]
        public virtual string Description { get; set; }
        [Parameter("uint8", "_relationshipType", 3)]
        public virtual byte RelationshipType { get; set; }
    }

    public partial class AddReferenceFunction : AddReferenceFunctionBase { }

    [Function("addReference")]
    public class AddReferenceFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "_entityType", 1)]
        public virtual byte EntityType { get; set; }
        [Parameter("address", "_identifier", 2)]
        public virtual string Identifier { get; set; }
    }

    public partial class DescriptionFunction : DescriptionFunctionBase { }

    [Function("description", "string")]
    public class DescriptionFunctionBase : FunctionMessage
    {

    }

    public partial class GetReferencesFunction : GetReferencesFunctionBase { }

    [Function("getReferences", typeof(GetReferencesOutputDTO))]
    public class GetReferencesFunctionBase : FunctionMessage
    {

    }

    public partial class GetRelationshipFunction : GetRelationshipFunctionBase { }

    [Function("getRelationship", typeof(GetRelationshipOutputDTO))]
    public class GetRelationshipFunctionBase : FunctionMessage
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

    public partial class RelationshipTypeFunction : RelationshipTypeFunctionBase { }

    [Function("relationshipType", "uint8")]
    public class RelationshipTypeFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveReferenceFunction : RemoveReferenceFunctionBase { }

    [Function("removeReference")]
    public class RemoveReferenceFunctionBase : FunctionMessage
    {
        [Parameter("address", "_identifier", 1)]
        public virtual string Identifier { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdateRelationshipFunction : UpdateRelationshipFunctionBase { }

    [Function("updateRelationship")]
    public class UpdateRelationshipFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 2)]
        public virtual string Description { get; set; }
        [Parameter("uint8", "_relationshipType", 3)]
        public virtual byte RelationshipType { get; set; }
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

    public partial class ReferenceAddedEventDTO : ReferenceAddedEventDTOBase { }

    [Event("ReferenceAdded")]
    public class ReferenceAddedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "entityType", 1, false )]
        public virtual byte EntityType { get; set; }
        [Parameter("address", "identifier", 2, true )]
        public virtual string Identifier { get; set; }
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

    public partial class GetReferencesOutputDTO : GetReferencesOutputDTOBase { }

    [FunctionOutput]
    public class GetReferencesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<Reference> ReturnValue1 { get; set; }
    }

    public partial class GetRelationshipOutputDTO : GetRelationshipOutputDTOBase { }

    [FunctionOutput]
    public class GetRelationshipOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual RelationshipResponse ReturnValue1 { get; set; }
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

    public partial class RelationshipTypeOutputDTO : RelationshipTypeOutputDTOBase { }

    [FunctionOutput]
    public class RelationshipTypeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }








}
