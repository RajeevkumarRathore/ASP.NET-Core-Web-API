using MediatR;
using Microsoft.Extensions.Configuration;


namespace Application.Handler.User.Queries.HostedEnvironment
{
    public class HostedEnvironmentQueryHandler : IRequestHandler<HostedEnvironmentQuery, string>
    {
        private readonly IConfiguration _configuration;
        public HostedEnvironmentQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;       
        }
        public async Task<string> Handle(HostedEnvironmentQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_configuration["Agencies"]);
        }
    }
}
