using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        public string BookGenre { get; set; }
        public SelectList Authors { get;set; }
        public SelectList Genres { get;set; }
    }

}
