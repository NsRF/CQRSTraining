using CQRS_Training.Data.Commands.Requests;
using CQRS_Training.Data.Commands.Responses;

namespace CQRS_Training.Data.Handlers;

public interface ICreateCustomerHandler
{
   Task<CreateCustomerResponse> Handle(CreateCustomerRequest command);
}