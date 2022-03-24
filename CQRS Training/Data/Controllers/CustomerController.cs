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
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> FindOne([FromServices]IFindCustomerHandler handler, int Id)
    {
        var response = await handler.HandleOne(new FindCustomerRequest(){Id = Id});
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> FindOne([FromServices]IFindCustomerHandler handler)
    {
        var response = await handler.HandleAll();
        return Ok(response);
    }
}