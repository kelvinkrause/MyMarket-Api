using Microsoft.AspNetCore.Mvc;
using MyMarket.Application.Interfaces;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;

namespace MyMarket.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredProductJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RequestRegisterProductJson request,
            [FromServices] IRegisterProductUseCase useCase)
        {
                var response = await useCase.Execute(request);

                return Created(string.Empty, response);
        }
    }
}
