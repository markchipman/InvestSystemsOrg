﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InvSys.Gamification.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DefaultHost();
            //ServiceFabricHost();
        }

        public static void DefaultHost()
        {
            var host = new WebHostBuilder()
                   .UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseIISIntegration()
                   .UseStartup<Startup>()
                   .UseUrls("http://localhost:5002")
                   .Build();

            host.Run();
        }

        public static void ServiceFabricHost()
        {
            ServiceRuntime.RegisterServiceAsync("InvSysCompaniesApiType", context => new WebHostingService(context, "ServiceEndpoint")).GetAwaiter().GetResult();
            Thread.Sleep(Timeout.Infinite);
        }
    }

    /// <summary>
    /// A specialized stateless service for hosting ASP.NET Core web apps.
    /// </summary>
    internal sealed class WebHostingService : StatelessService, ICommunicationListener
    {
        private readonly string _endpointName;

        private IWebHost _webHost;

        public WebHostingService(StatelessServiceContext serviceContext, string endpointName)
            : base(serviceContext)
        {
            _endpointName = endpointName;
        }

        #region StatelessService

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] { new ServiceInstanceListener(_ => this) };
        }

        #endregion StatelessService

        #region ICommunicationListener

        void ICommunicationListener.Abort()
        {
            _webHost?.Dispose();
        }

        Task ICommunicationListener.CloseAsync(CancellationToken cancellationToken)
        {
            _webHost?.Dispose();

            return Task.FromResult(true);
        }

        Task<string> ICommunicationListener.OpenAsync(CancellationToken cancellationToken)
        {
            var endpoint = FabricRuntime.GetActivationContext().GetEndpoint(_endpointName);

            string serverUrl = $"{endpoint.Protocol}://{FabricRuntime.GetNodeContext().IPAddressOrFQDN}:{endpoint.Port}";

            _webHost = new WebHostBuilder().UseKestrel()
                                           .UseContentRoot(Directory.GetCurrentDirectory())
                                           .UseStartup<Startup>()
                                           .UseUrls(serverUrl)
                                           .Build();

            _webHost.Start();

            return Task.FromResult(serverUrl);
        }

        #endregion ICommunicationListener
    }
}
