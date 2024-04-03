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
using StratML.Contracts.ContactInformation.ContractDefinition;

namespace StratML.Contracts.ContactInformation
{
    public partial class ContactInformationService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ContactInformationDeployment contactInformationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ContactInformationDeployment>().SendRequestAndWaitForReceiptAsync(contactInformationDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ContactInformationDeployment contactInformationDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ContactInformationDeployment>().SendRequestAsync(contactInformationDeployment);
        }

        public static async Task<ContactInformationService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ContactInformationDeployment contactInformationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, contactInformationDeployment, cancellationTokenSource);
            return new ContactInformationService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ContactInformationService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public ContactInformationService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> EmailAddressQueryAsync(EmailAddressFunction emailAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EmailAddressFunction, string>(emailAddressFunction, blockParameter);
        }

        
        public Task<string> EmailAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EmailAddressFunction, string>(null, blockParameter);
        }

        public Task<GetContactInformationResponseOutputDTO> GetContactInformationResponseQueryAsync(GetContactInformationResponseFunction getContactInformationResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetContactInformationResponseFunction, GetContactInformationResponseOutputDTO>(getContactInformationResponseFunction, blockParameter);
        }

        public Task<GetContactInformationResponseOutputDTO> GetContactInformationResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetContactInformationResponseFunction, GetContactInformationResponseOutputDTO>(null, blockParameter);
        }

        public Task<string> GivenNameQueryAsync(GivenNameFunction givenNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GivenNameFunction, string>(givenNameFunction, blockParameter);
        }

        
        public Task<string> GivenNameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GivenNameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> PhoneNumberQueryAsync(PhoneNumberFunction phoneNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PhoneNumberFunction, string>(phoneNumberFunction, blockParameter);
        }

        
        public Task<string> PhoneNumberQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PhoneNumberFunction, string>(null, blockParameter);
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

        public Task<string> SurnameQueryAsync(SurnameFunction surnameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SurnameFunction, string>(surnameFunction, blockParameter);
        }

        
        public Task<string> SurnameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SurnameFunction, string>(null, blockParameter);
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

        public Task<string> UpdateContactInformationRequestAsync(UpdateContactInformationFunction updateContactInformationFunction)
        {
             return ContractHandler.SendRequestAsync(updateContactInformationFunction);
        }

        public Task<TransactionReceipt> UpdateContactInformationRequestAndWaitForReceiptAsync(UpdateContactInformationFunction updateContactInformationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateContactInformationFunction, cancellationToken);
        }

        public Task<string> UpdateContactInformationRequestAsync(string givenName, string surname, string phoneNumber, string emailAddress)
        {
            var updateContactInformationFunction = new UpdateContactInformationFunction();
                updateContactInformationFunction.GivenName = givenName;
                updateContactInformationFunction.Surname = surname;
                updateContactInformationFunction.PhoneNumber = phoneNumber;
                updateContactInformationFunction.EmailAddress = emailAddress;
            
             return ContractHandler.SendRequestAsync(updateContactInformationFunction);
        }

        public Task<TransactionReceipt> UpdateContactInformationRequestAndWaitForReceiptAsync(string givenName, string surname, string phoneNumber, string emailAddress, CancellationTokenSource cancellationToken = null)
        {
            var updateContactInformationFunction = new UpdateContactInformationFunction();
                updateContactInformationFunction.GivenName = givenName;
                updateContactInformationFunction.Surname = surname;
                updateContactInformationFunction.PhoneNumber = phoneNumber;
                updateContactInformationFunction.EmailAddress = emailAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateContactInformationFunction, cancellationToken);
        }
    }
}
