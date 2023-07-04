using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Reflection;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Models
{
    // User Model
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
