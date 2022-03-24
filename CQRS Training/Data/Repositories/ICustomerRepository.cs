using CQRS_Training.Data.Entities;
using CQRS_Training.Data.Infra.Entities;

namespace CQRS_Training.Data.Repositories;

public interface ICustomerRepository
{
    Task<CustomerDTO> InsertCustomer(string name, string email);
    Task<Customer> FindCustomer(int id);
    Task<List<Customer>> FindCustomers();
}