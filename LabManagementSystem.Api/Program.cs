using LabManagementSystem.Data;
using LabManagementSystem.Data.Providers;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);

string dbConnString = GetConnectionString();
// Add services to the container.
builder.Services.AddTransient<ILabMgmtSystemProvider, LabMgmtSystemProvider>();
builder.Services.AddDbContext<LabMgmtDbContext>(item =>
item.UseSqlServer(dbConnString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static string GetConnectionString()
{
    SecretClientOptions options = new SecretClientOptions()
    {
        Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
    };
    var client = new SecretClient(new Uri("https://capstone-rk-dbkey.vault.azure.net/"), new DefaultAzureCredential(), options);

    KeyVaultSecret secret = client.GetSecret("db-conn-string");

    return secret.Value;
}