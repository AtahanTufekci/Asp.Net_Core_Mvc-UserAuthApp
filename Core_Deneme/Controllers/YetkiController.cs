using Microsoft.AspNetCore.Mvc;

namespace Core_Deneme.Controllers
{
    public class YetkiController : Controller
    {
        public IActionResult Yetkisiz()
        {
            return View();
        }
    }
}
