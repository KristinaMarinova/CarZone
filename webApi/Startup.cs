using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CarZone.Middlewares;
using CarZone.Services;
using CarZone.Data;
using CarZone.Services.Interfaces;
using CarZone.Services.jwtAuth.Interfaces;
using CarZone.Services.jwtAuth.Services;
using CarZone.Services.jwtAuth.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CarZone.Services.jwtAuth.Helpers;
using System;
using CarZone.Data.Configurations;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CarZone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(
                Configuration.GetSection("DbConfiguration:CarZoneConnectionString").Value,
                Configuration.GetSection("DbConfiguration:LogConnectionString").Value
            );

            services.AddScoped<ICarService, CarService>();
            services.AddScoped(typeof(INomenclatureService<>), typeof(NomenclatureService<>));
            services.AddScoped(typeof(ICommentService), typeof(CommentService));
            services.AddScoped(typeof(ILikeService), typeof(LikeService));
            services.AddScoped<IPartService, PartsService>();
            services.AddScoped<UserContext>();
            services.AddScoped<IUserService, UserService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = TokenHelper.Issuer,
                            ValidAudience = TokenHelper.Audience,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero,
                            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(TokenHelper.Secret))
                        };

                    });
            services.AddAuthorization(options => options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build()
            );
            services.AddSingleton<IAuthorizationHandler, CustomerBlockedStatusHandler>();

            services.AddHttpContextAccessor();
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRequestSaver();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization();
            });

        }
    }
}