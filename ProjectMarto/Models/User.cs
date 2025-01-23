using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectMarto.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        // public virtual ICollection<Order> Orders { get; set; }


        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
