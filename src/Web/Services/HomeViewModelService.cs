using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Brand> _brandRepo;

        public HomeViewModelService(IRepository<Product> productRepo, IRepository<Category> categoryRepo, IRepository<Brand> brandRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId)
        {
            var specProducts = new ProductFilterSpecification(categoryId, brandId);
            var products = await _productRepo.GetAllAsync(specProducts);

            var vm = new HomeViewModel()
            {
                Products = products.Select(pr =>
                new ProductViewModel()
                {
                    Id = pr.Id,
                    ProductName = pr.ProductName,
                    ProductPrice = pr.ProductPrice,
                    PictureUri = pr.PictureUri
                }).ToList(),

                Categories = (await _categoryRepo.GetAllAsync()).Select(cr =>
                    new SelectListItem(cr.CategoryName, cr.Id.ToString())).ToList(),
                Brands = (await _brandRepo.GetAllAsync()).Select(br =>
                    new SelectListItem(br.BrandName, br.Id.ToString())).ToList(),
                CategoryId = categoryId,
                BrandId = brandId
            };

            return vm;
        }
    }
}
