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
using StratML.Contracts.Organization.ContractDefinition;

namespace StratML.Contracts.Organization
{
    public partial class OrganizationService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OrganizationDeployment organizationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OrganizationDeployment>().SendRequestAndWaitForReceiptAsync(organizationDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OrganizationDeployment organizationDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OrganizationDeployment>().SendRequestAsync(organizationDeployment);
        }

        public static async Task<OrganizationService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OrganizationDeployment organizationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, organizationDeployment, cancellationTokenSource);
            return new OrganizationService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OrganizationService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public OrganizationService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AcryonymQueryAsync(AcryonymFunction acryonymFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AcryonymFunction, string>(acryonymFunction, blockParameter);
        }

        
        public Task<string> AcryonymQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AcryonymFunction, string>(null, blockParameter);
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

        public Task<GetOrganizationResponseOutputDTO> GetOrganizationResponseQueryAsync(GetOrganizationResponseFunction getOrganizationResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganizationResponseFunction, GetOrganizationResponseOutputDTO>(getOrganizationResponseFunction, blockParameter);
        }

        public Task<GetOrganizationResponseOutputDTO> GetOrganizationResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganizationResponseFunction, GetOrganizationResponseOutputDTO>(null, blockParameter);
        }

        public Task<GetOrganizationResponseBasedOutputDTO> GetOrganizationResponseBasedQueryAsync(GetOrganizationResponseBasedFunction getOrganizationResponseBasedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganizationResponseBasedFunction, GetOrganizationResponseBasedOutputDTO>(getOrganizationResponseBasedFunction, blockParameter);
        }

        public Task<GetOrganizationResponseBasedOutputDTO> GetOrganizationResponseBasedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganizationResponseBasedFunction, GetOrganizationResponseBasedOutputDTO>(null, blockParameter);
        }

        public Task<List<string>> GetStakeholdersQueryAsync(GetStakeholdersFunction getStakeholdersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakeholdersFunction, List<string>>(getStakeholdersFunction, blockParameter);
        }

        
        public Task<List<string>> GetStakeholdersQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakeholdersFunction, List<string>>(null, blockParameter);
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
