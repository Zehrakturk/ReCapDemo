using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstarct;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Business.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            /*builder.Services.AddSingleton<IBrandService, BrandManager>();
            builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
            builder.Services.AddSingleton<ICarService, CarManager>();
            builder.Services.AddSingleton<ICarDal, EfCarDal>();
            builder.Services.AddSingleton<IColorService, ColorManager>();
            builder.Services.AddSingleton<IColorDal, EfColorDal>();
            builder.Services.AddSingleton<ICustomerService, CustomerManager>();
            builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
            builder.Services.AddSingleton<IRentalService, RentalManager>();
            builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
            builder.Services.AddSingleton<IUserService, UserManager>();
            builder.Services.AddSingleton<IUserDal, EfUserDal>();*/
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
            ServiceTool.Create(builder.Services);


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>(builder =>
               {
                   builder.RegisterModule(new AutofacBusinessModule());
               });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

}