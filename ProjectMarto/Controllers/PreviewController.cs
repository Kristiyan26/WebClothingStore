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

            ProductRepository repo = new ProductRepository();
            ReviewRepository reviewRepo = new ReviewRepository();

            Product product = repo.GetFirstOrDefault(x=>x.Id==id);

            //SELECT FROM PROCUTS WHERE ID = 1;

            IndexVM model = new IndexVM();

            model.Product = product;
            model.Reviews = reviewRepo.GetAll(x => x.ProductId == product.Id).ToList(); 

       
            return View(model);
           
        }

    }
}
