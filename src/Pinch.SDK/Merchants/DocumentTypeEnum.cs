using System.ComponentModel.DataAnnotations;

namespace Pinch.SDK.Merchants
{
    public enum DocumentType
    {
        [Display(Name = "identity-document")] IdentityDocument = 1,
        [Display(Name = "additional-verification")] AdditionalVerification = 2,
        [Display(Name = "financial-document")] FinancialDocument = 3,
        [Display(Name = "business-registration")] BusinessRegistration = 4
    }
}