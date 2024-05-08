using Microsoft.Extensions.Logging;
using ReactiveUI;
using StratML.Blockchain.Core;
using StratML.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using StratML.Contracts.StratMLRegistry.ContractDefinition;

namespace StratML.Blockchain.ViewModels
{
    public class IndexViewModel : ReactiveObject
    {
        protected IStratMLDeployer Deployer { get; }
        protected ILogger Logger { get; }
        private string? _registryAddress;
        public string? RegistryAddress
        {
            get => _registryAddress;
            set => this.RaiseAndSetIfChanged(ref _registryAddress, value);
        }
        private string? xml;
        public string? Xml
        {
            get => xml;
            set => this.RaiseAndSetIfChanged(ref xml, value);
        }
        private string? _address;
        public string? Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }
        protected string? status;
        public string? Status
        {
            get => status;
            set => this.RaiseAndSetIfChanged(ref status, value);
        }
        public ReactiveCommand<Unit, Unit> DeployStratML { get; }
        public ReactiveCommand<Unit, Unit> Load { get; }
        public ObservableCollection<PerfomancePlanOrReportResponse> Plans { get; } = new();
        public IndexViewModel(IStratMLDeployer deployer, ILogger<IndexViewModel> logger)
        {
            Deployer = deployer;
            Logger = logger;
            DeployStratML = ReactiveCommand.CreateFromTask(async () =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(RegistryAddress) || string.IsNullOrWhiteSpace(Xml))
                    {
                        Logger.LogError("Registry address and XML must be provided");
                        return;
                    }
                    var progress = new Progress<ProgressReport>(report =>
                    {
                        Status = $"{report.Percent}% - {report.Status}";
                    });
                    var report = XMLHelper.Deserialize<PerformancePlanOrReport>(Xml);
                    Address = await Deployer.DeployStratML(RegistryAddress ?? throw new InvalidOperationException(), report ?? throw new InvalidDataException(), progress);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Failed to deploy StratML");
                    Status = ex.Message;
                }
            });
            Load = ReactiveCommand.CreateFromTask(async () =>
            {
                try
                {
                    if(string.IsNullOrWhiteSpace(RegistryAddress))
                    {
                        Logger.LogError("Registry address must be provided");
                        return;
                    }
                    var plans = await Deployer.GetRegisteredPlans(RegistryAddress ?? throw new InvalidOperationException());
                    Plans.Clear();
                    foreach (var plan in plans.ReturnValue1.Where(p => p != null))
                    {
                        Plans.Add(plan ?? throw new InvalidOperationException());
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Failed to load StratML");
                    Status = ex.Message;
                }
            });
        }
    }
}
