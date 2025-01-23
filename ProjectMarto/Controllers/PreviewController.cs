using Microsoft.AspNetCore.Mvc;
using ProjectMarto.Models;
using ProjectMarto.Repositories;
using ProjectMarto.ViewModels.Preview;

namespace ProjectMarto.Controllers
{
    public class PreviewController : Controller
    {

        [HttpGet]
        public IActionResult Index(int id)
        {

            OnlineShopDbContext context = new OnlineShopDbContext(); 

            Product product = context.Products.FirstOrDefault(x=>x.ProductId==id);

            //SELECT FROM PROCUTS WHERE ID = 1;

            IndexVM model = new IndexVM();

            model.Product = product;
            model.Reviews = context.Reviews.Where(x => x.ProductId == product.ProductId).ToList(); 

       
            return View(model);
           
        }

    }
}
