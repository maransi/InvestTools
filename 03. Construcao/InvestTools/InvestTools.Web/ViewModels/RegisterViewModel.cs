using System.ComponentModel.DataAnnotations;

namespace investTools.Web.ViewModels;

public class RegisterViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirme a senha")]
    [Compare("Password", ErrorMessage = "As senhas não conferem")]
    public string ConfirmPassword { get; set; }
}
