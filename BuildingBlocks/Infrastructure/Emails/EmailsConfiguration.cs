﻿namespace Quadrion.ERP.BuildingBlocks.Infrastructure.Emails
{
    public class EmailsConfiguration
    {
        public EmailsConfiguration(string fromEmail)
        {
            FromEmail = fromEmail;
        }

        public string FromEmail { get; }
    }
}