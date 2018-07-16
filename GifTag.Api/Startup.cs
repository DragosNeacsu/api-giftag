using GifTag.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace ApiGifTag
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GiftagDb")));
            services.AddCors();
            services.AddMvc().AddJsonOptions(opts =>
            {
                opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddDirectoryBrowser();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ITicketService, TicketService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.AllowAnyMethod().AllowAnyHeader()
                    .WithOrigins(
                    "http://localhost:4200",
                    "http://app.giftag.eu",
                    "https://app.giftag.eu",
                    "http://pre.giftag.eu",
                    "https://pre.giftag.eu",
                    "http://giftag.eu",
                    "https://giftag.eu")
            );

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines")),
                RequestPath = "/AirlineLogo"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets")),
                RequestPath = "/GeneratedTickets"
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets")),
                RequestPath = "/GeneratedTickets"
            });

            app.UseMvc();
        }
    }
}
