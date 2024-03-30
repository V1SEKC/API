using System;
using System.Net.Http;

namespace WpfApp1.Infrastructure
{
    public class ApiConnection
    {
        public HttpClient HttpClient { get; private set; }
        public string RefreshToken { get; set; }
        public static ApiConnection GetApiConnection { get; private set; } = new ApiConnection();
        
        private ApiConnection()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://localhost:7041");
        }
    }
}
