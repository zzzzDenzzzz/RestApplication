using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using RestApplication.Models;
using System.Text;

namespace RestApplication.Controllers
{
    [ApiController]
    [Route("")]
    public class PlusofonLogin : ControllerBase
    {
        [HttpPost("login")]
        public async Task<Response> LoginToPlusofon()
        {
            using HttpClient client = new();
            client.BaseAddress = new Uri("https://restapi.plusofon.ru/api/v1/login");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");

            HttpRequestMessage request = new(HttpMethod.Post, client.BaseAddress)
            {
                Content = new StringContent("""{"email":"dvaschenko33@gmail.com","password":"06660Dim"}""", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response>(responseBody)!;
        }

        [HttpGet("contact-list")]
        public async Task<ContactListResponse> GetContactList()
        {
            using HttpClient client = new();
            var result = await LoginToPlusofon();
            var token = result.Token;
            client.BaseAddress = new Uri("https://restapi.plusofon.ru/api/v1/contact-lists");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {token}");

            HttpRequestMessage request = new(HttpMethod.Get, client.BaseAddress)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ContactListResponse>(responseBody)!;
        }

        [HttpGet("contact-list/types")]
        public async Task<ResponseType> GetContactListTypes()
        {
            using HttpClient client = new();
            var result = await LoginToPlusofon();
            var token = result.Token;
            client.BaseAddress = new Uri("https://restapi.plusofon.ru/api/v1/contact-lists/types");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {token}");

            HttpRequestMessage request = new(HttpMethod.Get, client.BaseAddress)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseType>(responseBody)!;
        }

        [HttpGet("payment/balance")]
        public async Task<ResponseBalance> GetPaymentBalance()
        {
            using HttpClient client = new();
            var result = await LoginToPlusofon();
            var token = result.Token;
            client.BaseAddress = new Uri("https://restapi.plusofon.ru/api/v1/payment/balance");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {token}");

            HttpRequestMessage request = new(HttpMethod.Get, client.BaseAddress)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseBalance>(responseBody)!;
        }

        [HttpPost("flash-call/settings")]
        public async Task<ResponseSettings> SetSetting()
        {
            using HttpClient client = new();
            var result = await LoginToPlusofon();
            var token = result.Token;
            client.BaseAddress = new Uri("https://restapi.plusofon.ru/api/v1/flash-call/settings");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {token}");

            HttpRequestMessage request = new(HttpMethod.Post, client.BaseAddress)
            {
                Content = new StringContent("""{"calls_per_user_hour":1,"calls_per_user_day":9,"token_lifetime_sec":18,"pin_tries":15,"calls_per_hour":15,"calls_per_day":3,"return_operator":true}""", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseSettings>(responseBody)!;
        }

        [HttpGet("flash-call/settings")]
        public async Task<ResponseRoot> GetSetting()
        {
            using HttpClient client = new();
            var result = await LoginToPlusofon();
            var token = result.Token;
            client.BaseAddress = new Uri("https://restapi.plusofon.ru/api/v1/flash-call/settings");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("client", "10553");
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {token}");

            HttpRequestMessage request = new(HttpMethod.Get, client.BaseAddress)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseRoot>(responseBody)!;
        }
    }
}
