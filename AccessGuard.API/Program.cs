using AccessGuard_API.Data;
using AcessGuard_API.Middleware;
using AcessGuard_API.Repositories.Tenants;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AccessGuardDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("AccessGuardDB")!));

builder.Services.AddScoped<ITenantRepository,TenantRepository>();
builder.Services.AddTransient<AccessGuardExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<AccessGuardExceptionMiddleware>();

app.Run();
