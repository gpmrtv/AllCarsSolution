using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using AllCar.Core.DI;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.DataAccess;
using AllCar.DataAccess.Context;
using AllCar.DataAccess.Logging.Providers;
using AllCar.Identity;
using System.Net.Http;
using Rolf.WebApi.Mappers;

namespace Rolf.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddAllCarIdentity(options => options.UseIIS(_ => { }));

            services.AddHttpClient("withAppPoolCredentials")
                .ConfigurePrimaryHttpMessageHandler(p => new HttpClientHandler() { UseDefaultCredentials = true });

            services.AddMemoryCache();

            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    Converters = options.SerializerSettings.Converters,
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AllCar.WebApi", Version = "v1", Description = "Primary backend service for AllCar" });
            });

            services.AddDbContext<SqlEfContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PgSqlConnectionString"), b => b.MigrationsAssembly("AllCar.DataAccess"))
            .EnableSensitiveDataLogging());

            services.AddScoped<ILoggingProvider, TableLoggingProvider>();
            services.AddScoped<IUnitOfWork, SqlUnitOfWork>();

            services.AddHttpContextAccessor();

            services.AddCoreProviders();
            services.AddCoreServices();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(ViewMapperProfile));
                cfg.AddExpressionMapping();
                cfg.AddCollectionMappers();
                cfg.AllowNullCollections = true;
            });

            services.AddCors(options =>
            {

                options.AddPolicy("CorsFixPolicy",
                    builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(Configuration.GetSection("CorsOrigins").Get<string[]>())
                    .AllowCredentials()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsFixPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AllCar.WebApi v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseIdentityProcessing();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}