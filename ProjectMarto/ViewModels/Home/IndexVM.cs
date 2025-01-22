using ProjectMarto.Models;

namespace ProjectMarto.ViewModels.Home
{
    public class IndexVM
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public string? SelectedCategory { get; set; }  
    }
}
