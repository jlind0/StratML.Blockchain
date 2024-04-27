using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using StratML.Blockchain;
using StratML.Blockchain.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(provider =>
{
var acct = new Account(builder.Configuration["Infura:SecretKey"] ?? throw new InvalidOperationException());
var w3 = new Web3(acct, builder.Configuration["Infura:Endpoint"] ?? throw new InvalidDataException());
return w3;
});
builder.Services.AddSingleton<IStratMLDeployer, StratMLDeployer>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
