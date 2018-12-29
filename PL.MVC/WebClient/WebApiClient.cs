using System;
using System.Configuration;
using System.Net.Http;

namespace PL.MVC.WebClient
{
    public class WebApiClient
    {
        private static readonly Lazy<HttpClient> LazyClient =
            new Lazy<HttpClient>(() => new HttpClient()
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"])
            });
        public static HttpClient Instance => LazyClient.Value;

        private WebApiClient()
        {

        }
    }
}