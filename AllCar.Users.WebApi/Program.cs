using AllCar.Core.DI;
using AllCar.Core.Identity;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Core.Interfaces.Identity;
using AllCar.Core.Middlewares.Identity;
using AllCar.DataAccess.Context;
using AllCar.DataAccess.Logging.Providers;
using AllCar.DataAccess.Logging.Providers.Concrete;
using AllCar.DataAccess.Units;
using AllCar.Redis.Providers;
using AllCar.Users.WebApi.Mappers;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConnectionString"), b => b.MigrationsAssembly("AllCar.DataAccess"))
                                              .EnableSensitiveDataLogging());

builder.Services.AddScoped<ILoggingProvider, IdentityLoggingProvider>();
builder.Services.AddScoped<IUnitOfWork, IdentityUnitOfWork>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICachingProvider, AllCar.Redis.Providers.CachingProvider>(x => new CachingProvider("localhost:6379"));

builder.Services.AddCoreProviders();

builder.Services.AddScoped<IUserIdentityService, UserIdentityService>();

builder.Services.AddScoped<IdentityProcessingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsFixPolicy",
        build => build
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(builder.Configuration.GetSection("CorsOrigins").Get<string[]>())
        .AllowCredentials()
    );
});


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(ViewMapperProfile));
    cfg.AddExpressionMapping();
    cfg.AddCollectionMappers();
    cfg.AllowNullCollections = true;
});

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
