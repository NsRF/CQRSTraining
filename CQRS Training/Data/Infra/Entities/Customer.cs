namespace CQRS_Training.Data.Infra.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
