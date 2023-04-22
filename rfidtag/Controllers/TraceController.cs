using Microsoft.AspNetCore.Mvc;
using rfidtag.Data;
using rfidtag.Models;

namespace rfidtag.Controllers
{
    public class TraceController : Controller
    {
        public readonly rfidtagContext _context;
        public TraceController(rfidtagContext context)
        {
            _context = context;
        }
        public IActionResult Index(int Search)
        {
            var rfidNumber = _context.Supply.FirstOrDefault(x => x.RfidNo == Search);
            if(rfidNumber != null)
            {
                return RedirectToAction("Detail", new { id = rfidNumber.RfidNo });
            }

            return View();
        }
        public IActionResult Detail(int id)
        {
             Supply supply = _context.Supply.FirstOrDefault(x => x.RfidNo == id);
             return View(supply);
        
        }

       
    }
}
