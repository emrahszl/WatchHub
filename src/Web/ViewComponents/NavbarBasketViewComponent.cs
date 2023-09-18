using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class NavbarBasketViewComponent : ViewComponent
    {
        //todo: yarın IBasketViewModelService üzerinden BasketViewModel türünde sepeti buraya getireceğiz ve öğelerinin sayısını View'a aktaracağız. O View'da navbarın sağ üstüne view component ile yerleştirilecek.
        public NavbarBasketViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
