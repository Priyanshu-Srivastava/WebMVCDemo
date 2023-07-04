using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Models
{
    // Book Model
    public class Book
    {
        [Key]
        public Guid BookId { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
