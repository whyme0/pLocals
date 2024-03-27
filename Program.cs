using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pLocals.Data;
using pLocals.Models;
using pLocals.Repository;
using pLocals.Repository.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<AccountRepository>();

builder.Services.AddLogging(b =>
    b.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
