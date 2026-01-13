using Microsoft.AspNetCore.Mvc;
using MyMarket.Application.UseCase.Product.Register;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;

namespace MyMarket.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RequestRegisteredProductJson request)
        {

            var useCase = new RegisterProductUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
