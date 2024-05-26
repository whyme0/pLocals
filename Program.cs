using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using pLocals.Data;
using pLocals.Models;
using pLocals.Repository;
using pLocals.Repository.Abstract;

// Add logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
    .WriteTo.Console(
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

try
{
    Log.Information("Start web application.");

    var builder = WebApplication.CreateBuilder(args);

    // Add logger
    //obj.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning));
    builder.Services.AddSerilog();

    // Add services to the container.
    builder.Services.AddControllers();

    // Add database settings
    builder.Services.AddDbContext<AppDbContext>(o =>
    {
        o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
        builder.Services.AddScoped<AccountRepository>();

    

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.Information("End web application.");
    Log.CloseAndFlush();
}
