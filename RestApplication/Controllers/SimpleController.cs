using Microsoft.AspNetCore.Mvc;

namespace RestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet(Name = "GetString")]
        public JsonResult GetString()
        {
            return new JsonResult("this is string request");
        }

        [HttpPost(Name = "PostMap")]
        public async Task<string> PrintMapAsync(int postId)
        {
            HttpClient client = new();
            if (postId > 0)
            {
                return await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts" + "/" + postId);
            }
            else
            {
                return await client.GetStringAsync("not");
            }
        }
    }
}
