using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Store.ViewModels.Common;
using Store.ViewModels.Configuration;

namespace Store.Services.Utilities
{
    public static class UrlUtilities
    {
        public static string GetBaseUrl(HttpContext context, bool isHttps = false)
        {
            var request = context.Request;
            var host = request.Host.ToUriComponent();
            var pathBase = request.PathBase.ToUriComponent();

            return isHttps ? $"https://{host}{pathBase}" : $"http://{host}{pathBase}";
        }
    }
}