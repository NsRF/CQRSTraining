namespace CQRS_Training.Data.Commands.Requests;

public class CreateCustomerRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}