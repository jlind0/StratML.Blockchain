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
using StratML.Contracts.StratMLRegistry.ContractDefinition;

namespace StratML.Contracts.StratMLRegistry
{
    public partial class StratMLRegistryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, StratMLRegistryDeployment stratMLRegistryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<StratMLRegistryDeployment>().SendRequestAndWaitForReceiptAsync(stratMLRegistryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, StratMLRegistryDeployment stratMLRegistryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<StratMLRegistryDeployment>().SendRequestAsync(stratMLRegistryDeployment);
        }

        public static async Task<StratMLRegistryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, StratMLRegistryDeployment stratMLRegistryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, stratMLRegistryDeployment, cancellationTokenSource);
            return new StratMLRegistryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public StratMLRegistryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public StratMLRegistryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddOrganizationRequestAsync(AddOrganizationFunction addOrganizationFunction)
        {
             return ContractHandler.SendRequestAsync(addOrganizationFunction);
        }

        public Task<TransactionReceipt> AddOrganizationRequestAndWaitForReceiptAsync(AddOrganizationFunction addOrganizationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOrganizationFunction, cancellationToken);
        }

        public Task<string> AddOrganizationRequestAsync(string organization)
        {
            var addOrganizationFunction = new AddOrganizationFunction();
                addOrganizationFunction.Organization = organization;
            
             return ContractHandler.SendRequestAsync(addOrganizationFunction);
        }

        public Task<TransactionReceipt> AddOrganizationRequestAndWaitForReceiptAsync(string organization, CancellationTokenSource cancellationToken = null)
        {
            var addOrganizationFunction = new AddOrganizationFunction();
                addOrganizationFunction.Organization = organization;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOrganizationFunction, cancellationToken);
        }

        public Task<string> AddPerfomancePlanOrReportRequestAsync(AddPerfomancePlanOrReportFunction addPerfomancePlanOrReportFunction)
        {
             return ContractHandler.SendRequestAsync(addPerfomancePlanOrReportFunction);
        }

        public Task<TransactionReceipt> AddPerfomancePlanOrReportRequestAndWaitForReceiptAsync(AddPerfomancePlanOrReportFunction addPerfomancePlanOrReportFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPerfomancePlanOrReportFunction, cancellationToken);
        }

        public Task<string> AddPerfomancePlanOrReportRequestAsync(string perfomancePlanOrReport)
        {
            var addPerfomancePlanOrReportFunction = new AddPerfomancePlanOrReportFunction();
                addPerfomancePlanOrReportFunction.PerfomancePlanOrReport = perfomancePlanOrReport;
            
             return ContractHandler.SendRequestAsync(addPerfomancePlanOrReportFunction);
        }

        public Task<TransactionReceipt> AddPerfomancePlanOrReportRequestAndWaitForReceiptAsync(string perfomancePlanOrReport, CancellationTokenSource cancellationToken = null)
        {
            var addPerfomancePlanOrReportFunction = new AddPerfomancePlanOrReportFunction();
                addPerfomancePlanOrReportFunction.PerfomancePlanOrReport = perfomancePlanOrReport;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPerfomancePlanOrReportFunction, cancellationToken);
        }

        public Task<string> AddRoleRequestAsync(AddRoleFunction addRoleFunction)
        {
             return ContractHandler.SendRequestAsync(addRoleFunction);
        }

        public Task<TransactionReceipt> AddRoleRequestAndWaitForReceiptAsync(AddRoleFunction addRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRoleFunction, cancellationToken);
        }

        public Task<string> AddRoleRequestAsync(string role)
        {
            var addRoleFunction = new AddRoleFunction();
                addRoleFunction.Role = role;
            
             return ContractHandler.SendRequestAsync(addRoleFunction);
        }

        public Task<TransactionReceipt> AddRoleRequestAndWaitForReceiptAsync(string role, CancellationTokenSource cancellationToken = null)
        {
            var addRoleFunction = new AddRoleFunction();
                addRoleFunction.Role = role;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRoleFunction, cancellationToken);
        }

        public Task<string> AddStakeholderRequestAsync(AddStakeholderFunction addStakeholderFunction)
        {
             return ContractHandler.SendRequestAsync(addStakeholderFunction);
        }

        public Task<TransactionReceipt> AddStakeholderRequestAndWaitForReceiptAsync(AddStakeholderFunction addStakeholderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addStakeholderFunction, cancellationToken);
        }

        public Task<string> AddStakeholderRequestAsync(string stakeholder)
        {
            var addStakeholderFunction = new AddStakeholderFunction();
                addStakeholderFunction.Stakeholder = stakeholder;
            
             return ContractHandler.SendRequestAsync(addStakeholderFunction);
        }

        public Task<TransactionReceipt> AddStakeholderRequestAndWaitForReceiptAsync(string stakeholder, CancellationTokenSource cancellationToken = null)
        {
            var addStakeholderFunction = new AddStakeholderFunction();
                addStakeholderFunction.Stakeholder = stakeholder;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addStakeholderFunction, cancellationToken);
        }

        public Task<BigInteger> BoxDateTimeQueryAsync(BoxDateTimeFunction boxDateTimeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BoxDateTimeFunction, BigInteger>(boxDateTimeFunction, blockParameter);
        }

        
        public Task<BigInteger> BoxDateTimeQueryAsync(BigInteger time, BlockParameter blockParameter = null)
        {
            var boxDateTimeFunction = new BoxDateTimeFunction();
                boxDateTimeFunction.Time = time;
            
            return ContractHandler.QueryAsync<BoxDateTimeFunction, BigInteger>(boxDateTimeFunction, blockParameter);
        }

        public Task<GetAllOrganizationsOutputDTO> GetAllOrganizationsQueryAsync(GetAllOrganizationsFunction getAllOrganizationsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllOrganizationsFunction, GetAllOrganizationsOutputDTO>(getAllOrganizationsFunction, blockParameter);
        }

        public Task<GetAllOrganizationsOutputDTO> GetAllOrganizationsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllOrganizationsFunction, GetAllOrganizationsOutputDTO>(null, blockParameter);
        }

        public Task<GetAllPerfomancePlanOrReportsOutputDTO> GetAllPerfomancePlanOrReportsQueryAsync(GetAllPerfomancePlanOrReportsFunction getAllPerfomancePlanOrReportsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllPerfomancePlanOrReportsFunction, GetAllPerfomancePlanOrReportsOutputDTO>(getAllPerfomancePlanOrReportsFunction, blockParameter);
        }

        public Task<GetAllPerfomancePlanOrReportsOutputDTO> GetAllPerfomancePlanOrReportsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllPerfomancePlanOrReportsFunction, GetAllPerfomancePlanOrReportsOutputDTO>(null, blockParameter);
        }

        public Task<GetAllPerfomancePlanOrReportsByValidDateRangeOutputDTO> GetAllPerfomancePlanOrReportsByValidDateRangeQueryAsync(GetAllPerfomancePlanOrReportsByValidDateRangeFunction getAllPerfomancePlanOrReportsByValidDateRangeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllPerfomancePlanOrReportsByValidDateRangeFunction, GetAllPerfomancePlanOrReportsByValidDateRangeOutputDTO>(getAllPerfomancePlanOrReportsByValidDateRangeFunction, blockParameter);
        }

        public Task<GetAllPerfomancePlanOrReportsByValidDateRangeOutputDTO> GetAllPerfomancePlanOrReportsByValidDateRangeQueryAsync(BigInteger startDate, BigInteger endDate, BlockParameter blockParameter = null)
        {
            var getAllPerfomancePlanOrReportsByValidDateRangeFunction = new GetAllPerfomancePlanOrReportsByValidDateRangeFunction();
                getAllPerfomancePlanOrReportsByValidDateRangeFunction.StartDate = startDate;
                getAllPerfomancePlanOrReportsByValidDateRangeFunction.EndDate = endDate;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllPerfomancePlanOrReportsByValidDateRangeFunction, GetAllPerfomancePlanOrReportsByValidDateRangeOutputDTO>(getAllPerfomancePlanOrReportsByValidDateRangeFunction, blockParameter);
        }

        public Task<GetAllPerformancePlanOrReportsByPublicationDateRangeOutputDTO> GetAllPerformancePlanOrReportsByPublicationDateRangeQueryAsync(GetAllPerformancePlanOrReportsByPublicationDateRangeFunction getAllPerformancePlanOrReportsByPublicationDateRangeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllPerformancePlanOrReportsByPublicationDateRangeFunction, GetAllPerformancePlanOrReportsByPublicationDateRangeOutputDTO>(getAllPerformancePlanOrReportsByPublicationDateRangeFunction, blockParameter);
        }

        public Task<GetAllPerformancePlanOrReportsByPublicationDateRangeOutputDTO> GetAllPerformancePlanOrReportsByPublicationDateRangeQueryAsync(BigInteger startDate, BigInteger endDate, BlockParameter blockParameter = null)
        {
            var getAllPerformancePlanOrReportsByPublicationDateRangeFunction = new GetAllPerformancePlanOrReportsByPublicationDateRangeFunction();
                getAllPerformancePlanOrReportsByPublicationDateRangeFunction.StartDate = startDate;
                getAllPerformancePlanOrReportsByPublicationDateRangeFunction.EndDate = endDate;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllPerformancePlanOrReportsByPublicationDateRangeFunction, GetAllPerformancePlanOrReportsByPublicationDateRangeOutputDTO>(getAllPerformancePlanOrReportsByPublicationDateRangeFunction, blockParameter);
        }

        public Task<GetAllRolesOutputDTO> GetAllRolesQueryAsync(GetAllRolesFunction getAllRolesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllRolesFunction, GetAllRolesOutputDTO>(getAllRolesFunction, blockParameter);
        }

        public Task<GetAllRolesOutputDTO> GetAllRolesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllRolesFunction, GetAllRolesOutputDTO>(null, blockParameter);
        }

        public Task<GetAllStakeholdersOutputDTO> GetAllStakeholdersQueryAsync(GetAllStakeholdersFunction getAllStakeholdersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllStakeholdersFunction, GetAllStakeholdersOutputDTO>(getAllStakeholdersFunction, blockParameter);
        }

        public Task<GetAllStakeholdersOutputDTO> GetAllStakeholdersQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllStakeholdersFunction, GetAllStakeholdersOutputDTO>(null, blockParameter);
        }

        public Task<GetOrganizationsByNameOutputDTO> GetOrganizationsByNameQueryAsync(GetOrganizationsByNameFunction getOrganizationsByNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganizationsByNameFunction, GetOrganizationsByNameOutputDTO>(getOrganizationsByNameFunction, blockParameter);
        }

        public Task<GetOrganizationsByNameOutputDTO> GetOrganizationsByNameQueryAsync(string name, BlockParameter blockParameter = null)
        {
            var getOrganizationsByNameFunction = new GetOrganizationsByNameFunction();
                getOrganizationsByNameFunction.Name = name;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganizationsByNameFunction, GetOrganizationsByNameOutputDTO>(getOrganizationsByNameFunction, blockParameter);
        }

        public Task<GetPerfomancePlanOrReportsByNameOutputDTO> GetPerfomancePlanOrReportsByNameQueryAsync(GetPerfomancePlanOrReportsByNameFunction getPerfomancePlanOrReportsByNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerfomancePlanOrReportsByNameFunction, GetPerfomancePlanOrReportsByNameOutputDTO>(getPerfomancePlanOrReportsByNameFunction, blockParameter);
        }

        public Task<GetPerfomancePlanOrReportsByNameOutputDTO> GetPerfomancePlanOrReportsByNameQueryAsync(string name, BlockParameter blockParameter = null)
        {
            var getPerfomancePlanOrReportsByNameFunction = new GetPerfomancePlanOrReportsByNameFunction();
                getPerfomancePlanOrReportsByNameFunction.Name = name;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPerfomancePlanOrReportsByNameFunction, GetPerfomancePlanOrReportsByNameOutputDTO>(getPerfomancePlanOrReportsByNameFunction, blockParameter);
        }

        public Task<GetRolesByNameOutputDTO> GetRolesByNameQueryAsync(GetRolesByNameFunction getRolesByNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRolesByNameFunction, GetRolesByNameOutputDTO>(getRolesByNameFunction, blockParameter);
        }

        public Task<GetRolesByNameOutputDTO> GetRolesByNameQueryAsync(string name, BlockParameter blockParameter = null)
        {
            var getRolesByNameFunction = new GetRolesByNameFunction();
                getRolesByNameFunction.Name = name;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetRolesByNameFunction, GetRolesByNameOutputDTO>(getRolesByNameFunction, blockParameter);
        }

        public Task<GetStakeholdersByNameOutputDTO> GetStakeholdersByNameQueryAsync(GetStakeholdersByNameFunction getStakeholdersByNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStakeholdersByNameFunction, GetStakeholdersByNameOutputDTO>(getStakeholdersByNameFunction, blockParameter);
        }

        public Task<GetStakeholdersByNameOutputDTO> GetStakeholdersByNameQueryAsync(string name, BlockParameter blockParameter = null)
        {
            var getStakeholdersByNameFunction = new GetStakeholdersByNameFunction();
                getStakeholdersByNameFunction.Name = name;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetStakeholdersByNameFunction, GetStakeholdersByNameOutputDTO>(getStakeholdersByNameFunction, blockParameter);
        }

        public Task<string> RemoveOrganizationRequestAsync(RemoveOrganizationFunction removeOrganizationFunction)
        {
             return ContractHandler.SendRequestAsync(removeOrganizationFunction);
        }

        public Task<TransactionReceipt> RemoveOrganizationRequestAndWaitForReceiptAsync(RemoveOrganizationFunction removeOrganizationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOrganizationFunction, cancellationToken);
        }

        public Task<string> RemoveOrganizationRequestAsync(string organization)
        {
            var removeOrganizationFunction = new RemoveOrganizationFunction();
                removeOrganizationFunction.Organization = organization;
            
             return ContractHandler.SendRequestAsync(removeOrganizationFunction);
        }

        public Task<TransactionReceipt> RemoveOrganizationRequestAndWaitForReceiptAsync(string organization, CancellationTokenSource cancellationToken = null)
        {
            var removeOrganizationFunction = new RemoveOrganizationFunction();
                removeOrganizationFunction.Organization = organization;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOrganizationFunction, cancellationToken);
        }

        public Task<string> RemovePerfomancePlanOrReportRequestAsync(RemovePerfomancePlanOrReportFunction removePerfomancePlanOrReportFunction)
        {
             return ContractHandler.SendRequestAsync(removePerfomancePlanOrReportFunction);
        }

        public Task<TransactionReceipt> RemovePerfomancePlanOrReportRequestAndWaitForReceiptAsync(RemovePerfomancePlanOrReportFunction removePerfomancePlanOrReportFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePerfomancePlanOrReportFunction, cancellationToken);
        }

        public Task<string> RemovePerfomancePlanOrReportRequestAsync(string perfomancePlanOrReport)
        {
            var removePerfomancePlanOrReportFunction = new RemovePerfomancePlanOrReportFunction();
                removePerfomancePlanOrReportFunction.PerfomancePlanOrReport = perfomancePlanOrReport;
            
             return ContractHandler.SendRequestAsync(removePerfomancePlanOrReportFunction);
        }

        public Task<TransactionReceipt> RemovePerfomancePlanOrReportRequestAndWaitForReceiptAsync(string perfomancePlanOrReport, CancellationTokenSource cancellationToken = null)
        {
            var removePerfomancePlanOrReportFunction = new RemovePerfomancePlanOrReportFunction();
                removePerfomancePlanOrReportFunction.PerfomancePlanOrReport = perfomancePlanOrReport;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePerfomancePlanOrReportFunction, cancellationToken);
        }

        public Task<string> RemoveRoleRequestAsync(RemoveRoleFunction removeRoleFunction)
        {
             return ContractHandler.SendRequestAsync(removeRoleFunction);
        }

        public Task<TransactionReceipt> RemoveRoleRequestAndWaitForReceiptAsync(RemoveRoleFunction removeRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRoleFunction, cancellationToken);
        }

        public Task<string> RemoveRoleRequestAsync(string role)
        {
            var removeRoleFunction = new RemoveRoleFunction();
                removeRoleFunction.Role = role;
            
             return ContractHandler.SendRequestAsync(removeRoleFunction);
        }

        public Task<TransactionReceipt> RemoveRoleRequestAndWaitForReceiptAsync(string role, CancellationTokenSource cancellationToken = null)
        {
            var removeRoleFunction = new RemoveRoleFunction();
                removeRoleFunction.Role = role;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRoleFunction, cancellationToken);
        }

        public Task<string> RemoveStakeholderRequestAsync(RemoveStakeholderFunction removeStakeholderFunction)
        {
             return ContractHandler.SendRequestAsync(removeStakeholderFunction);
        }

        public Task<TransactionReceipt> RemoveStakeholderRequestAndWaitForReceiptAsync(RemoveStakeholderFunction removeStakeholderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeStakeholderFunction, cancellationToken);
        }

        public Task<string> RemoveStakeholderRequestAsync(string stakeholder)
        {
            var removeStakeholderFunction = new RemoveStakeholderFunction();
                removeStakeholderFunction.Stakeholder = stakeholder;
            
             return ContractHandler.SendRequestAsync(removeStakeholderFunction);
        }

        public Task<TransactionReceipt> RemoveStakeholderRequestAndWaitForReceiptAsync(string stakeholder, CancellationTokenSource cancellationToken = null)
        {
            var removeStakeholderFunction = new RemoveStakeholderFunction();
                removeStakeholderFunction.Stakeholder = stakeholder;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeStakeholderFunction, cancellationToken);
        }

        public Task<string> UpdateOrganizationIndexerRequestAsync(UpdateOrganizationIndexerFunction updateOrganizationIndexerFunction)
        {
             return ContractHandler.SendRequestAsync(updateOrganizationIndexerFunction);
        }

        public Task<TransactionReceipt> UpdateOrganizationIndexerRequestAndWaitForReceiptAsync(UpdateOrganizationIndexerFunction updateOrganizationIndexerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateOrganizationIndexerFunction, cancellationToken);
        }

        public Task<string> UpdateOrganizationIndexerRequestAsync(string organization, string oldName)
        {
            var updateOrganizationIndexerFunction = new UpdateOrganizationIndexerFunction();
                updateOrganizationIndexerFunction.Organization = organization;
                updateOrganizationIndexerFunction.OldName = oldName;
            
             return ContractHandler.SendRequestAsync(updateOrganizationIndexerFunction);
        }

        public Task<TransactionReceipt> UpdateOrganizationIndexerRequestAndWaitForReceiptAsync(string organization, string oldName, CancellationTokenSource cancellationToken = null)
        {
            var updateOrganizationIndexerFunction = new UpdateOrganizationIndexerFunction();
                updateOrganizationIndexerFunction.Organization = organization;
                updateOrganizationIndexerFunction.OldName = oldName;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateOrganizationIndexerFunction, cancellationToken);
        }

        public Task<string> UpdatePerfomancePlanOrReportIndexerRequestAsync(UpdatePerfomancePlanOrReportIndexerFunction updatePerfomancePlanOrReportIndexerFunction)
        {
             return ContractHandler.SendRequestAsync(updatePerfomancePlanOrReportIndexerFunction);
        }

        public Task<TransactionReceipt> UpdatePerfomancePlanOrReportIndexerRequestAndWaitForReceiptAsync(UpdatePerfomancePlanOrReportIndexerFunction updatePerfomancePlanOrReportIndexerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updatePerfomancePlanOrReportIndexerFunction, cancellationToken);
        }

        public Task<string> UpdatePerfomancePlanOrReportIndexerRequestAsync(string perfomancePlanOrReport, string oldName, BigInteger oldStartDate, BigInteger oldEndDate, BigInteger oldPublicationDate)
        {
            var updatePerfomancePlanOrReportIndexerFunction = new UpdatePerfomancePlanOrReportIndexerFunction();
                updatePerfomancePlanOrReportIndexerFunction.PerfomancePlanOrReport = perfomancePlanOrReport;
                updatePerfomancePlanOrReportIndexerFunction.OldName = oldName;
                updatePerfomancePlanOrReportIndexerFunction.OldStartDate = oldStartDate;
                updatePerfomancePlanOrReportIndexerFunction.OldEndDate = oldEndDate;
                updatePerfomancePlanOrReportIndexerFunction.OldPublicationDate = oldPublicationDate;
            
             return ContractHandler.SendRequestAsync(updatePerfomancePlanOrReportIndexerFunction);
        }

        public Task<TransactionReceipt> UpdatePerfomancePlanOrReportIndexerRequestAndWaitForReceiptAsync(string perfomancePlanOrReport, string oldName, BigInteger oldStartDate, BigInteger oldEndDate, BigInteger oldPublicationDate, CancellationTokenSource cancellationToken = null)
        {
            var updatePerfomancePlanOrReportIndexerFunction = new UpdatePerfomancePlanOrReportIndexerFunction();
                updatePerfomancePlanOrReportIndexerFunction.PerfomancePlanOrReport = perfomancePlanOrReport;
                updatePerfomancePlanOrReportIndexerFunction.OldName = oldName;
                updatePerfomancePlanOrReportIndexerFunction.OldStartDate = oldStartDate;
                updatePerfomancePlanOrReportIndexerFunction.OldEndDate = oldEndDate;
                updatePerfomancePlanOrReportIndexerFunction.OldPublicationDate = oldPublicationDate;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updatePerfomancePlanOrReportIndexerFunction, cancellationToken);
        }

        public Task<string> UpdateRoleIndexerRequestAsync(UpdateRoleIndexerFunction updateRoleIndexerFunction)
        {
             return ContractHandler.SendRequestAsync(updateRoleIndexerFunction);
        }

        public Task<TransactionReceipt> UpdateRoleIndexerRequestAndWaitForReceiptAsync(UpdateRoleIndexerFunction updateRoleIndexerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRoleIndexerFunction, cancellationToken);
        }

        public Task<string> UpdateRoleIndexerRequestAsync(string role, string oldName)
        {
            var updateRoleIndexerFunction = new UpdateRoleIndexerFunction();
                updateRoleIndexerFunction.Role = role;
                updateRoleIndexerFunction.OldName = oldName;
            
             return ContractHandler.SendRequestAsync(updateRoleIndexerFunction);
        }

        public Task<TransactionReceipt> UpdateRoleIndexerRequestAndWaitForReceiptAsync(string role, string oldName, CancellationTokenSource cancellationToken = null)
        {
            var updateRoleIndexerFunction = new UpdateRoleIndexerFunction();
                updateRoleIndexerFunction.Role = role;
                updateRoleIndexerFunction.OldName = oldName;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRoleIndexerFunction, cancellationToken);
        }

        public Task<string> UpdateStakeholderIndexerRequestAsync(UpdateStakeholderIndexerFunction updateStakeholderIndexerFunction)
        {
             return ContractHandler.SendRequestAsync(updateStakeholderIndexerFunction);
        }

        public Task<TransactionReceipt> UpdateStakeholderIndexerRequestAndWaitForReceiptAsync(UpdateStakeholderIndexerFunction updateStakeholderIndexerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateStakeholderIndexerFunction, cancellationToken);
        }

        public Task<string> UpdateStakeholderIndexerRequestAsync(string stakeholder, string oldName)
        {
            var updateStakeholderIndexerFunction = new UpdateStakeholderIndexerFunction();
                updateStakeholderIndexerFunction.Stakeholder = stakeholder;
                updateStakeholderIndexerFunction.OldName = oldName;
            
             return ContractHandler.SendRequestAsync(updateStakeholderIndexerFunction);
        }

        public Task<TransactionReceipt> UpdateStakeholderIndexerRequestAndWaitForReceiptAsync(string stakeholder, string oldName, CancellationTokenSource cancellationToken = null)
        {
            var updateStakeholderIndexerFunction = new UpdateStakeholderIndexerFunction();
                updateStakeholderIndexerFunction.Stakeholder = stakeholder;
                updateStakeholderIndexerFunction.OldName = oldName;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateStakeholderIndexerFunction, cancellationToken);
        }
    }
}
