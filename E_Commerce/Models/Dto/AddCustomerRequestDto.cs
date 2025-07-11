namespace E_Commerce.Models.Dto
{
    public class AddCustomerRequestDto
    {
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}
