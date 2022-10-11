using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;

namespace TBC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicApiController : ControllerBase
    {
        [HttpGet(Name = "publicApi")]

        public async Task<IActionResult> PablicApi()
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage response = await client.GetAsync("https://www.boredapi.com/api/activity/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return Ok(responseBody);
        }
    }
}
