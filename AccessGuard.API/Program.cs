global using AccessGuard_API.Exceptions;

using AccessGuard_API.Data;
using AccessGuard_API.Middleware;
using AccessGuard_API.Repositories.Errors;
using AccessGuard_API.Repositories.Tenants;
using AccessGuard_API.Services.Errors;
using AccessGuard_API.Services.Tenants;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AccessGuardDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("AccessGuardDB")!));

builder.Services.AddScoped<ITenantRepository,TenantRepository>();
builder.Services.AddScoped<IErrorRepository,ErrorRepository>();

builder.Services.AddScoped<ITenantService,TenantService>();
builder.Services.AddScoped<IErrorsService,ErrorsService>();

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
