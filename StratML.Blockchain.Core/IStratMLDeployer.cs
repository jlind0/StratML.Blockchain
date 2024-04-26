using StratML.Contracts.PerfomancePlanOrReport.ContractDefinition;
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
        Task<string?> DeployStratML(string registryAddress, string xml, CancellationToken token = default);
        Task<string?> DeployRegistry(CancellationToken token = default);
        Task<PerformancePlanOrReport?> Load(string address, CancellationToken token = default);
    }
}
