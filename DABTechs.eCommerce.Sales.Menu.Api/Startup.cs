using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DABTechs.eCommerce.Sales.Providers.Menu;

namespace DABTechs.eCommerce.Sales.Menu.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly string CorsClient = "_corsclient";

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Load settings from json file and deserialise into classes
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true, reloadOnChange: true)
               .Build();

            // TODO Place holder for jwt bear auth.
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.Authority = config["AppSettings:Authority"];
            //        options.Audience = SecurityResources.MenuApiResource;
            //        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            //        //options.TokenValidationParameters = new TokenValidationParameters
            //        //{
            //        //    ValidateIssuer = true,
            //        //    ValidateAudience = true,
            //        //    ValidateLifetime = true,
            //        //    ValidateIssuerSigningKey = true,
            //        //    ValidIssuer = config["AppSettings:Issuer"],
            //        //    ValidAudience = config["AppSettings:Audience"],
            //        //    IssuerSigningKey = JwtSecurityKey.Create(SecurityScopes.VipApiSecret)
            //        //};
            //    });

            // TODO better way to be had
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsClient,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                    }
                    );
            });

            services.AddControllers();

            services.AddSwaggerGen(swagger => {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "DAB Techs Menu Api" });
            });
            services.AddSwaggerGenNewtonsoftSupport();

            // TODO this is to get the Mega Nav xml file need to remove in new solution
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));

            services.AddScoped<IMenu, Providers.Menu.Menu>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(CorsClient);
            app.UseStaticFiles();

            

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.DocumentTitle = "Menu Api";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DAB Techs Menu Api");
                c.InjectJavascript("/swagger_custom.js");
            });

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
