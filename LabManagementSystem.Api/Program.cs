using LabManagementSystem.Data;
using LabManagementSystem.Data.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ILabMgmtSystemProvider, LabMgmtSystemProvider>();
builder.Services.AddDbContext<LabMgmtDbContext>(item => 
item.UseSqlServer("Server=tcp:socgensqlserver.database.windows.net,1433;Initial Catalog=Capstone-rk;Persist Security Info=False;User ID=socgen-admin;Password=Pa$$w0rd123$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
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
