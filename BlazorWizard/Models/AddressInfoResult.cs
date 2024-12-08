namespace BlazorWizard.Models;

public class AddressInfoResult(
    string? street,
    string? streetNumber,
    string? zipCode,
    string? city,
    string? province,
    string? country,
    bool isValidResult)
{
    public string? Street { get; } = street;
    public string? StreetNumber { get; } = streetNumber;
    public string? ZipCode { get; } = zipCode;
    public string? City { get; } = city;
    public string? Province { get; } = province;
    public string? Country { get; } = country;
    public bool IsValidResult { get; } = isValidResult;
}