using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsSeller { get; set; }
    }
}
