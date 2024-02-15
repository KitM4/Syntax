using System.ComponentModel.DataAnnotations;

namespace Syntax.WebApp.ViewModels.User;

public class EditUserViewModel
{
    [Required(ErrorMessage = "UserName is required.")]
    public string UserName { get; set; } = string.Empty;

    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }
}