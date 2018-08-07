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
            Settings.IsPaypalLive = bool.Parse(Configuration["IsPaypalLive"]);
            Settings.PaypalUrl = Configuration["Live_PaypalUrl"];
            Settings.PaypalEmail = Configuration["Live_PaypalEmail"];
            Settings.PaypalAuthToken = Configuration["Live_PaypalAuthToken"];

            if (!Settings.IsPaypalLive) {
                Settings.PaypalUrl = Configuration["Sandbox_PaypalUrl"];
                Settings.PaypalEmail = Configuration["Sandbox_PaypalEmail"];
                Settings.PaypalAuthToken = Configuration["Sandbox_PaypalAuthToken"];
            }

            Settings.FromName = Configuration["FromName"];
            Settings.FromEmail = Configuration["FromEmail"];
            Settings.SendGridKey = Configuration["SendGridKey"];
            Settings.UiUrl = Configuration["UiUrl"];
        }
    }
}
