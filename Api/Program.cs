using Api.Extensions;
using Api.Middlewares;
using Api.Modules;
using Domain.Services.AccountBalance;
using Serilog;
using SharedKernel.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(config =>
    {
        config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins(builder.Configuration.GetValue<string>("AllowedHosts") ?? "http://localhost").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddScoped<IDateTimes, DateTimes>();

builder.Services.RegisterAllDbContexts(builder.Configuration, builder.Environment);


#region Modules Registration

builder.Services.RegisterTransactionsModule();
builder.Services.RegisterExpensesModule();
builder.Services.RegisterFinancialToolsModule();

#endregion

#region DomainServices
builder.Services.AddTransient<IAccountBalanceService, AccountBalanceCalculator>();
#endregion

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

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
else
{
    app.UseMiddleware<ExceptionMiddleware>();
}

// app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.InitializeDatabase(app.Environment);

app.Run();