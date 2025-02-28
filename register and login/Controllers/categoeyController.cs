using Microsoft.AspNetCore.Mvc;
using register_and_login.Models;

namespace register_and_login.Controllers
{
    public class categoeyController : Controller
    {

        readonly Mycontext yy;

        public categoeyController(Mycontext uu)
        {
            yy = uu;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult cat(category a)
        {
            if (ModelState.IsValid)
            {
                yy.category.Add(a);
                yy.SaveChanges();
                return RedirectToAction("list");
            }
            return View();
        }
        public IActionResult list()
        {
            var o=yy.category.ToList();
            return View(o);
        }
    }
}
