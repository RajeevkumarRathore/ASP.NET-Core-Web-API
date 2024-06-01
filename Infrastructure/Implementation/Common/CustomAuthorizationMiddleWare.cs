using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Implementation.Common
{
    public class CustomAuthorizationMiddleWare
    {
        public static string GetClientIPAddress(HttpContext context)
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
            {
                ip = context.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                ip = context.Request.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
