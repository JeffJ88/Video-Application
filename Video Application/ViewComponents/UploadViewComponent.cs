using Microsoft.AspNetCore.Mvc;

namespace Video_Application.ViewComponents
{
    public class UploadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
