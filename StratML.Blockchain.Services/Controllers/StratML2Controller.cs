﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StratML.Blockchain.Core;
using StratML.Core;

namespace StratML.Blockchain.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StratML2Controller : ControllerBase
    {
        protected IStratMLDeployer Deployer { get; }
        public StratML2Controller(IStratMLDeployer deployer)
        {
            Deployer = deployer;
        }
        [HttpGet("deploy")]
        public async Task<ActionResult<string?>> DeployRegistry(CancellationToken token = default)
        {
            var address = await Deployer.DeployRegistry(token);
            return address;
        }
        [HttpPost("deploy/{registryAddress}")]
        public async Task<ActionResult<string?>> DeployStratML([FromBody] PerformancePlanOrReport stratML, string registryAddress, CancellationToken token = default)
        {
            var address = await Deployer.DeployStratML(registryAddress, stratML, token);
            return address;
        }
        [HttpGet("{address}")]
        public async Task<ActionResult<PerformancePlanOrReport?>> Load(string address, CancellationToken token = default)
        {
            var stratML = await Deployer.Load(address, token);
            return stratML;
        }
    }
}