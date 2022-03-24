using CQRS_Training.Data.Commands.Requests;
using CQRS_Training.Data.Commands.Responses;
using CQRS_Training.Data.Infra.Entities;
using CQRS_Training.Data.Repositories;

namespace CQRS_Training.Data.Handlers;

public class CreateCustomerHandler : ICreateCustomerHandler
{
    private ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest command)
    {
        var customer = await _customerRepository.InsertCustomer(command.Name, command.Email);
        return new CreateCustomerResponse()
        {
            Id = customer.Id,
            Date = DateTime.Now,
            Email = customer.Email,
            Name = customer.Name,
        };
    }

}