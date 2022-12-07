using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Pinch.SDK.WebSample.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IEnumerable<AuthenticationScheme> AuthenticationSchemes { get; set; } = new List<AuthenticationScheme>();
    }
}
