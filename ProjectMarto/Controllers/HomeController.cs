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
            CategoryRepository categoryRepository = new CategoryRepository();
            ProductRepository productRepository = new ProductRepository(); 
            IndexVM model = new IndexVM();

            model.Categories = categoryRepository.GetAll();
            model.SelectedCategory = selectedCategory;




            if (!string.IsNullOrEmpty(selectedCategory))
            {
                model.Products = productRepository
                                         .GetAll(x => x.Category.Name == selectedCategory);
                                        
            }
            else
            {
                model.Products = productRepository.GetAll();
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
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            UserRepository userRepository = new UserRepository();

            User newUser = new User();
            

            newUser.Username = model.Username; 
            newUser.Password=model.Password;

            userRepository.Save(newUser);

            

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

            UserRepository userRepo= new UserRepository();

            User loggedUser = userRepo.GetFirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

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
