using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Professional.Coding.Farm.WebUI.ExceptionsManagement;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Shouldly;

namespace WebUI.Test
{
    [TestClass]
    public class ExceptionManagement
    {
        [TestMethod]
        public async Task ThrowException()
        {
            string exceptionMessage = "Ooops an exception has occurred...";

            var builder = new WebHostBuilder()
                                .UseUrls("http://localhost:8345")
                                .ConfigureServices(s => { })
                                .Configure(app =>
                                {
                                    app.UseExceptionManagement();
                                    app.Run(context => throw new Exception(exceptionMessage));
                                });

            TestServer server = new TestServer(builder);
            HttpClient client = server.CreateClient();

            var response = await client.GetAsync("http://localhost:8345/");

            string responseAsString = await response.Content.ReadAsStringAsync();

            responseAsString.ShouldContain(exceptionMessage);
        }
    }
}
