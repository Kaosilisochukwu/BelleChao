using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelleChao.Web.Utilities
{
    public class Request
    {
        private readonly string _baseUrl;

        public Request(HttpContextAccessor contextAccessor)
        {
            _baseUrl = contextAccessor.HttpContext.Request.Host.ToUriComponent();
        }
        public async Task<HttpResponseMessage> PostForm(string destination, object model)
        {
            var url = $"http://{_baseUrl}{destination}";
            var client = new HttpClient();
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Post;
            message.RequestUri = new Uri(url);
            var jsonData = JsonSerializer.Serialize(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            message.Content = content;
            var response = await client.SendAsync(message);
            return response;
        }

        public async Task<HttpResponseMessage> GetMethod(string destination)
        {
            var url = $"http://{_baseUrl}{destination}";
            var client = new HttpClient();
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri(url);
            var response = await client.SendAsync(message);
            return response;
        }
    }
}
