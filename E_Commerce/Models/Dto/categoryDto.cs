namespace E_Commerce.Models.Dto
{
    public class categoryDto
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
