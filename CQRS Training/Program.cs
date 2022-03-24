using CQRS_Training.Data;
using CQRS_Training.Data.Handlers;
using CQRS_Training.Data.Infra.Contexts;
using CQRS_Training.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<CqrsContext>(op => op.UseNpgsql(Common.GetSettings("ConnectionString")));
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddTransient<ICreateCustomerHandler, CreateCustomerHandler>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();