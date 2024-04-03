using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using StratML.Contracts.Relationship.ContractDefinition;

namespace StratML.Contracts.Relationship
{
    public partial class RelationshipService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, RelationshipDeployment relationshipDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RelationshipDeployment>().SendRequestAndWaitForReceiptAsync(relationshipDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, RelationshipDeployment relationshipDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RelationshipDeployment>().SendRequestAsync(relationshipDeployment);
        }

        public static async Task<RelationshipService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, RelationshipDeployment relationshipDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, relationshipDeployment, cancellationTokenSource);
            return new RelationshipService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public RelationshipService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public RelationshipService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddReferenceRequestAsync(AddReferenceFunction addReferenceFunction)
        {
             return ContractHandler.SendRequestAsync(addReferenceFunction);
        }

        public Task<TransactionReceipt> AddReferenceRequestAndWaitForReceiptAsync(AddReferenceFunction addReferenceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addReferenceFunction, cancellationToken);
        }

        public Task<string> AddReferenceRequestAsync(byte entityType, string identifier)
        {
            var addReferenceFunction = new AddReferenceFunction();
                addReferenceFunction.EntityType = entityType;
                addReferenceFunction.Identifier = identifier;
            
             return ContractHandler.SendRequestAsync(addReferenceFunction);
        }

        public Task<TransactionReceipt> AddReferenceRequestAndWaitForReceiptAsync(byte entityType, string identifier, CancellationTokenSource cancellationToken = null)
        {
            var addReferenceFunction = new AddReferenceFunction();
                addReferenceFunction.EntityType = entityType;
                addReferenceFunction.Identifier = identifier;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addReferenceFunction, cancellationToken);
        }

        public Task<string> AddSiblingRequestAsync(AddSiblingFunction addSiblingFunction)
        {
             return ContractHandler.SendRequestAsync(addSiblingFunction);
        }

        public Task<TransactionReceipt> AddSiblingRequestAndWaitForReceiptAsync(AddSiblingFunction addSiblingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSiblingFunction, cancellationToken);
        }

        public Task<string> AddSiblingRequestAsync(string sibling)
        {
            var addSiblingFunction = new AddSiblingFunction();
                addSiblingFunction.Sibling = sibling;
            
             return ContractHandler.SendRequestAsync(addSiblingFunction);
        }

        public Task<TransactionReceipt> AddSiblingRequestAndWaitForReceiptAsync(string sibling, CancellationTokenSource cancellationToken = null)
        {
            var addSiblingFunction = new AddSiblingFunction();
                addSiblingFunction.Sibling = sibling;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSiblingFunction, cancellationToken);
        }

        public Task<string> DescriptionQueryAsync(DescriptionFunction descriptionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(descriptionFunction, blockParameter);
        }

        
        public Task<string> DescriptionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(null, blockParameter);
        }

        public Task<GetReferencesOutputDTO> GetReferencesQueryAsync(GetReferencesFunction getReferencesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetReferencesFunction, GetReferencesOutputDTO>(getReferencesFunction, blockParameter);
        }

        public Task<GetReferencesOutputDTO> GetReferencesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetReferencesFunction, GetReferencesOutputDTO>(null, blockParameter);
        }

        public Task<GetRelationshipOutputDTO> GetRelationshipQueryAsync(GetRelationshipFunction getRelationshipFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRelationshipFunction, GetRelationshipOutputDTO>(getRelationshipFunction, blockParameter);
        }

        public Task<GetRelationshipOutputDTO> GetRelationshipQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRelationshipFunction, GetRelationshipOutputDTO>(null, blockParameter);
        }

        public Task<bool> IsSiblingQueryAsync(IsSiblingFunction isSiblingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsSiblingFunction, bool>(isSiblingFunction, blockParameter);
        }

        
        public Task<bool> IsSiblingQueryAsync(string sibling, BlockParameter blockParameter = null)
        {
            var isSiblingFunction = new IsSiblingFunction();
                isSiblingFunction.Sibling = sibling;
            
            return ContractHandler.QueryAsync<IsSiblingFunction, bool>(isSiblingFunction, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> RegistryQueryAsync(RegistryFunction registryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistryFunction, string>(registryFunction, blockParameter);
        }

        
        public Task<string> RegistryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistryFunction, string>(null, blockParameter);
        }

        public Task<byte> RelationshipTypeQueryAsync(RelationshipTypeFunction relationshipTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RelationshipTypeFunction, byte>(relationshipTypeFunction, blockParameter);
        }

        
        public Task<byte> RelationshipTypeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RelationshipTypeFunction, byte>(null, blockParameter);
        }

        public Task<string> RemoveReferenceRequestAsync(RemoveReferenceFunction removeReferenceFunction)
        {
             return ContractHandler.SendRequestAsync(removeReferenceFunction);
        }

        public Task<TransactionReceipt> RemoveReferenceRequestAndWaitForReceiptAsync(RemoveReferenceFunction removeReferenceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeReferenceFunction, cancellationToken);
        }

        public Task<string> RemoveReferenceRequestAsync(string identifier)
        {
            var removeReferenceFunction = new RemoveReferenceFunction();
                removeReferenceFunction.Identifier = identifier;
            
             return ContractHandler.SendRequestAsync(removeReferenceFunction);
        }

        public Task<TransactionReceipt> RemoveReferenceRequestAndWaitForReceiptAsync(string identifier, CancellationTokenSource cancellationToken = null)
        {
            var removeReferenceFunction = new RemoveReferenceFunction();
                removeReferenceFunction.Identifier = identifier;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeReferenceFunction, cancellationToken);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SiblingsQueryAsync(SiblingsFunction siblingsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SiblingsFunction, string>(siblingsFunction, blockParameter);
        }

        
        public Task<string> SiblingsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var siblingsFunction = new SiblingsFunction();
                siblingsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<SiblingsFunction, string>(siblingsFunction, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> UpdateRelationshipRequestAsync(UpdateRelationshipFunction updateRelationshipFunction)
        {
             return ContractHandler.SendRequestAsync(updateRelationshipFunction);
        }

        public Task<TransactionReceipt> UpdateRelationshipRequestAndWaitForReceiptAsync(UpdateRelationshipFunction updateRelationshipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRelationshipFunction, cancellationToken);
        }

        public Task<string> UpdateRelationshipRequestAsync(string name, string description, byte relationshipType)
        {
            var updateRelationshipFunction = new UpdateRelationshipFunction();
                updateRelationshipFunction.Name = name;
                updateRelationshipFunction.Description = description;
                updateRelationshipFunction.RelationshipType = relationshipType;
            
             return ContractHandler.SendRequestAsync(updateRelationshipFunction);
        }

        public Task<TransactionReceipt> UpdateRelationshipRequestAndWaitForReceiptAsync(string name, string description, byte relationshipType, CancellationTokenSource cancellationToken = null)
        {
            var updateRelationshipFunction = new UpdateRelationshipFunction();
                updateRelationshipFunction.Name = name;
                updateRelationshipFunction.Description = description;
                updateRelationshipFunction.RelationshipType = relationshipType;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRelationshipFunction, cancellationToken);
        }
    }
}
