namespace Web.Extensions
{
    public static class MappingExtensions
    {
        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            return new BasketViewModel()
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                BasketItems = basket.BasketItems.Select(bi => new BasketItemViewModel()
                {
                    Id = bi.Id,
                    ProductId = bi.ProductId,
                    ProductName = bi.Product.ProductName,
                    PictureUri = bi.Product.PictureUri ?? "no-image.png",
                    Quantity = bi.Quantity,
                    UnitPrice = bi.Product.ProductPrice
                }).ToList()
            };
        }
    }
}
