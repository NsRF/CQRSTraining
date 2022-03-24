using CQRS_Training.Data.Commands.Requests;
using CQRS_Training.Data.Commands.Responses;

namespace CQRS_Training.Data.Handlers;

public interface IFindCustomerHandler
{
    Task<FindCustomerResponse> HandleOne(FindCustomerRequest command);
    Task<List<FindCustomerResponse>> HandleAll();
}