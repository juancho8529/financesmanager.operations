using FinancesManager.Operations.Application.Handlers;
using FinancesManager.Operations.Core.Repositories;
using FinancesManager.Operations.Core.Repositories.Base;
using FinancesManager.Operations.Infrastructure.Data;
using FinancesManager.Operations.Infrastructure.Repositories;
using FinancesManager.Operations.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee.API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<OperationContext>(m => 
    m.UseSqlServer(builder.Configuration.GetConnectionString("OperationDB"), b => b.MigrationsAssembly("FinancesManager.Operations.API")), ServiceLifetime.Singleton);
builder.Services.AddAutoMapper(typeof(CreateOperationHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateOperationHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IOperationRepository, OperationRepository>();


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

app.Run();
