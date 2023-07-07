using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{
    public class AlertViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
