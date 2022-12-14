using Autofac;
using Quadrion.ERP.BuildingBlocks.Application.Emails;
using Quadrion.ERP.BuildingBlocks.Infrastructure.Emails;

namespace Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Email
{
    internal class EmailModule : Module
    {
        private readonly IEmailSender _emailSender;
        private readonly EmailsConfiguration _configuration;

        public EmailModule(
            EmailsConfiguration configuration,
            IEmailSender emailSender)
        {
            _configuration = configuration;
            _emailSender = emailSender;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_emailSender != null)
            {
                builder.RegisterInstance(_emailSender);
            }
            else
            {
                builder.RegisterType<EmailSender>()
                    .As<IEmailSender>()
                    .WithParameter("configuration", _configuration)
                    .InstancePerLifetimeScope();
            }
        }
    }
}