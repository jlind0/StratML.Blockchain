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
using StratML.Contracts.AdministrativeInformation.ContractDefinition;

namespace StratML.Contracts.AdministrativeInformation
{
    public partial class AdministrativeInformationService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AdministrativeInformationDeployment administrativeInformationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AdministrativeInformationDeployment>().SendRequestAndWaitForReceiptAsync(administrativeInformationDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AdministrativeInformationDeployment administrativeInformationDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AdministrativeInformationDeployment>().SendRequestAsync(administrativeInformationDeployment);
        }

        public static async Task<AdministrativeInformationService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AdministrativeInformationDeployment administrativeInformationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, administrativeInformationDeployment, cancellationTokenSource);
            return new AdministrativeInformationService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AdministrativeInformationService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AdministrativeInformationService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> EndDateQueryAsync(EndDateFunction endDateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EndDateFunction, BigInteger>(endDateFunction, blockParameter);
        }

        
        public Task<BigInteger> EndDateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EndDateFunction, BigInteger>(null, blockParameter);
        }

        public Task<GetAdministrativeInformationResponseOutputDTO> GetAdministrativeInformationResponseQueryAsync(GetAdministrativeInformationResponseFunction getAdministrativeInformationResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAdministrativeInformationResponseFunction, GetAdministrativeInformationResponseOutputDTO>(getAdministrativeInformationResponseFunction, blockParameter);
        }

        public Task<GetAdministrativeInformationResponseOutputDTO> GetAdministrativeInformationResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAdministrativeInformationResponseFunction, GetAdministrativeInformationResponseOutputDTO>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> PublicationDateQueryAsync(PublicationDateFunction publicationDateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PublicationDateFunction, BigInteger>(publicationDateFunction, blockParameter);
        }

        
        public Task<BigInteger> PublicationDateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PublicationDateFunction, BigInteger>(null, blockParameter);
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

        public Task<string> SourceQueryAsync(SourceFunction sourceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SourceFunction, string>(sourceFunction, blockParameter);
        }

        
        public Task<string> SourceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SourceFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> StartDateQueryAsync(StartDateFunction startDateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StartDateFunction, BigInteger>(startDateFunction, blockParameter);
        }

        
        public Task<BigInteger> StartDateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StartDateFunction, BigInteger>(null, blockParameter);
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

        public Task<string> UpdateAdministrativeInformationRequestAsync(UpdateAdministrativeInformationFunction updateAdministrativeInformationFunction)
        {
             return ContractHandler.SendRequestAsync(updateAdministrativeInformationFunction);
        }

        public Task<TransactionReceipt> UpdateAdministrativeInformationRequestAndWaitForReceiptAsync(UpdateAdministrativeInformationFunction updateAdministrativeInformationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateAdministrativeInformationFunction, cancellationToken);
        }

        public Task<string> UpdateAdministrativeInformationRequestAsync(BigInteger startDate, BigInteger endDate, BigInteger publicationDate, string source)
        {
            var updateAdministrativeInformationFunction = new UpdateAdministrativeInformationFunction();
                updateAdministrativeInformationFunction.StartDate = startDate;
                updateAdministrativeInformationFunction.EndDate = endDate;
                updateAdministrativeInformationFunction.PublicationDate = publicationDate;
                updateAdministrativeInformationFunction.Source = source;
            
             return ContractHandler.SendRequestAsync(updateAdministrativeInformationFunction);
        }

        public Task<TransactionReceipt> UpdateAdministrativeInformationRequestAndWaitForReceiptAsync(BigInteger startDate, BigInteger endDate, BigInteger publicationDate, string source, CancellationTokenSource cancellationToken = null)
        {
            var updateAdministrativeInformationFunction = new UpdateAdministrativeInformationFunction();
                updateAdministrativeInformationFunction.StartDate = startDate;
                updateAdministrativeInformationFunction.EndDate = endDate;
                updateAdministrativeInformationFunction.PublicationDate = publicationDate;
                updateAdministrativeInformationFunction.Source = source;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateAdministrativeInformationFunction, cancellationToken);
        }
    }
}
