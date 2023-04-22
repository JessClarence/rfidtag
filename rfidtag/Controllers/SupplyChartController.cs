using Microsoft.AspNetCore.Mvc;

namespace rfidtag.Controllers
{
    public class SupplyChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
