using Casbin;
using Casbin.Persist.Adapter.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Application.Services.Auth;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;

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

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
builder.Services.AddScoped<AuthService>();

// Password hasher (generic version)
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// --- Controllers & Swagger ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
