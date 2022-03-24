using CQRS_Training.Data.Entities;
using CQRS_Training.Data.Infra.Contexts;
using CQRS_Training.Data.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Training.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CqrsContext _ctx;

    public CustomerRepository(CqrsContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<CustomerDTO> InsertCustomer(string name, string email)
    {
        var customer = new Customer()
        {
            Name = name,
            Email = email,
            Date = DateTime.Now.ToUniversalTime()
        };
        try
        {
            await _ctx.Customers.AddAsync(customer);
            await _ctx.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new CustomerDTO
        {
            Id = customer.Id,
            Email = customer.Email,
            Name = customer.Name
        };
    }
    
    public async Task<List<Customer>> FindCustomers()
    {
        return await _ctx.Customers.ToListAsync();
    }

    public async Task<Customer> FindCustomer(int id)
    {
        return await _ctx.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }
}