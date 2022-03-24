using CQRS_Training.Data.Commands.Requests;
using CQRS_Training.Data.Commands.Responses;
using CQRS_Training.Data.Repositories;

namespace CQRS_Training.Data.Handlers;

public class FindCustomerHandler : IFindCustomerHandler
{
    private ICustomerRepository _customerRepository;

    public FindCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<FindCustomerResponse> HandleOne(FindCustomerRequest command)
    {
        var customerFound = await _customerRepository.FindCustomer(command.Id);

        if (customerFound == null)
            return new FindCustomerResponse();

        return new FindCustomerResponse()
        {
            Id = customerFound.Id,
            Name = customerFound.Name,
            Date = customerFound.Date,
            Email = customerFound.Email
        };
    }
    
    public async Task<List<FindCustomerResponse>> HandleAll()
    {
        var customersFound = await _customerRepository.FindCustomers();

        return customersFound.Select(x => new FindCustomerResponse()
        {
            Date = x.Date,
            Name = x.Name,
            Email = x.Email,
            Id = x.Id,
        }).ToList();
    }
}