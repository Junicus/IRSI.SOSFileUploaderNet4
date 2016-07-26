using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using IRSI.SOSFileUploaderNet4.ApiClients;
using IRSI.SOSFileUploaderNet4.Services;

namespace IRSI.SOSFileUploaderNet4.Modules
{
    public class SOSUploadModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileHistoryService>().As<IFileHistoryService>();
            builder.RegisterType<SOSLineParserService>().As<ISOSLineParserService>();
            builder.RegisterType<SOSFileParserService>().As<ISOSFileParserService>();
            builder.RegisterType<TokenClient>().AsSelf();
            builder.RegisterType<SOSApiClient>().AsSelf();
            builder.RegisterType<SOSFileUploader>().AsSelf();
        }
    }
}
