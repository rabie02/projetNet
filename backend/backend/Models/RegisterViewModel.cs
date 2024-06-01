using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public decimal? Telephone { get; set; }
    }

}