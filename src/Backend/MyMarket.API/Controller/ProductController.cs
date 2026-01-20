using Microsoft.AspNetCore.Mvc;
using MyMarket.Application.UseCase.Product.Register;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;
using MyMarket.Exceptions.Exceptions;

namespace MyMarket.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredProductJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterAsync([FromBody] RequestRegisteredProductJson request)
        {
            try
            {
                var useCase = new RegisterProductUseCase();

                var response = await useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationException ex)
            {
                return BadRequest(new ResponseErrorJson(ex.MessageErrors));
            }
            
        }
    }
}
