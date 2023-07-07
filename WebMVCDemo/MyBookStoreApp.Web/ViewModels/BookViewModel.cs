using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{
    public class BookViewModel
    {
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

    }

}
