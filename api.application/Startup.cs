using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api.crosscutting.DependenceInjection;
using api.crosscutting.Mappings;
using api.data.Context;
using api.data.Repository;
using api.domain.Interfaces;
using api.domain.Security;
using api.domain.Services;
using api.service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace api.application
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
            services.AddControllers();

            ConfigureService.ConfigureDependenceService(services);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfiguration"))
                .Configure(tokenConfiguration);
                services.AddSingleton(tokenConfiguration);

                var config = new AutoMapper.MapperConfiguration(options => {
                    options.AddProfile(new DtoModelProfiles());
                });

                IMapper mapper = config.CreateMapper();
                services.AddSingleton(mapper);


                services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>{
                    var paramsValidation = options.TokenValidationParameters;
                    paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                    paramsValidation.ValidAudience = tokenConfiguration.Audience;
                    paramsValidation.ValidIssuer = tokenConfiguration.Issuer;

                    paramsValidation.ValidateIssuerSigningKey = true;
                    paramsValidation.ValidateLifetime = true;
                    paramsValidation.ClockSkew = TimeSpan.Zero;
                });

                 services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

                  

            services.AddSwaggerGen( options => {
                options.SwaggerDoc("v1", new OpenApiInfo{
                                    Version="Versao 1",
                                    Description = "Modelagem/Arquitetura DDD",
                                    Contact = new OpenApiContact{
                                    Name = "Rodrigo Castilho", 
                                    Email = "rcastilho@gmail.com"
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                                                Description = "Entre com o token JWT", 
                                                Name = "Authorization",
                                                In = ParameterLocation.Header, 
                                                Type = SecuritySchemeType.ApiKey, 
                                                Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                    new OpenApiSecurityScheme{
                                            Reference = new OpenApiReference{
                                            Id = "Bearer", 
                                            Type = ReferenceType.SecurityScheme
                        }, 
                                            Scheme = "oauth2",
                                            Name = "Bearer",
                                            In = ParameterLocation.Header
                    }, 
                    new List<string>()
                    }
                    });
                    });

            
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "APi modelagem DDD"));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
