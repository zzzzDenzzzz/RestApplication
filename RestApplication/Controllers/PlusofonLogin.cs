using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace RestApplication.Controllers
{
    [ApiController]
    [Route("")]
    public class PlusofonLogin : ControllerBase
    {
        [HttpPost]
        public async Task<string> LoginToPlusofon()
        {
            HttpClient client = new();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");

            HttpRequestMessage request = new(HttpMethod.Post, "https://restapi.plusofon.ru/api/v1/login")
            {
                Content = new StringContent("""{"email":"dvaschenko33@gmail.com","password":"06660Dim"}""", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
