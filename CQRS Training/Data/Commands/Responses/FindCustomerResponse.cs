namespace CQRS_Training.Data.Commands.Responses;

public class FindCustomerResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
}