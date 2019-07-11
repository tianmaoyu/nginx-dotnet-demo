using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace webapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var port = "5000";
            if (args.Any()&&args[0] == "-p")
            {
                var portStr = args[1];
                if (Regex.IsMatch(portStr, @"^\d*$"))
                {
                    port = portStr;
                }
            }
            CreateWebHostBuilder(args, port).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string port) =>
            WebHost.CreateDefaultBuilder(args)
                 .UseKestrel()
                 .UseUrls($"http://*:{port}")
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseStartup<Startup>();
    }
}
