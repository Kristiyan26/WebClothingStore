using System.ComponentModel.DataAnnotations;

namespace ProjectMarto.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
