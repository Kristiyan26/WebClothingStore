using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectMarto.ExtentionMethods;
using ProjectMarto.Models;
using ProjectMarto.Repositories;
using ProjectMarto.ViewModels.Home;

namespace ProjectMarto.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [HttpPost]
        public IActionResult Index(string? selectedCategory)
        {
            OnlineShopDbContext context = new OnlineShopDbContext();

            IndexVM model = new IndexVM();

            model.Categories = context.Categories.ToList();
            model.SelectedCategory = selectedCategory;




            if (!string.IsNullOrEmpty(selectedCategory))
            {
                model.Products = context.Products
                                         .Where(x => x.Category.Name == selectedCategory)
                                         .ToList();
            }
            else
            {
                model.Products = context.Products.ToList();
            }

            return View(model);

        }

        [HttpGet]

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public IActionResult SignUp(SignUpVM model)
        {
            //TODO : Find a way to check in the database if a User with the given Username
            //is already existing. If it is send an error message to the view that says
            //'Username is taken'

            OnlineShopDbContext context=new OnlineShopDbContext();

            User newUser = new User();
            

            newUser.Username = model.Username; 
            newUser.Password=model.Password;

            context.Users.Add(newUser);

            context.SaveChanges();

            

            this.HttpContext.Session.SetObject<User>("loggedUser", newUser);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            OnlineShopDbContext context = new OnlineShopDbContext();

            User loggedUser = context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (loggedUser == null)
            {
                return View(model);
            }
            else
            {
                this.HttpContext.Session.SetObject<User>("loggedUser", loggedUser);
                return RedirectToAction("Index", "Home");
            }

        }


        [HttpGet]
        public IActionResult Logout()
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");

            if (loggedUser != null)
            {
                this.HttpContext.Session.SetObject<User>("loggedUser", null);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
