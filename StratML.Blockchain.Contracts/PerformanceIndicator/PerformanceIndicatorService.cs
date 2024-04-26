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
using StratML.Contracts.PerformanceIndicator.ContractDefinition;

namespace StratML.Contracts.PerformanceIndicator
{
    public partial class PerformanceIndicatorService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PerformanceIndicatorDeployment performanceIndicatorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PerformanceIndicatorDeployment>().SendRequestAndWaitForReceiptAsync(performanceIndicatorDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PerformanceIndicatorDeployment performanceIndicatorDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PerformanceIndicatorDeployment>().SendRequestAsync(performanceIndicatorDeployment);
        }

        public static async Task<PerformanceIndicatorService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PerformanceIndicatorDeployment performanceIndicatorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, performanceIndicatorDeployment, cancellationTokenSource);
            return new PerformanceIndicatorService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PerformanceIndicatorService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PerformanceIndicatorService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddMeasurementInstanceRequestAsync(AddMeasurementInstanceFunction addMeasurementInstanceFunction)
        {
             return ContractHandler.SendRequestAsync(addMeasurementInstanceFunction);
        }

        public Task<TransactionReceipt> AddMeasurementInstanceRequestAndWaitForReceiptAsync(AddMeasurementInstanceFunction addMeasurementInstanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addMeasurementInstanceFunction, cancellationToken);
        }

        public Task<string> AddMeasurementInstanceRequestAsync(MeasurementInstance measurementInstance)
        {
            var addMeasurementInstanceFunction = new AddMeasurementInstanceFunction();
                addMeasurementInstanceFunction.MeasurementInstance = measurementInstance;
            
             return ContractHandler.SendRequestAsync(addMeasurementInstanceFunction);
        }

        public Task<TransactionReceipt> AddMeasurementInstanceRequestAndWaitForReceiptAsync(MeasurementInstance measurementInstance, CancellationTokenSource cancellationToken = null)
        {
            var addMeasurementInstanceFunction = new AddMeasurementInstanceFunction();
                addMeasurementInstanceFunction.MeasurementInstance = measurementInstance;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addMeasurementInstanceFunction, cancellationToken);
        }

        public Task<string> AddRelationshipRequestAsync(AddRelationshipFunction addRelationshipFunction)
        {
             return ContractHandler.SendRequestAsync(addRelationshipFunction);
        }

        public Task<TransactionReceipt> AddRelationshipRequestAndWaitForReceiptAsync(AddRelationshipFunction addRelationshipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRelationshipFunction, cancellationToken);
        }

        public Task<string> AddRelationshipRequestAsync(string relationshipAddress)
        {
            var addRelationshipFunction = new AddRelationshipFunction();
                addRelationshipFunction.RelationshipAddress = relationshipAddress;
            
             return ContractHandler.SendRequestAsync(addRelationshipFunction);
        }

        public Task<TransactionReceipt> AddRelationshipRequestAndWaitForReceiptAsync(string relationshipAddress, CancellationTokenSource cancellationToken = null)
        {
            var addRelationshipFunction = new AddRelationshipFunction();
                addRelationshipFunction.RelationshipAddress = relationshipAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRelationshipFunction, cancellationToken);
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

        public Task<GetMeasurementInstancesOutputDTO> GetMeasurementInstancesQueryAsync(GetMeasurementInstancesFunction getMeasurementInstancesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMeasurementInstancesFunction, GetMeasurementInstancesOutputDTO>(getMeasurementInstancesFunction, blockParameter);
        }

        public Task<GetMeasurementInstancesOutputDTO> GetMeasurementInstancesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMeasurementInstancesFunction, GetMeasurementInstancesOutputDTO>(null, blockParameter);
        }

        public Task<GetPerformanceIndicatorOutputDTO> GetPerformanceIndicatorQueryAsync(GetPerformanceIndicatorFunction getPerformanceIndicatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerformanceIndicatorFunction, GetPerformanceIndicatorOutputDTO>(getPerformanceIndicatorFunction, blockParameter);
        }

        public Task<GetPerformanceIndicatorOutputDTO> GetPerformanceIndicatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerformanceIndicatorFunction, GetPerformanceIndicatorOutputDTO>(null, blockParameter);
        }

        public Task<List<string>> GetRelationshipsQueryAsync(GetRelationshipsFunction getRelationshipsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRelationshipsFunction, List<string>>(getRelationshipsFunction, blockParameter);
        }

        
        public Task<List<string>> GetRelationshipsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRelationshipsFunction, List<string>>(null, blockParameter);
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

        public Task<string> MeasurementDimensionQueryAsync(MeasurementDimensionFunction measurementDimensionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MeasurementDimensionFunction, string>(measurementDimensionFunction, blockParameter);
        }

        
        public Task<string> MeasurementDimensionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MeasurementDimensionFunction, string>(null, blockParameter);
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

        public Task<byte> PerfomanceIndicatorQueryAsync(PerfomanceIndicatorFunction perfomanceIndicatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PerfomanceIndicatorFunction, byte>(perfomanceIndicatorFunction, blockParameter);
        }

        
        public Task<byte> PerfomanceIndicatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PerfomanceIndicatorFunction, byte>(null, blockParameter);
        }

        public Task<string> RegistryQueryAsync(RegistryFunction registryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistryFunction, string>(registryFunction, blockParameter);
        }

        
        public Task<string> RegistryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistryFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveMeasurementInstanceRequestAsync(RemoveMeasurementInstanceFunction removeMeasurementInstanceFunction)
        {
             return ContractHandler.SendRequestAsync(removeMeasurementInstanceFunction);
        }

        public Task<TransactionReceipt> RemoveMeasurementInstanceRequestAndWaitForReceiptAsync(RemoveMeasurementInstanceFunction removeMeasurementInstanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeMeasurementInstanceFunction, cancellationToken);
        }

        public Task<string> RemoveMeasurementInstanceRequestAsync(BigInteger index)
        {
            var removeMeasurementInstanceFunction = new RemoveMeasurementInstanceFunction();
                removeMeasurementInstanceFunction.Index = index;
            
             return ContractHandler.SendRequestAsync(removeMeasurementInstanceFunction);
        }

        public Task<TransactionReceipt> RemoveMeasurementInstanceRequestAndWaitForReceiptAsync(BigInteger index, CancellationTokenSource cancellationToken = null)
        {
            var removeMeasurementInstanceFunction = new RemoveMeasurementInstanceFunction();
                removeMeasurementInstanceFunction.Index = index;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeMeasurementInstanceFunction, cancellationToken);
        }

        public Task<string> RemoveRelationshipRequestAsync(RemoveRelationshipFunction removeRelationshipFunction)
        {
             return ContractHandler.SendRequestAsync(removeRelationshipFunction);
        }

        public Task<TransactionReceipt> RemoveRelationshipRequestAndWaitForReceiptAsync(RemoveRelationshipFunction removeRelationshipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRelationshipFunction, cancellationToken);
        }

        public Task<string> RemoveRelationshipRequestAsync(string relationshipAddress)
        {
            var removeRelationshipFunction = new RemoveRelationshipFunction();
                removeRelationshipFunction.RelationshipAddress = relationshipAddress;
            
             return ContractHandler.SendRequestAsync(removeRelationshipFunction);
        }

        public Task<TransactionReceipt> RemoveRelationshipRequestAndWaitForReceiptAsync(string relationshipAddress, CancellationTokenSource cancellationToken = null)
        {
            var removeRelationshipFunction = new RemoveRelationshipFunction();
                removeRelationshipFunction.RelationshipAddress = relationshipAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRelationshipFunction, cancellationToken);
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

        public Task<string> UnitOfMeasurementQueryAsync(UnitOfMeasurementFunction unitOfMeasurementFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UnitOfMeasurementFunction, string>(unitOfMeasurementFunction, blockParameter);
        }

        
        public Task<string> UnitOfMeasurementQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UnitOfMeasurementFunction, string>(null, blockParameter);
        }

        public Task<string> UpdatePerformanceIndicatorRequestAsync(UpdatePerformanceIndicatorFunction updatePerformanceIndicatorFunction)
        {
             return ContractHandler.SendRequestAsync(updatePerformanceIndicatorFunction);
        }

        public Task<TransactionReceipt> UpdatePerformanceIndicatorRequestAndWaitForReceiptAsync(UpdatePerformanceIndicatorFunction updatePerformanceIndicatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updatePerformanceIndicatorFunction, cancellationToken);
        }

        public Task<string> UpdatePerformanceIndicatorRequestAsync(string sequenceIndicator, string measurementDimension, string unitOfMeasurement, byte perfomanceIndicator)
        {
            var updatePerformanceIndicatorFunction = new UpdatePerformanceIndicatorFunction();
                updatePerformanceIndicatorFunction.SequenceIndicator = sequenceIndicator;
                updatePerformanceIndicatorFunction.MeasurementDimension = measurementDimension;
                updatePerformanceIndicatorFunction.UnitOfMeasurement = unitOfMeasurement;
                updatePerformanceIndicatorFunction.PerfomanceIndicator = perfomanceIndicator;
            
             return ContractHandler.SendRequestAsync(updatePerformanceIndicatorFunction);
        }

        public Task<TransactionReceipt> UpdatePerformanceIndicatorRequestAndWaitForReceiptAsync(string sequenceIndicator, string measurementDimension, string unitOfMeasurement, byte perfomanceIndicator, CancellationTokenSource cancellationToken = null)
        {
            var updatePerformanceIndicatorFunction = new UpdatePerformanceIndicatorFunction();
                updatePerformanceIndicatorFunction.SequenceIndicator = sequenceIndicator;
                updatePerformanceIndicatorFunction.MeasurementDimension = measurementDimension;
                updatePerformanceIndicatorFunction.UnitOfMeasurement = unitOfMeasurement;
                updatePerformanceIndicatorFunction.PerfomanceIndicator = perfomanceIndicator;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updatePerformanceIndicatorFunction, cancellationToken);
        }

        public Task<byte> VauleChangeStageQueryAsync(VauleChangeStageFunction vauleChangeStageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VauleChangeStageFunction, byte>(vauleChangeStageFunction, blockParameter);
        }

        
        public Task<byte> VauleChangeStageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VauleChangeStageFunction, byte>(null, blockParameter);
        }
    }
}
