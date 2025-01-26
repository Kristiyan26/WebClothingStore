using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectMarto.Models
{
    public class Category:BaseModel
    {
        

        [Required, MaxLength(100)]
        public string Name { get; set; }


        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
