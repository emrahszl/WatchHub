namespace Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public string? PictureUri { get; set; }
    }
}
