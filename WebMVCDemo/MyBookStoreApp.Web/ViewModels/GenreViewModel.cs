using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{
    public class GenreViewModel
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //Going to use these to display alerts
        public string AlertMessage { get; set; } = String.Empty;
        public string AlertClass { get; set; } = String.Empty;

    }

}
