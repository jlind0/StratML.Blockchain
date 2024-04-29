using StratML.Contracts.PerfomancePlanOrReport.ContractDefinition;
using StratML.Contracts.StratMLRegistry.ContractDefinition;
using StratML.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratML.Blockchain.Core
{
    public interface IStratMLDeployer
    {
        Task<string?> DeployStratML(string registryAddress, PerformancePlanOrReport stratML, IProgress<ProgressReport>? progress = null, CancellationToken token = default);
        Task<string?> DeployRegistry(CancellationToken token = default);
        Task<PerformancePlanOrReport?> Load(string address, CancellationToken token = default);
        Task<GetAllPerfomancePlanOrReportsOutputDTO> GetRegisteredPlans(string registry, CancellationToken token = default);
    }
    public class ProgressReport
    {
        public int Percent { get; set; }
        public string Status { get; set; } = null!;
    }
}
