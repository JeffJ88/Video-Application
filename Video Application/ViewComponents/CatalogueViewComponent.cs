using Microsoft.AspNetCore.Mvc;

namespace Video_Application.ViewComponents
{
    public class CatalogueViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
