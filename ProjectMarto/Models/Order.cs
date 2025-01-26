using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectMarto.Models
{
    public class Order : BaseModel
    {
        

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } 

        [Required]
        public decimal TotalPrice { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
