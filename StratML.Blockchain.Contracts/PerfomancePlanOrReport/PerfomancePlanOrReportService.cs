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
using StratML.Contracts.PerfomancePlanOrReport.ContractDefinition;

namespace StratML.Contracts.PerfomancePlanOrReport
{
    public partial class PerfomancePlanOrReportService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PerfomancePlanOrReportDeployment perfomancePlanOrReportDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PerfomancePlanOrReportDeployment>().SendRequestAndWaitForReceiptAsync(perfomancePlanOrReportDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PerfomancePlanOrReportDeployment perfomancePlanOrReportDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PerfomancePlanOrReportDeployment>().SendRequestAsync(perfomancePlanOrReportDeployment);
        }

        public static async Task<PerfomancePlanOrReportService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PerfomancePlanOrReportDeployment perfomancePlanOrReportDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, perfomancePlanOrReportDeployment, cancellationTokenSource);
            return new PerfomancePlanOrReportService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PerfomancePlanOrReportService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PerfomancePlanOrReportService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddGoalRequestAsync(AddGoalFunction addGoalFunction)
        {
             return ContractHandler.SendRequestAsync(addGoalFunction);
        }

        public Task<TransactionReceipt> AddGoalRequestAndWaitForReceiptAsync(AddGoalFunction addGoalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addGoalFunction, cancellationToken);
        }

        public Task<string> AddGoalRequestAsync(string goalAddress)
        {
            var addGoalFunction = new AddGoalFunction();
                addGoalFunction.GoalAddress = goalAddress;
            
             return ContractHandler.SendRequestAsync(addGoalFunction);
        }

        public Task<TransactionReceipt> AddGoalRequestAndWaitForReceiptAsync(string goalAddress, CancellationTokenSource cancellationToken = null)
        {
            var addGoalFunction = new AddGoalFunction();
                addGoalFunction.GoalAddress = goalAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addGoalFunction, cancellationToken);
        }

        public Task<string> AddOrganizationRequestAsync(AddOrganizationFunction addOrganizationFunction)
        {
             return ContractHandler.SendRequestAsync(addOrganizationFunction);
        }

        public Task<TransactionReceipt> AddOrganizationRequestAndWaitForReceiptAsync(AddOrganizationFunction addOrganizationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOrganizationFunction, cancellationToken);
        }

        public Task<string> AddOrganizationRequestAsync(string organizationAddress)
        {
            var addOrganizationFunction = new AddOrganizationFunction();
                addOrganizationFunction.OrganizationAddress = organizationAddress;
            
             return ContractHandler.SendRequestAsync(addOrganizationFunction);
        }

        public Task<TransactionReceipt> AddOrganizationRequestAndWaitForReceiptAsync(string organizationAddress, CancellationTokenSource cancellationToken = null)
        {
            var addOrganizationFunction = new AddOrganizationFunction();
                addOrganizationFunction.OrganizationAddress = organizationAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOrganizationFunction, cancellationToken);
        }

        public Task<string> AddValueRequestAsync(AddValueFunction addValueFunction)
        {
             return ContractHandler.SendRequestAsync(addValueFunction);
        }

        public Task<TransactionReceipt> AddValueRequestAndWaitForReceiptAsync(AddValueFunction addValueFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addValueFunction, cancellationToken);
        }

        public Task<string> AddValueRequestAsync(string name, string description)
        {
            var addValueFunction = new AddValueFunction();
                addValueFunction.Name = name;
                addValueFunction.Description = description;
            
             return ContractHandler.SendRequestAsync(addValueFunction);
        }

        public Task<TransactionReceipt> AddValueRequestAndWaitForReceiptAsync(string name, string description, CancellationTokenSource cancellationToken = null)
        {
            var addValueFunction = new AddValueFunction();
                addValueFunction.Name = name;
                addValueFunction.Description = description;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addValueFunction, cancellationToken);
        }

        public Task<string> DescriptionQueryAsync(DescriptionFunction descriptionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(descriptionFunction, blockParameter);
        }

        
        public Task<string> DescriptionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(null, blockParameter);
        }

        public Task<GetAdministrativeInformationOutputDTO> GetAdministrativeInformationQueryAsync(GetAdministrativeInformationFunction getAdministrativeInformationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAdministrativeInformationFunction, GetAdministrativeInformationOutputDTO>(getAdministrativeInformationFunction, blockParameter);
        }

        public Task<GetAdministrativeInformationOutputDTO> GetAdministrativeInformationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAdministrativeInformationFunction, GetAdministrativeInformationOutputDTO>(null, blockParameter);
        }

        public Task<List<string>> GetGoalsQueryAsync(GetGoalsFunction getGoalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGoalsFunction, List<string>>(getGoalsFunction, blockParameter);
        }

        
        public Task<List<string>> GetGoalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGoalsFunction, List<string>>(null, blockParameter);
        }

        public Task<List<string>> GetOrganizationsQueryAsync(GetOrganizationsFunction getOrganizationsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOrganizationsFunction, List<string>>(getOrganizationsFunction, blockParameter);
        }

        
        public Task<List<string>> GetOrganizationsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOrganizationsFunction, List<string>>(null, blockParameter);
        }

        public Task<GetPerfomancePlanOrReportResponseOutputDTO> GetPerfomancePlanOrReportResponseQueryAsync(GetPerfomancePlanOrReportResponseFunction getPerfomancePlanOrReportResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerfomancePlanOrReportResponseFunction, GetPerfomancePlanOrReportResponseOutputDTO>(getPerfomancePlanOrReportResponseFunction, blockParameter);
        }

        public Task<GetPerfomancePlanOrReportResponseOutputDTO> GetPerfomancePlanOrReportResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerfomancePlanOrReportResponseFunction, GetPerfomancePlanOrReportResponseOutputDTO>(null, blockParameter);
        }

        public Task<GetPerfomancePlanOrReportResponseBaseOutputDTO> GetPerfomancePlanOrReportResponseBaseQueryAsync(GetPerfomancePlanOrReportResponseBaseFunction getPerfomancePlanOrReportResponseBaseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerfomancePlanOrReportResponseBaseFunction, GetPerfomancePlanOrReportResponseBaseOutputDTO>(getPerfomancePlanOrReportResponseBaseFunction, blockParameter);
        }

        public Task<GetPerfomancePlanOrReportResponseBaseOutputDTO> GetPerfomancePlanOrReportResponseBaseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerfomancePlanOrReportResponseBaseFunction, GetPerfomancePlanOrReportResponseBaseOutputDTO>(null, blockParameter);
        }

        public Task<GetStrategeticPlanCoreResponseOutputDTO> GetStrategeticPlanCoreResponseQueryAsync(GetStrategeticPlanCoreResponseFunction getStrategeticPlanCoreResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStrategeticPlanCoreResponseFunction, GetStrategeticPlanCoreResponseOutputDTO>(getStrategeticPlanCoreResponseFunction, blockParameter);
        }

        public Task<GetStrategeticPlanCoreResponseOutputDTO> GetStrategeticPlanCoreResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStrategeticPlanCoreResponseFunction, GetStrategeticPlanCoreResponseOutputDTO>(null, blockParameter);
        }

        public Task<GetStrategeticPlanCoreResponseBaseOutputDTO> GetStrategeticPlanCoreResponseBaseQueryAsync(GetStrategeticPlanCoreResponseBaseFunction getStrategeticPlanCoreResponseBaseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStrategeticPlanCoreResponseBaseFunction, GetStrategeticPlanCoreResponseBaseOutputDTO>(getStrategeticPlanCoreResponseBaseFunction, blockParameter);
        }

        public Task<GetStrategeticPlanCoreResponseBaseOutputDTO> GetStrategeticPlanCoreResponseBaseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStrategeticPlanCoreResponseBaseFunction, GetStrategeticPlanCoreResponseBaseOutputDTO>(null, blockParameter);
        }

        public Task<GetSumbitterOutputDTO> GetSumbitterQueryAsync(GetSumbitterFunction getSumbitterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSumbitterFunction, GetSumbitterOutputDTO>(getSumbitterFunction, blockParameter);
        }

        public Task<GetSumbitterOutputDTO> GetSumbitterQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSumbitterFunction, GetSumbitterOutputDTO>(null, blockParameter);
        }

        public Task<GetValuesOutputDTO> GetValuesQueryAsync(GetValuesFunction getValuesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValuesFunction, GetValuesOutputDTO>(getValuesFunction, blockParameter);
        }

        public Task<GetValuesOutputDTO> GetValuesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValuesFunction, GetValuesOutputDTO>(null, blockParameter);
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

        public Task<string> RemoveGoalRequestAsync(RemoveGoalFunction removeGoalFunction)
        {
             return ContractHandler.SendRequestAsync(removeGoalFunction);
        }

        public Task<TransactionReceipt> RemoveGoalRequestAndWaitForReceiptAsync(RemoveGoalFunction removeGoalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeGoalFunction, cancellationToken);
        }

        public Task<string> RemoveGoalRequestAsync(string goalAddress)
        {
            var removeGoalFunction = new RemoveGoalFunction();
                removeGoalFunction.GoalAddress = goalAddress;
            
             return ContractHandler.SendRequestAsync(removeGoalFunction);
        }

        public Task<TransactionReceipt> RemoveGoalRequestAndWaitForReceiptAsync(string goalAddress, CancellationTokenSource cancellationToken = null)
        {
            var removeGoalFunction = new RemoveGoalFunction();
                removeGoalFunction.GoalAddress = goalAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeGoalFunction, cancellationToken);
        }

        public Task<string> RemoveOrganizationRequestAsync(RemoveOrganizationFunction removeOrganizationFunction)
        {
             return ContractHandler.SendRequestAsync(removeOrganizationFunction);
        }

        public Task<TransactionReceipt> RemoveOrganizationRequestAndWaitForReceiptAsync(RemoveOrganizationFunction removeOrganizationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOrganizationFunction, cancellationToken);
        }

        public Task<string> RemoveOrganizationRequestAsync(string organizationAddress)
        {
            var removeOrganizationFunction = new RemoveOrganizationFunction();
                removeOrganizationFunction.OrganizationAddress = organizationAddress;
            
             return ContractHandler.SendRequestAsync(removeOrganizationFunction);
        }

        public Task<TransactionReceipt> RemoveOrganizationRequestAndWaitForReceiptAsync(string organizationAddress, CancellationTokenSource cancellationToken = null)
        {
            var removeOrganizationFunction = new RemoveOrganizationFunction();
                removeOrganizationFunction.OrganizationAddress = organizationAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOrganizationFunction, cancellationToken);
        }

        public Task<string> RemoveValueRequestAsync(RemoveValueFunction removeValueFunction)
        {
             return ContractHandler.SendRequestAsync(removeValueFunction);
        }

        public Task<TransactionReceipt> RemoveValueRequestAndWaitForReceiptAsync(RemoveValueFunction removeValueFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeValueFunction, cancellationToken);
        }

        public Task<string> RemoveValueRequestAsync(BigInteger index)
        {
            var removeValueFunction = new RemoveValueFunction();
                removeValueFunction.Index = index;
            
             return ContractHandler.SendRequestAsync(removeValueFunction);
        }

        public Task<TransactionReceipt> RemoveValueRequestAndWaitForReceiptAsync(BigInteger index, CancellationTokenSource cancellationToken = null)
        {
            var removeValueFunction = new RemoveValueFunction();
                removeValueFunction.Index = index;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeValueFunction, cancellationToken);
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

        public Task<string> SetAdministrativeInformationRequestAsync(SetAdministrativeInformationFunction setAdministrativeInformationFunction)
        {
             return ContractHandler.SendRequestAsync(setAdministrativeInformationFunction);
        }

        public Task<TransactionReceipt> SetAdministrativeInformationRequestAndWaitForReceiptAsync(SetAdministrativeInformationFunction setAdministrativeInformationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdministrativeInformationFunction, cancellationToken);
        }

        public Task<string> SetAdministrativeInformationRequestAsync(string adminInfo)
        {
            var setAdministrativeInformationFunction = new SetAdministrativeInformationFunction();
                setAdministrativeInformationFunction.AdminInfo = adminInfo;
            
             return ContractHandler.SendRequestAsync(setAdministrativeInformationFunction);
        }

        public Task<TransactionReceipt> SetAdministrativeInformationRequestAndWaitForReceiptAsync(string adminInfo, CancellationTokenSource cancellationToken = null)
        {
            var setAdministrativeInformationFunction = new SetAdministrativeInformationFunction();
                setAdministrativeInformationFunction.AdminInfo = adminInfo;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdministrativeInformationFunction, cancellationToken);
        }

        public Task<string> SetMissionRequestAsync(SetMissionFunction setMissionFunction)
        {
             return ContractHandler.SendRequestAsync(setMissionFunction);
        }

        public Task<TransactionReceipt> SetMissionRequestAndWaitForReceiptAsync(SetMissionFunction setMissionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMissionFunction, cancellationToken);
        }

        public Task<string> SetMissionRequestAsync(string mission)
        {
            var setMissionFunction = new SetMissionFunction();
                setMissionFunction.Mission = mission;
            
             return ContractHandler.SendRequestAsync(setMissionFunction);
        }

        public Task<TransactionReceipt> SetMissionRequestAndWaitForReceiptAsync(string mission, CancellationTokenSource cancellationToken = null)
        {
            var setMissionFunction = new SetMissionFunction();
                setMissionFunction.Mission = mission;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMissionFunction, cancellationToken);
        }

        public Task<string> SetSumbitterRequestAsync(SetSumbitterFunction setSumbitterFunction)
        {
             return ContractHandler.SendRequestAsync(setSumbitterFunction);
        }

        public Task<TransactionReceipt> SetSumbitterRequestAndWaitForReceiptAsync(SetSumbitterFunction setSumbitterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSumbitterFunction, cancellationToken);
        }

        public Task<string> SetSumbitterRequestAsync(string submitter)
        {
            var setSumbitterFunction = new SetSumbitterFunction();
                setSumbitterFunction.Submitter = submitter;
            
             return ContractHandler.SendRequestAsync(setSumbitterFunction);
        }

        public Task<TransactionReceipt> SetSumbitterRequestAndWaitForReceiptAsync(string submitter, CancellationTokenSource cancellationToken = null)
        {
            var setSumbitterFunction = new SetSumbitterFunction();
                setSumbitterFunction.Submitter = submitter;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSumbitterFunction, cancellationToken);
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

        public Task<string> UpdateValueRequestAsync(UpdateValueFunction updateValueFunction)
        {
             return ContractHandler.SendRequestAsync(updateValueFunction);
        }

        public Task<TransactionReceipt> UpdateValueRequestAndWaitForReceiptAsync(UpdateValueFunction updateValueFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateValueFunction, cancellationToken);
        }

        public Task<string> UpdateValueRequestAsync(BigInteger index, string name, string description)
        {
            var updateValueFunction = new UpdateValueFunction();
                updateValueFunction.Index = index;
                updateValueFunction.Name = name;
                updateValueFunction.Description = description;
            
             return ContractHandler.SendRequestAsync(updateValueFunction);
        }

        public Task<TransactionReceipt> UpdateValueRequestAndWaitForReceiptAsync(BigInteger index, string name, string description, CancellationTokenSource cancellationToken = null)
        {
            var updateValueFunction = new UpdateValueFunction();
                updateValueFunction.Index = index;
                updateValueFunction.Name = name;
                updateValueFunction.Description = description;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateValueFunction, cancellationToken);
        }

        public Task<string> UpdateVisionRequestAsync(UpdateVisionFunction updateVisionFunction)
        {
             return ContractHandler.SendRequestAsync(updateVisionFunction);
        }

        public Task<TransactionReceipt> UpdateVisionRequestAndWaitForReceiptAsync(UpdateVisionFunction updateVisionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateVisionFunction, cancellationToken);
        }

        public Task<string> UpdateVisionRequestAsync(string vision)
        {
            var updateVisionFunction = new UpdateVisionFunction();
                updateVisionFunction.Vision = vision;
            
             return ContractHandler.SendRequestAsync(updateVisionFunction);
        }

        public Task<TransactionReceipt> UpdateVisionRequestAndWaitForReceiptAsync(string vision, CancellationTokenSource cancellationToken = null)
        {
            var updateVisionFunction = new UpdateVisionFunction();
                updateVisionFunction.Vision = vision;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateVisionFunction, cancellationToken);
        }
    }
}
