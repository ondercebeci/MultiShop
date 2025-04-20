using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponets
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
