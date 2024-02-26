using DBC.Core.Shared.models;
using Newtonsoft.Json;
using Serilog;
using System.Globalization;
using System.Net;

namespace DBC.Core.Application.Filters
{

    public class GlobalExceptionHandler
    {
        public RequestDelegate requestDelegate;
        public ILogger<GlobalExceptionHandler> logger;

        public GlobalExceptionHandler(RequestDelegate requestDelegate, ILogger<GlobalExceptionHandler> loggers)
        {
            this.requestDelegate = requestDelegate;
            this.logger = loggers;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //await HandleException(context);
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                Log.Logger = new LoggerConfiguration()

                .WriteTo.File(GetLogFilePath(), rollingInterval: RollingInterval.Day) // Configure logging to write to a file with daily rolling
                .CreateLogger();
                Log.Information("------------------------Exception------------------------------");
                Log.Information($"Error:{ex.Message},\n StackTrace{ex.StackTrace}");
                await HandleException(context, ex);
            }
        }
       
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessage = JsonConvert.SerializeObject(new ResponseModel<Exception>
            {
                message = ex.Message,
                code = (int)HttpStatusCode.BadRequest,
                status = "failure"
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(errorMessage);
        }

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


    }
}
