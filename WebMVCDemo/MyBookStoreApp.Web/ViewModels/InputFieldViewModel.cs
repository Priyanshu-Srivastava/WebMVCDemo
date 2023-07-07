using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{
    public class InputFieldViewModel
    {
        public string Label { get; set; }
        public string  PropertyName { get; set; }
        public string Value { get; set; }
        public string ValidationMessage { get; set; }
    
       
    }
}
