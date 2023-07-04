using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Models
{
    // Author Model
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; } = Guid.NewGuid();

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
