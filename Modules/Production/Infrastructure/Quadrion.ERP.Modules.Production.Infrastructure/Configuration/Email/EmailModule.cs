using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Quadrion.ERP.BuildingBlocks.Application.Emails;
using Quadrion.ERP.BuildingBlocks.Infrastructure.Emails;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Email
{
    internal class EmailModule : Module
    {
        private readonly EmailsConfiguration _configuration;

        public EmailModule(EmailsConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSender>()
                .As<IEmailSender>()
                .WithParameter("configuration", _configuration)
                .InstancePerLifetimeScope();
        }
    }
}
