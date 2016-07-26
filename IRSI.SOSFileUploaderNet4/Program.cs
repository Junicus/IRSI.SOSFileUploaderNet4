using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IRSI.SOSFileUploaderNet4.Configuration;
using Serilog;

namespace IRSI.SOSFileUploaderNet4
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetEntryAssembly();
            var builder = new ContainerBuilder();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .WriteTo.RollingFile(Properties.Settings.Default.SOSFileUploader_LogPath + "/Log-{Date}.txt")
                .CreateLogger();

            ILogger log = Log.ForContext<Program>();
            log.Information("Registering Components and Modules...");

            builder.Register<SOSApiClientOptions>(c => new SOSApiClientOptions()
            {
                ApiUrl = Properties.Settings.Default.SOSApi_ApiUrl,
                ClientId = Properties.Settings.Default.SOSApi_ClientId,
                ClientSecret = Properties.Settings.Default.SOSApi_ClientSecret
            });

            builder.Register<TokenClientOptions>(t => new TokenClientOptions()
            {
                TokenUrl = Properties.Settings.Default.IdentityServer_TokenEndpointUrl
            });

            builder.Register<SOSFileUploaderOptions>(s => new SOSFileUploaderOptions()
            {
                StoreId = Guid.Parse(Properties.Settings.Default.SOSFileUploader_StoreId),
                QsrSOSPath = Properties.Settings.Default.SOSFileUploader_QsrSOSPath
            });

            builder.Register<FileHistoryServiceOptions>(s => new FileHistoryServiceOptions()
            {
                HistoryFilePath = Properties.Settings.Default.SOSFileUploader_HistoryPath
            });

            builder.RegisterAssemblyModules(assembly);
            var container = builder.Build();

            try
            {
                log.Information("Resolving SOSFileUploader...");
                var sosFileUploader = container.Resolve<SOSFileUploader>();
                log.Information("SOSFileUploader resolved");
                log.Information("Running SOSFileUploader...");
                Task.WaitAll(sosFileUploader.RunAsync());
                log.Information("SOSFileUploader Finished running successfully");
            }
            catch(Exception ex)
            {
                log.Error(ex, "Error resolving or running SOSFileUploader");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
