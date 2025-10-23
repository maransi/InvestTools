using System.ComponentModel.DataAnnotations;

namespace investTools.Web.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
