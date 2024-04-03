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
using StratML.Contracts.Objective.ContractDefinition;

namespace StratML.Contracts.Objective
{
    public partial class ObjectiveService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ObjectiveDeployment objectiveDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ObjectiveDeployment>().SendRequestAndWaitForReceiptAsync(objectiveDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ObjectiveDeployment objectiveDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ObjectiveDeployment>().SendRequestAsync(objectiveDeployment);
        }

        public static async Task<ObjectiveService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ObjectiveDeployment objectiveDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, objectiveDeployment, cancellationTokenSource);
            return new ObjectiveService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ObjectiveService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public ObjectiveService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddPerformanceIndicatorRequestAsync(AddPerformanceIndicatorFunction addPerformanceIndicatorFunction)
        {
             return ContractHandler.SendRequestAsync(addPerformanceIndicatorFunction);
        }

        public Task<TransactionReceipt> AddPerformanceIndicatorRequestAndWaitForReceiptAsync(AddPerformanceIndicatorFunction addPerformanceIndicatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPerformanceIndicatorFunction, cancellationToken);
        }

        public Task<string> AddPerformanceIndicatorRequestAsync(string performanceIndicatorAddress)
        {
            var addPerformanceIndicatorFunction = new AddPerformanceIndicatorFunction();
                addPerformanceIndicatorFunction.PerformanceIndicatorAddress = performanceIndicatorAddress;
            
             return ContractHandler.SendRequestAsync(addPerformanceIndicatorFunction);
        }

        public Task<TransactionReceipt> AddPerformanceIndicatorRequestAndWaitForReceiptAsync(string performanceIndicatorAddress, CancellationTokenSource cancellationToken = null)
        {
            var addPerformanceIndicatorFunction = new AddPerformanceIndicatorFunction();
                addPerformanceIndicatorFunction.PerformanceIndicatorAddress = performanceIndicatorAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPerformanceIndicatorFunction, cancellationToken);
        }

        public Task<string> AddStakeholderRequestAsync(AddStakeholderFunction addStakeholderFunction)
        {
             return ContractHandler.SendRequestAsync(addStakeholderFunction);
        }

        public Task<TransactionReceipt> AddStakeholderRequestAndWaitForReceiptAsync(AddStakeholderFunction addStakeholderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addStakeholderFunction, cancellationToken);
        }

        public Task<string> AddStakeholderRequestAsync(string stakeholderAddress)
        {
            var addStakeholderFunction = new AddStakeholderFunction();
                addStakeholderFunction.StakeholderAddress = stakeholderAddress;
            
             return ContractHandler.SendRequestAsync(addStakeholderFunction);
        }

        public Task<TransactionReceipt> AddStakeholderRequestAndWaitForReceiptAsync(string stakeholderAddress, CancellationTokenSource cancellationToken = null)
        {
            var addStakeholderFunction = new AddStakeholderFunction();
                addStakeholderFunction.StakeholderAddress = stakeholderAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addStakeholderFunction, cancellationToken);
        }

        public Task<string> DescriptionQueryAsync(DescriptionFunction descriptionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(descriptionFunction, blockParameter);
        }

        
        public Task<string> DescriptionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(null, blockParameter);
        }

        public Task<GetObjectiveResponseOutputDTO> GetObjectiveResponseQueryAsync(GetObjectiveResponseFunction getObjectiveResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetObjectiveResponseFunction, GetObjectiveResponseOutputDTO>(getObjectiveResponseFunction, blockParameter);
        }

        public Task<GetObjectiveResponseOutputDTO> GetObjectiveResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetObjectiveResponseFunction, GetObjectiveResponseOutputDTO>(null, blockParameter);
        }

        public Task<GetObjectiveResponseBaseOutputDTO> GetObjectiveResponseBaseQueryAsync(GetObjectiveResponseBaseFunction getObjectiveResponseBaseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetObjectiveResponseBaseFunction, GetObjectiveResponseBaseOutputDTO>(getObjectiveResponseBaseFunction, blockParameter);
        }

        public Task<GetObjectiveResponseBaseOutputDTO> GetObjectiveResponseBaseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetObjectiveResponseBaseFunction, GetObjectiveResponseBaseOutputDTO>(null, blockParameter);
        }

        public Task<List<string>> GetPerformanceIndicatorsQueryAsync(GetPerformanceIndicatorsFunction getPerformanceIndicatorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPerformanceIndicatorsFunction, List<string>>(getPerformanceIndicatorsFunction, blockParameter);
        }

        
        public Task<List<string>> GetPerformanceIndicatorsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPerformanceIndicatorsFunction, List<string>>(null, blockParameter);
        }

        public Task<List<string>> GetStakeholdersQueryAsync(GetStakeholdersFunction getStakeholdersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakeholdersFunction, List<string>>(getStakeholdersFunction, blockParameter);
        }

        
        public Task<List<string>> GetStakeholdersQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakeholdersFunction, List<string>>(null, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OtherInformationQueryAsync(OtherInformationFunction otherInformationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OtherInformationFunction, string>(otherInformationFunction, blockParameter);
        }

        
        public Task<string> OtherInformationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OtherInformationFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> RemovePerformanceIndicatorRequestAsync(RemovePerformanceIndicatorFunction removePerformanceIndicatorFunction)
        {
             return ContractHandler.SendRequestAsync(removePerformanceIndicatorFunction);
        }

        public Task<TransactionReceipt> RemovePerformanceIndicatorRequestAndWaitForReceiptAsync(RemovePerformanceIndicatorFunction removePerformanceIndicatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePerformanceIndicatorFunction, cancellationToken);
        }

        public Task<string> RemovePerformanceIndicatorRequestAsync(string performanceIndicatorAddress)
        {
            var removePerformanceIndicatorFunction = new RemovePerformanceIndicatorFunction();
                removePerformanceIndicatorFunction.PerformanceIndicatorAddress = performanceIndicatorAddress;
            
             return ContractHandler.SendRequestAsync(removePerformanceIndicatorFunction);
        }

        public Task<TransactionReceipt> RemovePerformanceIndicatorRequestAndWaitForReceiptAsync(string performanceIndicatorAddress, CancellationTokenSource cancellationToken = null)
        {
            var removePerformanceIndicatorFunction = new RemovePerformanceIndicatorFunction();
                removePerformanceIndicatorFunction.PerformanceIndicatorAddress = performanceIndicatorAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePerformanceIndicatorFunction, cancellationToken);
        }

        public Task<string> RemoveStakeholderRequestAsync(RemoveStakeholderFunction removeStakeholderFunction)
        {
             return ContractHandler.SendRequestAsync(removeStakeholderFunction);
        }

        public Task<TransactionReceipt> RemoveStakeholderRequestAndWaitForReceiptAsync(RemoveStakeholderFunction removeStakeholderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeStakeholderFunction, cancellationToken);
        }

        public Task<string> RemoveStakeholderRequestAsync(string stakeholderAddress)
        {
            var removeStakeholderFunction = new RemoveStakeholderFunction();
                removeStakeholderFunction.StakeholderAddress = stakeholderAddress;
            
             return ContractHandler.SendRequestAsync(removeStakeholderFunction);
        }

        public Task<TransactionReceipt> RemoveStakeholderRequestAndWaitForReceiptAsync(string stakeholderAddress, CancellationTokenSource cancellationToken = null)
        {
            var removeStakeholderFunction = new RemoveStakeholderFunction();
                removeStakeholderFunction.StakeholderAddress = stakeholderAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeStakeholderFunction, cancellationToken);
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

        public Task<string> SequenceIndicatorQueryAsync(SequenceIndicatorFunction sequenceIndicatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SequenceIndicatorFunction, string>(sequenceIndicatorFunction, blockParameter);
        }

        
        public Task<string> SequenceIndicatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SequenceIndicatorFunction, string>(null, blockParameter);
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
    }
}
