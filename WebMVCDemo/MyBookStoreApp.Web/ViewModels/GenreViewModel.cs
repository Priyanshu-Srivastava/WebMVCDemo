using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{
    public class GenreViewModel
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<Book> Books { get; set; }

    }

}
