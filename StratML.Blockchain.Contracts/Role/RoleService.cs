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
using StratML.Contracts.Role.ContractDefinition;

namespace StratML.Contracts.Role
{
    public partial class RoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, RoleDeployment roleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RoleDeployment>().SendRequestAndWaitForReceiptAsync(roleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, RoleDeployment roleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RoleDeployment>().SendRequestAsync(roleDeployment);
        }

        public static async Task<RoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, RoleDeployment roleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, roleDeployment, cancellationTokenSource);
            return new RoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public RoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public RoleService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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

        public Task<GetRoleOutputDTO> GetRoleQueryAsync(GetRoleFunction getRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRoleFunction, GetRoleOutputDTO>(getRoleFunction, blockParameter);
        }

        public Task<GetRoleOutputDTO> GetRoleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRoleFunction, GetRoleOutputDTO>(null, blockParameter);
        }

        public Task<List<string>> GetStakeholderAddressesQueryAsync(GetStakeholderAddressesFunction getStakeholderAddressesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakeholderAddressesFunction, List<string>>(getStakeholderAddressesFunction, blockParameter);
        }

        
        public Task<List<string>> GetStakeholderAddressesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakeholderAddressesFunction, List<string>>(null, blockParameter);
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

        public Task<byte> RoleTypeQueryAsync(RoleTypeFunction roleTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RoleTypeFunction, byte>(roleTypeFunction, blockParameter);
        }

        
        public Task<byte> RoleTypeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RoleTypeFunction, byte>(null, blockParameter);
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

        public Task<string> UpdateRoleRequestAsync(UpdateRoleFunction updateRoleFunction)
        {
             return ContractHandler.SendRequestAsync(updateRoleFunction);
        }

        public Task<TransactionReceipt> UpdateRoleRequestAndWaitForReceiptAsync(UpdateRoleFunction updateRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRoleFunction, cancellationToken);
        }

        public Task<string> UpdateRoleRequestAsync(string name, string description, byte roleType)
        {
            var updateRoleFunction = new UpdateRoleFunction();
                updateRoleFunction.Name = name;
                updateRoleFunction.Description = description;
                updateRoleFunction.RoleType = roleType;
            
             return ContractHandler.SendRequestAsync(updateRoleFunction);
        }

        public Task<TransactionReceipt> UpdateRoleRequestAndWaitForReceiptAsync(string name, string description, byte roleType, CancellationTokenSource cancellationToken = null)
        {
            var updateRoleFunction = new UpdateRoleFunction();
                updateRoleFunction.Name = name;
                updateRoleFunction.Description = description;
                updateRoleFunction.RoleType = roleType;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRoleFunction, cancellationToken);
        }
    }
}
