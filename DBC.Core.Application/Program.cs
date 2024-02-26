using DBC.Core.Application.Filters;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoggerFactory, LoggerFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region Global Exeption Handling
app.UseMiddleware(typeof(GlobalExceptionHandler));
#endregion

// Helper method to get log file path
static string GetLogFilePath()
{
    var Logs = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    var YearPath = Path.Combine(Logs, DateTime.Now.Year.ToString());
    var MonthPath = Path.Combine(YearPath, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month).ToString());
    if (!Directory.Exists(MonthPath))
    {
        Directory.CreateDirectory(MonthPath);
    }
    var dateFile = DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
    var path = Path.Combine(MonthPath, dateFile);
    return path;
}
// Initialize Serilog logger
Log.Logger = new LoggerConfiguration()
    
    .WriteTo.File(GetLogFilePath(), rollingInterval: RollingInterval.Day) // Configure logging to write to a file with daily rolling
    .CreateLogger();



Log.Information("Starting application");

// Your application logic goes here

Log.Information("Shutting down application");
Log.CloseAndFlush();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
