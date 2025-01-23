using System.ComponentModel.DataAnnotations;

namespace ProjectMarto.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int UserId { get; set; }
        public  User User { get; set; }

        [Required]
        public int ProductId { get; set; }
        public  Product Product { get; set; }

        [Required]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
