using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Quadrion.ERP.BuildingBlocks.Application.Data;
using Dapper;
using Quadrion.ERP.Modules.UserAccess.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.UserAccess.Application.Emails
{
    internal class GetAllEmailsQueryHandler : IQueryHandler<GetAllEmailsQuery, List<EmailDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllEmailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<EmailDto>> Handle(GetAllEmailsQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QueryAsync<EmailDto>(
                "SELECT " +
                $"[Email].[Id] AS [{nameof(EmailDto.Id)}], " +
                $"[Email].[From] AS [{nameof(EmailDto.From)}], " +
                $"[Email].[To] AS [{nameof(EmailDto.To)}], " +
                $"[Email].[Subject] AS [{nameof(EmailDto.Subject)}], " +
                $"[Email].[Content] AS [{nameof(EmailDto.Content)}], " +
                $"[Email].[Date] AS [{nameof(EmailDto.Date)}] " +
                "FROM [app].[Emails] AS [Email] " +
                "ORDER BY [Email].[Date] DESC")).AsList();
        }
    }
}