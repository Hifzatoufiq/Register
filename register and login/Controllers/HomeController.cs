using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using register_and_login.Models;

namespace register_and_login.Controllers
{
    public class HomeController : Controller
    {
        
        readonly Mycontext hh;
        private readonly string _uploadsFolderPath;
        public HomeController(IWebHostEnvironment env, Mycontext dd)
        {
            _uploadsFolderPath = Path.Combine(env.WebRootPath, "images");
            hh = dd;
        }

        public IActionResult Index()
        {

            var f = hh.product1.ToList();
            return View(f);
           
        }

        public IActionResult Privacy()
        {
            var f = hh.product1.ToList();
            return View(f);
           
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productvm model)
        {
            if (ModelState.IsValid)
            {
                if (model.image != null && model.image.Length > 0)
                {
                    // Create the uploads folder if it doesn't exist
                    if (!Directory.Exists(_uploadsFolderPath))
                    {
                        Directory.CreateDirectory(_uploadsFolderPath);
                    }

                    // Generate a unique filename
                    var fileName = Path.GetFileName(model.image.FileName);
                    var filePath = Path.Combine(_uploadsFolderPath, fileName);

                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.image.CopyToAsync(stream);
                    }

                    // Create and save the product
                    var product = new product
                    {
                        price = model.price,
                        name = model.name,
                        description = model.description,
                        imagepath = fileName,
                        CategoryId = model.CategoryId
                    };

                    hh.product1.Add(product);
                    await hh.SaveChangesAsync();

                    TempData["Message"] = "File uploaded successfully!";
                    return RedirectToAction(nameof(Privacy));
                }
                else
                {
                    ModelState.AddModelError("", "No file selected!");
                }
            }

            // If model state is invalid, redisplay the form with validation errors
            return View(model);
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
