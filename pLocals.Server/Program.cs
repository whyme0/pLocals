using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using pLocals.Data;
using pLocals.Models;
using pLocals.Repository;
using pLocals.Repository.Abstract;
using Microsoft.Net.Http.Headers;

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
    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

    // CORS
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
        });
    });

    // Add database settings
    builder.Services.AddDbContext<AppDbContext>(o =>
    {
#if DEBUG
        o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionForDebug"));
#else
        o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
#endif
    });
    builder.Services.AddScoped<AccountRepository>();

    var app = builder.Build();

#if DEBUG
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
            Log.Information("Database created");
        }
    });

    // What to do when applictions stopped
    app.Lifetime.ApplicationStopping.Register(() =>
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureDeleted();
            Log.Information("Database deleted");
        }
    });
# endif

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();

    // CORS
    app.UseCors();
    
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