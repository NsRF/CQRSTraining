using CQRS_Training.Data.Commands.Requests;
using CQRS_Training.Data.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Training.Data.Controllers;

[Route("[controller]")]
public class CustomerController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create([FromServices]ICreateCustomerHandler handler, [FromBody]CreateCustomerRequest command)
    {
        var response = await handler.Handle(command);
        return Ok(response);
    }
}