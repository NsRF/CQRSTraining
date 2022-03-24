using CQRS_Training.Data.Entities;

namespace CQRS_Training.Data.Repositories;

public interface ICustomerRepository
{
    Task<CustomerDTO> InsertCustomer(string name, string email);
}