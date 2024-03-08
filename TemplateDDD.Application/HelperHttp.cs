using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace TemplateDDD.Application
{
    public static class HelperHttp
    {
        public static string? Token { get; set; }
        public static HttpClient GerarHttpClient(IHttpClientFactory httpClientFactory)
        {
            HttpClient client = httpClientFactory.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return client;
        }
    }
}

