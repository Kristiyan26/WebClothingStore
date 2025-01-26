using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMarto.ActionFilters;
using ProjectMarto.ExtentionMethods;
using ProjectMarto.Models;
using ProjectMarto.Repositories;
using ProjectMarto.ViewModels.Orders;

namespace ProjectMarto.Controllers
{
    [AuthenticationFilter]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            OrderRepository repo=new OrderRepository();

            IndexVM model = new IndexVM();
            User user = this.HttpContext.Session.GetObject<User>("loggedUser");

     
            model.Orders = repo.GetAll(x => x.UserId == user.Id);
            return View(model);
        }
    }
}
