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
using StratML.Contracts.Mission.ContractDefinition;

namespace StratML.Contracts.Mission
{
    public partial class MissionService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MissionDeployment missionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MissionDeployment>().SendRequestAndWaitForReceiptAsync(missionDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MissionDeployment missionDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MissionDeployment>().SendRequestAsync(missionDeployment);
        }

        public static async Task<MissionService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MissionDeployment missionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, missionDeployment, cancellationTokenSource);
            return new MissionService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MissionService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public MissionService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DescriptionQueryAsync(DescriptionFunction descriptionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(descriptionFunction, blockParameter);
        }

        
        public Task<string> DescriptionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(null, blockParameter);
        }

        public Task<GetMissionResponseOutputDTO> GetMissionResponseQueryAsync(GetMissionResponseFunction getMissionResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMissionResponseFunction, GetMissionResponseOutputDTO>(getMissionResponseFunction, blockParameter);
        }

        public Task<GetMissionResponseOutputDTO> GetMissionResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMissionResponseFunction, GetMissionResponseOutputDTO>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
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

        public Task<string> UpdateMissionRequestAsync(UpdateMissionFunction updateMissionFunction)
        {
             return ContractHandler.SendRequestAsync(updateMissionFunction);
        }

        public Task<TransactionReceipt> UpdateMissionRequestAndWaitForReceiptAsync(UpdateMissionFunction updateMissionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateMissionFunction, cancellationToken);
        }

        public Task<string> UpdateMissionRequestAsync(string description)
        {
            var updateMissionFunction = new UpdateMissionFunction();
                updateMissionFunction.Description = description;
            
             return ContractHandler.SendRequestAsync(updateMissionFunction);
        }

        public Task<TransactionReceipt> UpdateMissionRequestAndWaitForReceiptAsync(string description, CancellationTokenSource cancellationToken = null)
        {
            var updateMissionFunction = new UpdateMissionFunction();
                updateMissionFunction.Description = description;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateMissionFunction, cancellationToken);
        }
    }
}
