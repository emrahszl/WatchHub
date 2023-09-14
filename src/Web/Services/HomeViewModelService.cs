namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepo;

        public HomeViewModelService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var vm = new HomeViewModel()
            {
                Products = (await _productRepo.GetAllAsync()).Select(pr =>
                new ProductViewModel()
                {
                    Id = pr.Id,
                    ProductName = pr.ProductName,
                    ProductPrice = pr.ProductPrice,
                    PictureUri = pr.PictureUri
                }).ToList()
            };

            return vm;
        }
    }
}
