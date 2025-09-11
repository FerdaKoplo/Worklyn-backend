using Casbin;
using Casbin.Persist.Adapter.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Worklyn_backend.Domain.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<CasbinDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<Enforcer>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var modelPath = Path.Combine(env.ContentRootPath, "rbac_model.conf");

    // Get the Casbin DbContext instance
    var dbContext = sp.GetRequiredService<CasbinDbContext>();
    var adapter = new EFCoreAdapter<int>(dbContext);

    var enforcer = new Enforcer(modelPath, adapter);
    enforcer.LoadPolicy();

    return enforcer;
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
