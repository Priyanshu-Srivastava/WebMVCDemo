﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using global::MyBookStoreApp.MyBookStoreApp.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBookStoreApp.MyBookStoreApp.Web.ViewModels
{

    public class AuthorViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        
    }
}
