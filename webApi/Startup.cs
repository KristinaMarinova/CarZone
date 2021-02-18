using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebCarsProject.Middlewares;
using WebCarsProject.Services;
using WebCarsProject.Data;
using WebCarsProject.Services.Interfaces;
using WebCarsProject.Services.jwtAuth.Interfaces;
using WebCarsProject.Services.jwtAuth.Services;
using WebCarsProject.Services.jwtAuth.Requirements;
using WebCarsProject.Services.jwtAuth.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebCarsProject.Services.jwtAuth.Helpers;
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace WebCarsProject
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
            services.AddDbContext<AppDbContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICarService, CarService>();
            services.AddScoped(typeof(INomenclatureService<>), typeof(NomenclatureService<>));
            services.AddScoped(typeof(ICommentService), typeof(CommentService));
            services.AddScoped(typeof(ILikeService), typeof(LikeService));
            services.AddScoped<IHisoryDescriptionService, HisoryDescriptionService>();


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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestSaver();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization();
            });

        }
    }
}