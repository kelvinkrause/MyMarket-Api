using Microsoft.AspNetCore.Mvc;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;

namespace MyMarket.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisteredProductJson request)
        {
            var response = new ResponseRegisteredProductJson
            {
                Name = string.Empty
            };

            return Created(string.Empty, response);
        }
    }
}
