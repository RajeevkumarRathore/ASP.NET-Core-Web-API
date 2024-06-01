using Application.Abstraction.SignalR;
using Microsoft.AspNetCore.SignalR;
namespace Infrastructure.Implementation.Hub
{
    public class LogoutUsersHub : Hub<IHubClient>
    {
    }
}
