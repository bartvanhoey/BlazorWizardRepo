using System.ComponentModel.DataAnnotations;

namespace BlazorWizard.Models;

public class UserInfoInputModel
{
    [Required] public string? FirstName { get; set; }
    [Required] public string? LastName { get; set; }
}