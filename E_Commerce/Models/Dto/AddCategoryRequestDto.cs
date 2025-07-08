namespace E_Commerce.Models.Dto
{
    public class AddCategoryRequestDto
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
