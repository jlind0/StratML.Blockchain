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
using StratML.Contracts.OwnableOrSiblings.ContractDefinition;

namespace StratML.Contracts.OwnableOrSiblings
{
    public partial class OwnableOrSiblingsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OwnableOrSiblingsDeployment ownableOrSiblingsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OwnableOrSiblingsDeployment>().SendRequestAndWaitForReceiptAsync(ownableOrSiblingsDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OwnableOrSiblingsDeployment ownableOrSiblingsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OwnableOrSiblingsDeployment>().SendRequestAsync(ownableOrSiblingsDeployment);
        }

        public static async Task<OwnableOrSiblingsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OwnableOrSiblingsDeployment ownableOrSiblingsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, ownableOrSiblingsDeployment, cancellationTokenSource);
            return new OwnableOrSiblingsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OwnableOrSiblingsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public OwnableOrSiblingsService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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
