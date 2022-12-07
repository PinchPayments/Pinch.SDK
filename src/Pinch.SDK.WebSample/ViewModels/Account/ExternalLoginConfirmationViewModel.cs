using System.ComponentModel.DataAnnotations;

namespace Pinch.SDK.WebSample.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
