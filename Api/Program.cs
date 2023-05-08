using Api.Extensions;
using Domain.Services.AccountBalance;
using Infrastructure;
using Expenses.Infrastructure;
using Application;
using Expenses.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddApplication();
builder.Services.AddExpensesApplication();
builder.Services.AddTransactionsInfrastructure(builder.Configuration);
builder.Services.AddExpensesInfrastructure(builder.Configuration);

#region DomainServices
builder.Services.AddTransient<IAccountBalanceService, AccountBalanceCalculator>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", (context) => {
        context.Response.Redirect("/swagger/");
        return Task.CompletedTask;
    });
}

// app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.InitializeDatabase();

app.Run();