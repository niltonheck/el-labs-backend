using CWebService.CrossCutting.DependencyInjector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CWebService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SimpleInjector.Lifestyles;
using System;
using CWebService.Infrastructure.Contexts;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.SwaggerGen;
using CWebService.Application.ABC;

namespace CWebService.Application.ABC {
    public class UpdateFileDownloadOperations : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.OperationId == "DownloadFile_Get")
            {
                // operation. = new[] { "application/octet-stream" };
            }
        }
    }
}

namespace CWebService.Api
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();

        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CWebService.Api", Version = "v1" });
                c.OperationFilter<UpdateFileDownloadOperations>();
            });

            services.AddDbContextPool<ApplicationContext>(options => getDefaultOptions(options));
            services.AddDbContextPool<BrandContext>(options => getDefaultOptions(options));
            services.AddDbContextPool<ModelContext>(options => getDefaultOptions(options));
            services.AddDbContextPool<VehicleContext>(options => getDefaultOptions(options));
            services.AddDbContextPool<BookingContext>(options => getDefaultOptions(options));

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();
            });

            container = new Composer(container).Build();

            services.AddAuthentication(option =>
            {	
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {

                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("0dabbad70b774266a599b10fc1a98911")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                    {
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Name = "JWT Authentication",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Description = "Put your JWT Bearer below!",

                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    };

                    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });

                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CWebService.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private DbContextOptionsBuilder getDefaultOptions (DbContextOptionsBuilder options) {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            return options;
        }
    }
}
