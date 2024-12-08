using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWizard.Components;

public partial class AddressEntry : ComponentBase
{
    [Parameter] public EventCallback<AddressInfoResult> OnAddressInfoEntered { get; set; }
    [Parameter] public bool IsAddressValid { get; set; }
    private EditContext? _editContext;
    private AddressInputModel _addressInputModel = new AddressInputModel();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_addressInputModel);
        _editContext.OnFieldChanged += EditContextOnFieldChanged;
    }

    private void EditContextOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var isValid = _editContext != null && _editContext.Validate();
        OnAddressInfoEntered.InvokeAsync(new AddressInfoResult(_addressInputModel.Street, _addressInputModel.StreetNumber,
            _addressInputModel.ZipCode, _addressInputModel.City, _addressInputModel.Province, _addressInputModel.Country, isValid));
    }


    public class AddressInputModel
    {
        [Required] public string? Street { get; set; }
        [Required] public string? StreetNumber { get; set; }
        [Required] public string? ZipCode { get; set; }
        [Required] public string? City { get; set; }
        [Required] public string? Province { get; set; }
        [Required] public string? Country { get; set; }
    }
}

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