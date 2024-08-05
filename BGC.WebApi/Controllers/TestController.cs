using Microsoft.AspNetCore.Mvc;

namespace BGC.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            await Task.Delay(1);
            return "";
        }
    }
}
