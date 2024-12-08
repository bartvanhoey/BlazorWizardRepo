using System.ComponentModel.DataAnnotations;

namespace BlazorWizard.Models;

public class AddressInfoInputModel
{
    [Required] public string? Street { get; set; }
    [Required] public string? StreetNumber { get; set; }
    [Required] public string? ZipCode { get; set; }
    [Required] public string? City { get; set; }
    [Required] public string? Province { get; set; }
    [Required] public string? Country { get; set; }
}