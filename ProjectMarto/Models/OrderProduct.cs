using System.ComponentModel.DataAnnotations;

namespace ProjectMarto.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
