using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoClientes.Api;
using Microsoft.AspNetCore;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Net;
using Xunit;

namespace ProjetoClientes.Test
{
    
    public class ClienteTest
    {
        private readonly HttpClient _client;

        public ClienteTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();

            
        }

        [Theory]
        [InlineData("GET")]
        public async Task ClienteGetAll(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/cliente");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
