using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Models
{
    // Genre Model
    public class Genre
    {
        [Key]
        public Guid GenreId { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
