using BlazorWizard.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWizard.Components;

public partial class AddressEntry : ComponentBase
{
    [Parameter] public EventCallback<AddressInfoResult> OnAddressInfoEntered { get; set; }
    [Parameter] public bool IsAddressValid { get; set; }
    private EditContext? _editContext;
    private AddressInfoInputModel _addressInfoInputModel = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_addressInfoInputModel);
        _editContext.OnFieldChanged += EditContextOnFieldChanged;
    }

    private void EditContextOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var isValid = _editContext != null && _editContext.Validate();
        OnAddressInfoEntered.InvokeAsync(new AddressInfoResult(_addressInfoInputModel.Street, _addressInfoInputModel.StreetNumber,
            _addressInfoInputModel.ZipCode, _addressInfoInputModel.City, _addressInfoInputModel.Province, _addressInfoInputModel.Country, isValid));
    }
}