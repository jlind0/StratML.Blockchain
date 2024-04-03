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
using StratML.Contracts.Goal.ContractDefinition;

namespace StratML.Contracts.Goal
{
    public partial class GoalService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, GoalDeployment goalDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<GoalDeployment>().SendRequestAndWaitForReceiptAsync(goalDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, GoalDeployment goalDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<GoalDeployment>().SendRequestAsync(goalDeployment);
        }

        public static async Task<GoalService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, GoalDeployment goalDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, goalDeployment, cancellationTokenSource);
            return new GoalService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public GoalService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public GoalService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddObjectiveRequestAsync(AddObjectiveFunction addObjectiveFunction)
        {
             return ContractHandler.SendRequestAsync(addObjectiveFunction);
        }

        public Task<TransactionReceipt> AddObjectiveRequestAndWaitForReceiptAsync(AddObjectiveFunction addObjectiveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addObjectiveFunction, cancellationToken);
        }

        public Task<string> AddObjectiveRequestAsync(string objectiveAddress)
        {
            var addObjectiveFunction = new AddObjectiveFunction();
                addObjectiveFunction.ObjectiveAddress = objectiveAddress;
            
             return ContractHandler.SendRequestAsync(addObjectiveFunction);
        }

        public Task<TransactionReceipt> AddObjectiveRequestAndWaitForReceiptAsync(string objectiveAddress, CancellationTokenSource cancellationToken = null)
        {
            var addObjectiveFunction = new AddObjectiveFunction();
                addObjectiveFunction.ObjectiveAddress = objectiveAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addObjectiveFunction, cancellationToken);
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

        public Task<GetGoalResponseOutputDTO> GetGoalResponseQueryAsync(GetGoalResponseFunction getGoalResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetGoalResponseFunction, GetGoalResponseOutputDTO>(getGoalResponseFunction, blockParameter);
        }

        public Task<GetGoalResponseOutputDTO> GetGoalResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetGoalResponseFunction, GetGoalResponseOutputDTO>(null, blockParameter);
        }

        public Task<GetGoalResponseBaseOutputDTO> GetGoalResponseBaseQueryAsync(GetGoalResponseBaseFunction getGoalResponseBaseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetGoalResponseBaseFunction, GetGoalResponseBaseOutputDTO>(getGoalResponseBaseFunction, blockParameter);
        }

        public Task<GetGoalResponseBaseOutputDTO> GetGoalResponseBaseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetGoalResponseBaseFunction, GetGoalResponseBaseOutputDTO>(null, blockParameter);
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

        public Task<string> RegistryQueryAsync(RegistryFunction registryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistryFunction, string>(registryFunction, blockParameter);
        }

        
        public Task<string> RegistryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistryFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveObjectiveRequestAsync(RemoveObjectiveFunction removeObjectiveFunction)
        {
             return ContractHandler.SendRequestAsync(removeObjectiveFunction);
        }

        public Task<TransactionReceipt> RemoveObjectiveRequestAndWaitForReceiptAsync(RemoveObjectiveFunction removeObjectiveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeObjectiveFunction, cancellationToken);
        }

        public Task<string> RemoveObjectiveRequestAsync(string objectiveAddress)
        {
            var removeObjectiveFunction = new RemoveObjectiveFunction();
                removeObjectiveFunction.ObjectiveAddress = objectiveAddress;
            
             return ContractHandler.SendRequestAsync(removeObjectiveFunction);
        }

        public Task<TransactionReceipt> RemoveObjectiveRequestAndWaitForReceiptAsync(string objectiveAddress, CancellationTokenSource cancellationToken = null)
        {
            var removeObjectiveFunction = new RemoveObjectiveFunction();
                removeObjectiveFunction.ObjectiveAddress = objectiveAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeObjectiveFunction, cancellationToken);
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
    }
}
