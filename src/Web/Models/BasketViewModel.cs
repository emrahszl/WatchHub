namespace Web.Models
{
    public class BasketViewModel
    {
        public int Id { get; set; }

        public string BuyerId { get; set; } = null!;

        public List<BasketItemViewModel> BasketItems { get; set; } = new();

        public int TotalItems => BasketItems.Sum(bi => bi.Quantity);

        public decimal TotalPrice => BasketItems.Sum(bi => bi.TotalPrice);
    }
}
