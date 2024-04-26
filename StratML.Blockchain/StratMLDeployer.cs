using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using StratML.Blockchain.Core;
using StratML.Contracts.AdministrativeInformation;
using StratML.Contracts.AdministrativeInformation.ContractDefinition;
using StratML.Contracts.ContactInformation;
using StratML.Contracts.ContactInformation.ContractDefinition;
using StratML.Contracts.Goal;
using StratML.Contracts.Goal.ContractDefinition;
using StratML.Contracts.Mission;
using StratML.Contracts.Mission.ContractDefinition;
using StratML.Contracts.Objective;
using StratML.Contracts.Objective.ContractDefinition;
using StratML.Contracts.Organization;
using StratML.Contracts.Organization.ContractDefinition;
using StratML.Contracts.PerfomancePlanOrReport;
using StratML.Contracts.PerfomancePlanOrReport.ContractDefinition;
using StratML.Contracts.PerformanceIndicator;
using StratML.Contracts.PerformanceIndicator.ContractDefinition;
using StratML.Contracts.Relationship;
using StratML.Contracts.Relationship.ContractDefinition;
using StratML.Contracts.Role;
using StratML.Contracts.Role.ContractDefinition;
using StratML.Contracts.Stakeholder;
using StratML.Contracts.Stakeholder.ContractDefinition;
using StratML.Contracts.StratMLRegistry;
using StratML.Contracts.StratMLRegistry.ContractDefinition;
using StratML.Contracts.Vision;
using StratML.Contracts.Vision.ContractDefinition;
using StratML.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Decimal = StratML.Contracts.PerformanceIndicator.ContractDefinition.Decimal;

namespace StratML.Blockchain
{
    public class StratMLDeployer : IStratMLDeployer
    {
        protected Web3 W3 { get; }
        protected ILogger Logger { get; }
        public StratMLDeployer(Web3 w3, ILogger<StratMLDeployer> logger) 
        {
            W3 = w3;
            Logger = logger;
        }

        public async Task<string?> DeployStratML(string registryAddress, string xml, CancellationToken token = default)
        {
            StratMLRegistryService registryService = new StratMLRegistryService(W3, registryAddress);
            var stratML = XMLHelper.Deserialize<PerformancePlanOrReport>(xml);
            if(stratML == null)
            {
                Logger.LogError("Failed to deserialize StratML XML");
                return null;
            }
            Dictionary<string, Stakeholder> stakeholders = new Dictionary<string, Stakeholder>();
            Dictionary<string, string> stakleholdersNamesToAddress = new Dictionary<string, string>();
            Dictionary<string, Role> roles = new Dictionary<string, Role>();
            Dictionary<string, string> roleNamesToAddress = new Dictionary<string, string>();
            Dictionary<string, string> idToAddress = new Dictionary<string, string>();
            Dictionary<string, EntityTypes> entities = new Dictionary<string, EntityTypes>();
            foreach(var org in stratML.StrategicPlanCore.Organization)
            {
                foreach(var stakeholder in org.Stakeholder)
                {
                    stakeholders.Add(stakeholder.Name, stakeholder);
                    foreach(var role in stakeholder.Role)
                    {
                        roles.Add(role.Name, role);
                    }
                }
            }
            foreach(var goal in stratML.StrategicPlanCore.Goal)
            {
                foreach(var stakeholder in goal.Stakeholder)
                {
                    if(!stakeholders.ContainsKey(stakeholder.Name))
                    {
                        stakeholders.Add(stakeholder.Name, stakeholder);
                        foreach(var role in stakeholder.Role)
                        {
                            if(!roles.ContainsKey(role.Name))
                            {
                                roles.Add(role.Name, role);
                            }
                        }
                    }
                }
                foreach(var obj in goal.Objective)
                {
                    foreach(var stakeholder in obj.Stakeholder)
                    {
                        if(!stakeholders.ContainsKey(stakeholder.Name))
                        {
                            stakeholders.Add(stakeholder.Name, stakeholder);
                        }
                        foreach (var role in stakeholder.Role)
                        {
                            if (!roles.ContainsKey(role.Name))
                            {
                                roles.Add(role.Name, role);
                            }
                        }
                    }
                }
            }
            foreach(var role in roles.Values)
            {
                var rs = await registryService.GetRolesByNameQueryAsync(role.Name);
                var ro = rs.ReturnValue1.FirstOrDefault();
                if(ro == null)
                {
                    var r = await RoleService.DeployContractAndGetServiceAsync(W3, new RoleDeployment
                    {
                        Registry = registryAddress,
                        Name = role.Name ?? "",
                        RoleTypes = role.RoleType.Select(rt => (byte)rt).ToList(),
                        Description = role.Description ?? ""
                    });
                    if(r != null)
                    {
                        roleNamesToAddress.Add(role.Name, r.ContractHandler.ContractAddress);
                        entities.Add(r.ContractHandler.ContractAddress, EntityTypes.Role);
                    }
                }
                else
                {
                    roleNamesToAddress.Add(role.Name, ro.Base.Identifier);
                    entities.Add(ro.Base.Identifier, EntityTypes.Role);
                }
            }
            foreach(var stakeholder in stakeholders.Values)
            {
                if(stakeholder.Name == null)
                    continue;
                var sh = await registryService.GetStakeholdersByNameQueryAsync(stakeholder.Name);
                var sho = sh.ReturnValue1.FirstOrDefault();
                if(sho == null)
                {
                    var s = await StakeholderService.DeployContractAndGetServiceAsync(W3, new StakeholderDeployment
                    {
                        Name = stakeholder.Name ?? "",
                        StakeholderType = (byte)stakeholder.StakeholderTypeType,
                        Registry = registryAddress,
                        Roles = stakeholder.Role.Select(r => roleNamesToAddress[r.Name]).ToList(),
                        Description = stakeholder.Description ?? ""
                    });
                    if(s != null)
                    {
                        stakleholdersNamesToAddress.Add(stakeholder.Name, s.ContractHandler.ContractAddress);
                        foreach(var role in stakeholder.Role)
                        {
                            RoleService rs = new RoleService(W3, roleNamesToAddress[role.Name]);
                            await rs.AddStakeholderRequestAndWaitForReceiptAsync(new Contracts.Role.ContractDefinition.AddStakeholderFunction
                            {
                                StakeholderAddress = s.ContractHandler.ContractAddress
                            });
                        }
                    }   
                }
                else
                {
                    stakleholdersNamesToAddress.Add(stakeholder.Name, sho.Base.Identifier);
                }
            }
            var plan = await PerfomancePlanOrReportService.DeployContractAndGetServiceAsync(W3, new PerfomancePlanOrReportDeployment
            {
                Registry = registryAddress,
                Name = stratML.Name ?? "",
                Description = stratML.Description ?? "",
                ReportType = (byte)stratML.Type,
                OtherInformation = stratML.OtherInformation ?? ""
                
            });
            
           
            if (stratML.AdministrativeInformation != null)
            {
                var admin = await AdministrativeInformationService.DeployContractAndGetServiceAsync(W3, new AdministrativeInformationDeployment
                {
                    Registry = registryAddress,
                    Source = stratML.AdministrativeInformation.Source ?? "",
                    StartDate = !string.IsNullOrWhiteSpace(stratML.AdministrativeInformation.StartDate) ? new DateTimeOffset(DateTime.Parse(stratML.AdministrativeInformation.StartDate)).ToUnixTimeSeconds() : 0,
                    EndDate = !string.IsNullOrWhiteSpace(stratML.AdministrativeInformation.EndDate) ? new DateTimeOffset(DateTime.Parse(stratML.AdministrativeInformation.EndDate)).ToUnixTimeSeconds() : 0,
                    PublicationDate = !string.IsNullOrWhiteSpace(stratML.AdministrativeInformation.PublicationDate) ? new DateTimeOffset(DateTime.Parse(stratML.AdministrativeInformation.PublicationDate)).ToUnixTimeSeconds() : 0
                });
                if(admin != null)
                {
                    if(stratML.AdministrativeInformation.Identifier != null)
                        idToAddress.Add(stratML.AdministrativeInformation.Identifier, admin.ContractHandler.ContractAddress);
                    await plan.SetAdministrativeInformationRequestAndWaitForReceiptAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.SetAdministrativeInformationFunction
                    {
                        AdminInfo = admin.ContractHandler.ContractAddress
                    });
                }
            }
            if(stratML.Submitter != null)
            {
                var submitter = await ContactInformationService.DeployContractAndGetServiceAsync(W3, new ContactInformationDeployment
                {
                    Registry = registryAddress,
                    GivenName = stratML.Submitter.GivenName ?? "",
                    Surname =  stratML.Submitter.Surname ?? "",
                    PhoneNumber = stratML.Submitter.PhoneNumber ?? "",
                    EmailAddress = stratML.Submitter.EmailAddress ?? ""
                });
                if(submitter != null)
                {
                    stratML.Submitter.Identifier ??= Guid.NewGuid().ToString();
                    idToAddress.Add(stratML.Submitter.Identifier, submitter.ContractHandler.ContractAddress);
                    entities.Add(stratML.Submitter.Identifier, EntityTypes.Stakeholder);
                    await plan.SetsubmitterRequestAndWaitForReceiptAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.SetsubmitterFunction
                    {
                        Submitter = submitter.ContractHandler.ContractAddress
                    }); 
                }
            }
            if(stratML.StrategicPlanCore != null)
            {
                foreach (var org in stratML.StrategicPlanCore.Organization)
                {
                    var o = await OrganizationService.DeployContractAndGetServiceAsync(W3, new OrganizationDeployment
                    {
                        Name = org.Name ?? "",
                        Description = org.Description ?? "",
                        Registry = registryAddress,
                        Acryonym = org.Acronym ?? ""
                    });
                    if (o != null)
                    {
                        org.Identifier ??= Guid.NewGuid().ToString();
                        idToAddress.Add(org.Identifier, o.ContractHandler.ContractAddress);
                        entities.Add(org.Identifier, EntityTypes.Organization);
                        await plan.AddOrganizationRequestAndWaitForReceiptAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.AddOrganizationFunction
                        {
                            OrganizationAddress = o.ContractHandler.ContractAddress
                        });
                        await registryService.AddOrganizationRequestAndWaitForReceiptAsync(new Contracts.StratMLRegistry.ContractDefinition.AddOrganizationFunction
                        {
                            Organization = o.ContractHandler.ContractAddress
                        });
                        foreach (var stakeholder in org.Stakeholder)
                        {
                            if (stakleholdersNamesToAddress.TryGetValue(stakeholder.Name, out string? address))
                                await o.AddStakeholderRequestAndWaitForReceiptAsync(new Contracts.Organization.ContractDefinition.AddStakeholderFunction
                                {
                                    StakeholderAddress = address
                                });
                        }
                    }
                }
                if(stratML.StrategicPlanCore.Mission != null)
                {
                    var mission = await MissionService.DeployContractAndGetServiceAsync(W3, new MissionDeployment
                    {
                        Registry = registryAddress,
                        Description = stratML.StrategicPlanCore.Mission.Description ?? ""
                    });
                    if(mission != null)
                    {
                        stratML.StrategicPlanCore.Mission.Identifier ??= Guid.NewGuid().ToString();     
                        idToAddress.Add(stratML.StrategicPlanCore.Mission.Identifier, mission.ContractHandler.ContractAddress);
                        entities.Add(stratML.StrategicPlanCore.Mission.Identifier, EntityTypes.Mission);
                        await plan.SetMissionRequestAndWaitForReceiptAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.SetMissionFunction
                        {
                            Mission = mission.ContractHandler.ContractAddress
                        });
                    }
                }
                if(stratML.StrategicPlanCore.Vision != null)
                {
                    var vision = await VisionService.DeployContractAndGetServiceAsync(W3, new VisionDeployment
                    {
                        Registry = registryAddress,
                        Description = stratML.StrategicPlanCore.Vision.Description
                    });
                    if(vision != null)
                    {
                        stratML.StrategicPlanCore.Vision.Identifier ??= Guid.NewGuid().ToString();
                        idToAddress.Add(stratML.StrategicPlanCore.Vision.Identifier, vision.ContractHandler.ContractAddress);
                        entities.Add(stratML.StrategicPlanCore.Vision.Identifier, EntityTypes.Vision);
                        await plan.UpdateVisionRequestAndWaitForReceiptAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.UpdateVisionFunction
                        {
                            Vision = vision.ContractHandler.ContractAddress
                        }); 
                    }
                }
                foreach(var val in stratML.StrategicPlanCore.Value)
                {
                    await plan.AddValueRequestAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.AddValueFunction
                    {
                        Name = val.Name ?? "",
                        Description = val.Description ?? ""
                    });
                }
                foreach(var goal in stratML.StrategicPlanCore.Goal)
                {
                    var g = await GoalService.DeployContractAndGetServiceAsync(W3, new GoalDeployment
                    {
                        Registry = registryAddress,
                        Description = goal.Description ?? "",
                        Name = goal.Name ?? "",
                        SequenceIndicator = goal.SequenceIndicator ?? "",
                        OtherInformation = goal.OtherInformation ?? ""
                    });
                    if(g != null)
                    {
                        goal.Identifier ??= Guid.NewGuid().ToString();
                        idToAddress.Add(goal.Identifier, g.ContractHandler.ContractAddress);
                        entities.Add(goal.Identifier, EntityTypes.Goal);
                        await plan.AddGoalRequestAndWaitForReceiptAsync(new Contracts.PerfomancePlanOrReport.ContractDefinition.AddGoalFunction()
                        {
                            GoalAddress = g.ContractHandler.ContractAddress
                        });
                        foreach(var stakeholder in goal.Stakeholder)
                        {
                            if(stakleholdersNamesToAddress.TryGetValue(stakeholder.Name, out string? address))
                                await g.AddStakeholderRequestAndWaitForReceiptAsync(new Contracts.Goal.ContractDefinition.AddStakeholderFunction
                                {
                                    StakeholderAddress = address
                                });
                        }
                        foreach(var obj in goal.Objective)
                        {
                            var o = await ObjectiveService.DeployContractAndGetServiceAsync(W3, new ObjectiveDeployment()
                            {
                                Registry = registryAddress,
                                Description = obj.Description ?? "",
                                Name = obj.Name ?? "",
                                SequenceIndicator = obj.SequenceIndicator ?? "",
                                OtherInformation = obj.OtherInformation ?? ""
                            });
                            if(o != null)
                            {
                                obj.Identifier ??= Guid.NewGuid().ToString();
                                idToAddress.Add(obj.Identifier, o.ContractHandler.ContractAddress);
                                entities.Add(obj.Identifier, EntityTypes.Objective);
                                await g.AddObjectiveRequestAndWaitForReceiptAsync(new Contracts.Goal.ContractDefinition.AddObjectiveFunction()
                                {
                                    ObjectiveAddress = o.ContractHandler.ContractAddress
                                });
                                foreach(var stakeholder in obj.Stakeholder)
                                {
                                    if(stakleholdersNamesToAddress.TryGetValue(stakeholder.Name, out string? address))
                                        await o.AddStakeholderRequestAndWaitForReceiptAsync(new Contracts.Objective.ContractDefinition.AddStakeholderFunction
                                        {
                                            StakeholderAddress = address
                                        });
                                }
                                foreach(var pi in obj.PerformanceIndicator)
                                {
                                    var p = await PerformanceIndicatorService.DeployContractAndGetServiceAsync(W3, new PerformanceIndicatorDeployment()
                                    {
                                        Registry = registryAddress,
                                        MeasurementDimension = pi.MeasurementDimension ?? "",
                                        UnitOfMeasurement = pi.UnitOfMeasurement ?? "",
                                        PerfomanceIndicator = (byte)pi.PerformanceIndicatorType,
                                        VauleChangeStage = (byte)pi.ValueChainStage,
                                        SequenceIndicator = pi.SequenceIndicator ?? "",
                                        OtherInformation = pi.OtherInformation ?? ""
                                    });
                                    if(p != null)
                                    {
                                        pi.Identifier ??= Guid.NewGuid().ToString();
                                        idToAddress.Add(pi.Identifier, p.ContractHandler.ContractAddress);
                                        entities.Add(pi.Identifier, EntityTypes.PerformanceIndicator);
                                        await o.AddPerformanceIndicatorRequestAndWaitForReceiptAsync(new Contracts.Objective.ContractDefinition.AddPerformanceIndicatorFunction()
                                        {
                                            PerformanceIndicatorAddress = p.ContractHandler.ContractAddress
                                        });
                                        foreach(var mi in pi.MeasurementInstance)
                                        {
                                            await p.AddMeasurementInstanceRequestAndWaitForReceiptAsync(new Contracts.PerformanceIndicator.ContractDefinition.AddMeasurementInstanceFunction()
                                            {
                                                MeasurementInstance = new Contracts.PerformanceIndicator.ContractDefinition.MeasurementInstance()
                                                {
                                                    ActualResults = mi.ActualResult.Select(ar => new Contracts.PerformanceIndicator.ContractDefinition.ActualResult()
                                                    {
                                                        StartDate = ar.StartDate != null ? new DateTimeOffset(DateTime.Parse(ar.StartDate)).ToUnixTimeSeconds() : 0,
                                                        EndDate = ar.EndDate != null ? new DateTimeOffset(DateTime.Parse(ar.EndDate)).ToUnixTimeSeconds() : 0,
                                                        NumberOfUnits = ConvertToDecimal(ar.NumberOfUnits),
                                                        Descriptor = new Contracts.PerformanceIndicator.ContractDefinition.Descriptor()
                                                        {
                                                            Value = ar.Descriptor.DescriptorValue ?? "",
                                                            Name = ar.Descriptor.DescriptorName ?? ""
                                                        },
                                                        Description = ar.Description
                                                    }).ToList(),
                                                    TargetResults = mi.TargetResult.Select(tr => new Contracts.PerformanceIndicator.ContractDefinition.TargetResult()
                                                    {
                                                        StartDate = tr.StartDate != null ? new DateTimeOffset(DateTime.Parse(tr.StartDate)).ToUnixTimeSeconds() : 0,
                                                        EndDate = tr.EndDate != null ? new DateTimeOffset(DateTime.Parse(tr.EndDate)).ToUnixTimeSeconds() : 0,
                                                        NumberOfUnits = ConvertToDecimal(tr.NumberOfUnits),
                                                        Descriptor = new Contracts.PerformanceIndicator.ContractDefinition.Descriptor()
                                                        {
                                                            Value = tr.Descriptor.DescriptorValue ?? "",
                                                            Name = tr.Descriptor.DescriptorName ?? ""
                                                        },
                                                        Description = tr.Description
                                                    }).ToList()
                                                }
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach(var goal in stratML.StrategicPlanCore.Goal)
                {
                    foreach(var obj in goal.Objective)
                    {
                        foreach(var pi in obj.PerformanceIndicator)
                        {
                            PerformanceIndicatorService pis = new PerformanceIndicatorService(W3, idToAddress[pi.Identifier]);
                            foreach(var rel in pi.Relationship)
                            {
                                var r = await RelationshipService.DeployContractAndGetServiceAsync(W3, new RelationshipDeployment()
                                {
                                    Registry = registryAddress,
                                    Description = rel.Description ?? "",
                                    RelationshipType = (byte)rel.RelationshipType,
                                    Name = rel.Name
                                });
                                if(r != null)
                                {
                                    rel.Identifier ??= Guid.NewGuid().ToString();
                                    idToAddress.Add(rel.Identifier, r.ContractHandler.ContractAddress);
                                    entities.Add(rel.Identifier, EntityTypes.Relationship);
                                    await pis.AddRelationshipRequestAndWaitForReceiptAsync(new Contracts.PerformanceIndicator.ContractDefinition.AddRelationshipFunction()
                                    {
                                        RelationshipAddress = r.ContractHandler.ContractAddress
                                    });
                                }
                            }
                        }
                    }
                }
                foreach (var goal in stratML.StrategicPlanCore.Goal)
                {
                    foreach (var obj in goal.Objective)
                    {
                        foreach (var pi in obj.PerformanceIndicator)
                        {
                            foreach (var rel in pi.Relationship)
                            {
                                RelationshipService rs = new RelationshipService(W3, idToAddress[rel.Identifier]);
                                foreach (var rf in rel.ReferentIdentifier)
                                {
                                    if (idToAddress.TryGetValue(rf, out string? address))
                                    {
                                        await rs.AddReferenceRequestAndWaitForReceiptAsync(new Contracts.Relationship.ContractDefinition.AddReferenceFunction()
                                        {
                                            Identifier = address,
                                            EntityType = (byte)entities[rf]
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return plan.ContractHandler.ContractAddress;
        }
        enum EntityTypes :byte
        {
            Role,
            Stakeholder,
            PerformanceIndicator,
            Objective,
            Organization,
            Goal,
            Mission,
            Vision,
            Relationship
        }
        public Decimal ConvertToDecimal(string value)
        {
            if(decimal.TryParse(value, out decimal d))
            {
                int precision = BitConverter.GetBytes(decimal.GetBits(d)[3])[2];
                return new Decimal()
                {
                    Value = (long)(d * (decimal)Math.Pow(10, precision)),
                    Precision = precision
                };
            }
            return new Decimal();
        }
        public async Task<string?> DeployRegistry(CancellationToken token = default)
        {
            var registry = await StratMLRegistryService.DeployContractAndGetServiceAsync(W3, new StratMLRegistryDeployment());
            return registry.ContractHandler.ContractAddress;
        }

        public async Task<PerformancePlanOrReport?> Load(string address, CancellationToken token = default)
        {
            PerfomancePlanOrReportService service = new PerfomancePlanOrReportService(W3, address);
            var report = await service.GetPerfomancePlanOrReportResponseQueryAsync();
            if(report == null || report.ReturnValue1 == null)
            {
                Logger.LogError("Failed to load StratML from address {0}", address);
                return null;
            }
            var doc = report.ReturnValue1;
            PerformancePlanOrReport stratML = new PerformancePlanOrReport()
            {
                Name = doc.Base.Name,
                Description = doc.Base.Description,
                Type = (PerformancePlanOrReportType)doc.Base.ReportType,
                OtherInformation = doc.Base.OtherInformation
            };
            stratML.Submitter = new ContactInformationType()
            {
                GivenName = doc.Base.Submitter.GivenName,
                Surname = doc.Base.Submitter.Surname,
                PhoneNumber = doc.Base.Submitter.PhoneNumber,
                EmailAddress = doc.Base.Submitter.EmailAddress,
                Identifier = doc.Base.Submitter.Identifier
            };
            stratML.AdministrativeInformation = new AdministrativeInformationType()
            {
                Source = doc.Base.AdministrativeInformation.Source,
                StartDate = doc.Base.AdministrativeInformation.StartDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)doc.Base.AdministrativeInformation.StartDate).ToString() : "",
                EndDate = doc.Base.AdministrativeInformation.EndDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)doc.Base.AdministrativeInformation.EndDate).ToString() : "",
                PublicationDate = doc.Base.AdministrativeInformation.PublicationDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)doc.Base.AdministrativeInformation.PublicationDate).ToString() : "",
                Identifier = doc.Base.AdministrativeInformation.Identifier
            };
            List<Organization> orgs = new List<Organization>();
            stratML.StrategicPlanCore = new StrategicPlanCore();
            foreach(var org in doc.StrategeticPlanCore.Organizations)
            {
                var os = new OrganizationService(W3, org.Identifier);
                var od = (await os.GetOrganizationResponseQueryAsync()).ReturnValue1;
                
                Organization o = new Organization()
                {
                    Name = od.Base.Name,
                    Description = od.Base.Description,
                    Acronym = od.Base.Acryonym,
                    Identifier = od.Base.Identifier,
                };
                List<Stakeholder> stakeholders = new List<Stakeholder>();
                foreach(var sh in od.Stakeholders)
                {
                    Stakeholder s = new Stakeholder()
                    {
                        Name = sh.Base.Name,
                        StakeholderTypeType = (StakeholderStakeholderTypeType)sh.Base.StakeholderType,
                        Description = sh.Description
                    };
                    List<Role> roles = new List<Role>();
                    foreach(var role in sh.Roles)
                    {
                        var rs = new RoleService(W3, role.Identifier);
                        var r = (await rs.GetRoleQueryAsync()).ReturnValue1;
                        roles.Add(new Role()
                        {
                            Name = r.Base.Name,
                            Description = r.Base.Description,
                            RoleType = r.Base.RoleTypes.Select(rt => (RoleType)rt).ToArray()
                        });
                    }
                    s.Role = roles.ToArray();
                    stakeholders.Add(s);
                }
                o.Stakeholder = stakeholders.ToArray();
                orgs.Add(o);
            }
            stratML.StrategicPlanCore.Organization = orgs.ToArray();
            stratML.StrategicPlanCore.Mission = new Mission()
            {
                Description = doc.StrategeticPlanCore.Base.Mission.Description,
                Identifier = doc.StrategeticPlanCore.Base.Mission.Identifier
            };
            stratML.StrategicPlanCore.Vision = new Vision()
            {
                Description = doc.StrategeticPlanCore.Base.Vision.Description,
                Identifier = doc.StrategeticPlanCore.Base.Vision.Identifier
            };
            stratML.StrategicPlanCore.Value = doc.StrategeticPlanCore.Base.Values.Select(v => new StratML.Core.Value()
            {
                Name = v.Name,
                Description = v.Description
            }).ToArray();
            List<Goal> goals = new List<Goal>();
            foreach(var goal in doc.StrategeticPlanCore.Goals)
            {
                var gs = new GoalService(W3, goal.Identifier);
                var g = (await gs.GetGoalResponseQueryAsync()).ReturnValue1;
                Goal gl = new Goal()
                {
                    Name = g.Base.Name,
                    Description = g.Base.Description,
                    SequenceIndicator = g.Base.SequenceIndicator,
                    OtherInformation = g.Base.OtherInformation,
                    Identifier = g.Base.Identifier
                };
                List<Stakeholder> stakeholders = new List<Stakeholder>();
                foreach(var sh in g.Stakeholders)
                {
                    var ss = new StakeholderService(W3, sh.Identifier);
                    var s = (await ss.GetStakeholderQueryAsync()).ReturnValue1;
                    var stake = new Stakeholder()
                    {
                        Name = s.Base.Name,
                        Description = s.Description,
                        StakeholderTypeType = (StakeholderStakeholderTypeType)s.Base.StakeholderType
                    };
                    List<Role> roles = new List<Role>();
                    foreach(var role in s.Roles)
                    {
                        roles.Add(new Role()
                        {
                            Name = role.Name,
                            Description = role.Description,
                            RoleType = role.RoleTypes.Select(rt => (RoleType)rt).ToArray()
                        });
                    }
                    stake.Role = roles.ToArray();
                    stakeholders.Add(stake);
                }
                gl.Stakeholder = stakeholders.ToArray();
                List<ObjectiveType> objectives = new List<ObjectiveType>();
                foreach(var obj in g.Objectives)
                {
                    var os = new ObjectiveService(W3, obj.Identifier);
                    var o = (await os.GetObjectiveResponseQueryAsync()).ReturnValue1;
                    var objective = new ObjectiveType()
                    {
                        Name = o.Base.Name,
                        Description = o.Base.Description,
                        SequenceIndicator = o.Base.SequenceIndicator,
                        OtherInformation = o.Base.OtherInformation,
                        Identifier = o.Base.Identifier
                    };
                    List<Stakeholder> objStakeholders = new List<Stakeholder>();
                    foreach(var sh in o.Stakeholders)
                    {
                        var ss = new StakeholderService(W3, sh.Identifier);
                        var s = (await ss.GetStakeholderQueryAsync()).ReturnValue1;
                        var stake = new Stakeholder()
                        {
                            Name = s.Base.Name,
                            Description = s.Description,
                            StakeholderTypeType = (StakeholderStakeholderTypeType)s.Base.StakeholderType
                        };
                        List<Role> roles = new List<Role>();
                        foreach(var role in s.Roles)
                        {
                            roles.Add(new Role()
                            {
                                Name = role.Name,
                                Description = role.Description,
                                RoleType = role.RoleTypes.Select(rt => (RoleType)rt).ToArray()
                            });
                        }
                        stake.Role = roles.ToArray();
                        objStakeholders.Add(stake);
                    }
                    objective.Stakeholder = objStakeholders.ToArray();
                    List<PerformanceIndicator> performanceIndicators = new List<PerformanceIndicator>();
                    foreach(var pi in o.Base.PerfomanceIndicators)
                    {
                        var pis = new PerformanceIndicatorService(W3, pi.Identifier);
                        var p = (await pis.GetPerformanceIndicatorQueryAsync()).ReturnValue1;
                        var perf = new PerformanceIndicator()
                        {
                            MeasurementDimension = p.MeasurementDimension,
                            UnitOfMeasurement = p.UnitOfMeasurement,
                            PerformanceIndicatorType = (PerformanceIndicatorTypeType)p.PerfomanceIndicator,
                            ValueChainStage = (ValueChainStageType)p.VauleChangeStage,
                            SequenceIndicator = p.SeqeunceIndicator,
                            OtherInformation = p.OtherInformation,
                            Identifier = p.Identifier
                        };
                        perf.MeasurementInstance = p.MeasurementInstances.Select(mi => new StratML.Core.MeasurementInstance()
                        {
                            ActualResult = mi.ActualResults.Select(ar => new StratML.Core.ActualResult()
                            {
                                StartDate = ar.StartDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)ar.StartDate).ToString() : "",
                                EndDate = ar.EndDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)ar.EndDate).ToString() : "",
                                NumberOfUnits = ar.NumberOfUnits.Value.ToString(),
                                Descriptor = new StratML.Core.Descriptor()
                                {
                                    DescriptorName = ar.Descriptor.Name,
                                    DescriptorValue = ar.Descriptor.Value
                                },
                                Description = ar.Description
                            }).ToArray(),
                            TargetResult = mi.TargetResults.Select(tr => new StratML.Core.TargetResult()
                            {
                                StartDate = tr.StartDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)tr.StartDate).ToString() : "",
                                EndDate = tr.EndDate != 0 ? DateTimeOffset.FromUnixTimeSeconds((long)tr.EndDate).ToString() : "",
                                NumberOfUnits = tr.NumberOfUnits.Value.ToString(),
                                Descriptor = new StratML.Core.Descriptor()
                                {
                                    DescriptorName = tr.Descriptor.Name,
                                    DescriptorValue = tr.Descriptor.Value
                                },
                                Description = tr.Description
                            }).ToArray()
                        }).ToArray();
                        List<Relationship> rls = new List<Relationship>();
                        foreach(var refr in pi.Relationships)
                        {
                            var rs = new RelationshipService(W3, refr.Identifier);
                            var r = (await rs.GetRelationshipQueryAsync()).ReturnValue1;
                            var rel = new Relationship()
                            {
                                Description = r.Description,
                                Name = r.Name,
                                RelationshipType = (RelationshipTypeType)r.RelationshipType,
                                Identifier = r.Identifier
                            };
                            List<string> referents = new List<string>();
                            foreach(var refId in r.References)
                            {
                                referents.Add(refId.Identifier);
                            }
                            rel.ReferentIdentifier = referents.ToArray();
                            rls.Add(rel);
                        }
                        perf.Relationship = rls.ToArray();
                    }
                    objective.PerformanceIndicator = performanceIndicators.ToArray();
                    objectives.Add(objective);
                }
                gl.Objective = objectives.ToArray();
                goals.Add(gl);
            }
            stratML.StrategicPlanCore.Goal = goals.ToArray();
            return stratML;
        }
    }
}
