using System.ComponentModel.DataAnnotations;

namespace BlazorWizard.Models;

public class CredentialsInputModel
{
    [Required] [EmailAddress] public string? Username { get; set; }

    [Required] [MinLength(6)] public string? Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }
}