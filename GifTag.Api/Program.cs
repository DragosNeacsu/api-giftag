using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiGifTag
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            BuildAppSettings();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static void BuildAppSettings()
        {
            Settings.PaypalUrl = Configuration["PaypalUrl"];
            Settings.PaypalEmail = Configuration["PaypalEmail"];
            Settings.PaypalAuthToken = Configuration["PaypalAuthToken"];
            Settings.FromName = Configuration["FromName"];
            Settings.FromEmail = Configuration["FromEmail"];
            Settings.SendGridKey = Configuration["SendGridKey"];
            Settings.UiUrl = Configuration["UiUrl"];
        }
    }
}
