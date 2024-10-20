using FluentValidation;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pos.Core;
using Pos.Core.Mapper;
using Pos.Infrustructure;
using Pos.IRepository;
using Pos.Repository;
using Pos.Repository.IRepository;
using Pos.Repository.Repository;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.IoC.Configuration
{
   public static  class ConfigureationService
    {
       
        public static IConfiguration Configuration { get; }
        public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<PosDbContext>(options =>
			   options.UseSqlServer(configuration.GetConnectionString("Conn")
				   ));
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
            });


            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);


            //var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes("ThisIsASuperSecretKeyOfAtLeast32Charsrakibhasan@#$");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                };
                x.Events = new JwtBearerEvents();
                x.Events.OnMessageReceived = context =>
                {

                    if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                    {
                        context.Token = context.Request.Cookies["X-Access-Token"];
                    }

                    return Task.CompletedTask;
                };
            });
            services.AddAutoMapper(typeof(CommonMapper).Assembly);

     
            services.AddTransient<IAccountsHeadTypeRepository, AccountsHeadTypeRepository>();
            services.AddTransient<IAccountsHeadRepository, AccountsHeadRepository>();
            services.AddTransient<IAccountsTransactionRepository, AccountsTransactionRepository>();
            services.AddTransient<IAccountsReportReposity, AccountsReportReposity>();
            services.AddTransient<IAccountsReportSettingRepository, AccountsReportSettingRepository>();

            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            // services.Scan(s => s.FromAssemblyOf<IApplication>().AddClasses(c => c.AssignableTo<IApplication>()).AsSelfWithInterfaces().WithTransientLifetime());

            services.AddValidatorsFromAssembly(typeof(ICore).Assembly);

            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));

            //services.AddMediatR(cfg =>
            //{
            //	cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);

            //});



            return services;
		}
	}
}
