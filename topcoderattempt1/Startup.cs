using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using topcoderattempt1.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CustomPolicyProvider;
using topcoderattempt1.Controllers;
using topcoderattempt1.Backend.Authorization.ResourceBased;

namespace topcoderattempt1
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
            services.AddSingleton<IAuthorizationPolicyProvider, LoginRequiredPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, LoggedInAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, AdminPermissionsHandler>();

            services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("CommanderConnection")));
            services.AddDbContext<MercuryContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("MercuryConnection")));

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddScoped<IUserRepo, SqlUserRepo>();
            services.AddScoped<ILocationRepo, LocationsSqlRepo>();

            services.AddScoped<ICommanderRepo, SqlCommanderRepo>(); // depency to be injected to any thing 

            // authentication stuff
            // this verifies WHO the person is 
            var KeyBytes = Encoding.UTF8.GetBytes(Constants.SecretKey);

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = "JwtBearer";
                config.DefaultChallengeScheme = "JwtBearer";
            })
                .AddJwtBearer("JwtBearer", jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
                        ValidateIssuer = true,
                        ValidIssuer = Constants.Issuer,
                        ValidateAudience = true,
                        ValidAudience = Constants.Audiance,
                        ValidateLifetime = false,
                        ClockSkew = TimeSpan.FromMinutes(3),
                    };
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            //who are u 
            app.UseAuthentication();

            // are u allowed
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
