using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using KsyushaNik_kt_31_23.Database;

var builder = WebApplication.CreateBuilder(args);

// Инициализация логгера NLog
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();

    // Регистрация DbContext для PostgreSQL
    builder.Services.AddDbContext<StudentDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = string.Empty; // Открывать Swagger прямо на главной странице
        });
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}