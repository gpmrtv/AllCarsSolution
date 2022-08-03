using AllCar.WebApi.Mappers;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AllCar.Core.DI;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.DataAccess.Units;
using AllCar.DataAccess.Context;
using AllCar.DataAccess.Logging.Providers;
using AllCar.Shared.Dto;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities;
using AllCar.Shared.Entities.References;
using AllCar.WebApi.Services.Domain;
using AllCar.Core.Common;
using AllCar.Redis.Providers;
using AllCar.DataAccess.Logging.Providers.Concrete;

namespace AllCar.WebApi
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
            services.AddMemoryCache();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AllCar.WebApi", Version = "v1" });
            });

            services.AddDbContext<ReferencesContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PgSqlConnectionString"), b => b.MigrationsAssembly("AllCar.DataAccess"))
                                                          .EnableSensitiveDataLogging());

            services.AddScoped<ILoggingProvider, ReferencesLoggingProvider>();
            services.AddScoped<IUnitOfWork, ReferencesUnitOfWork>();

            services.AddHttpContextAccessor();

            services.AddScoped<IBaseCrudService<CarEntity, CarDto>, CoreCrudService<CarEntity, CarDto>>();
            services.AddScoped<IBaseCrudService<ColorEntity, ColorDto>, CoreCrudService<ColorEntity, ColorDto>>();
            services.AddScoped<IBaseCrudService<BodyEntity, BodyDto>, BodiesService>();
            services.AddScoped<IBaseCrudService<EquipmentVariantEntity, EquipmentVariantDto>, CoreCrudService<EquipmentVariantEntity, EquipmentVariantDto>>();
            services.AddScoped<IBaseCrudService<GearboxEntity, GearboxDto>, CoreCrudService<GearboxEntity, GearboxDto>>();
            services.AddScoped<IBaseCrudService<GearEntity, GearDto>, CoreCrudService<GearEntity, GearDto>>();
            services.AddScoped<IBaseCrudService<GenerationEntity, GenerationDto>, CoreCrudService<GenerationEntity, GenerationDto>>();
            services.AddScoped<IBaseCrudService<MakeEntity, MakeDto>, CoreCrudService<MakeEntity, MakeDto>>();
            services.AddScoped<IBaseCrudService<ModelEntity, ModelDto>, CoreCrudService<ModelEntity, ModelDto>>();
            services.AddScoped<IBaseCrudService<AreaEntity, AreaDto>, CoreCrudService<AreaEntity, AreaDto>>();

            services.AddScoped<ICachingProvider, AllCar.Redis.Providers.CachingProvider>(x => new CachingProvider("localhost:6379"));

            services.AddCoreProviders();
            services.AddCoreServices();

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


            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(ViewMapperProfile));
                cfg.AddExpressionMapping();
                cfg.AddCollectionMappers();
                cfg.AllowNullCollections = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsFixPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AllCar.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
