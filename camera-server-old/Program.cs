#define DefaultBuilder
// Define any of the following for the scenarios described in the Kestrel topic:
// DefaultBuilder Limits TCPSocket UnixSocket FileDescriptor Port0 SyncIO
// The following require an X.509 certificate:
// TCPSocket UnixSocket FileDescriptor Limits

using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace coeusCapture
{
    /// <summary>
    /// Executing the "dotnet run" command in the application folder will run this app.
    /// </summary>
    public class Program
    {
        // The default listening address is http://localhost:5000 if none is specified.


        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                
                
                .UseUrls("http://*:5000");

    }
}


