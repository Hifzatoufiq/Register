using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using register_and_login.Models;

namespace register_and_login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly Mycontext hh;
        public HomeController(ILogger<HomeController> logger, Mycontext dd)
        {
            _logger = logger;
          hh= dd;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register us)
        {
            if (ModelState.IsValid)
            {
                var obj=new Register();
                obj.email= us.email;
                obj.name= us.name;
                obj.password= us.password;
                obj.Role = "user";
                hh.register.Add(obj);
                hh.SaveChanges();
                return RedirectToAction("Index");
               
            }
            return View(us);
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(login u)
        {
            var obj = hh.register.FirstOrDefault(x=>x.email == u.email && x.password == u.password);
            if (obj != null)
            {
                if (obj.Role == "user")
                {
                    return RedirectToAction("Index");   
                }
                else
                {
                    if (obj.Role == "admin")
                    {
                        return RedirectToAction("dashboard");
                    }
                }
            }
            return View();
        }

        public IActionResult dashboard()
        {
            return View();
        }

        public IActionResult create()
        {
            var tt=hh.category.ToList();
            ViewBag.categories=tt;
            return View();
        }
        [HttpPost]
        public IActionResult create(product ff)
        {
            if (ModelState.IsValid)
            {
                hh.Add(ff);
                hh.SaveChanges();
                return RedirectToAction("list");
            }
            return View();
        }
        public IActionResult list()
        {
            var dd=hh.product1.ToList();
            return View(dd);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
