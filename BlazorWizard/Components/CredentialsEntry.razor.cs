using BlazorWizard.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWizard.Components;

public partial class CredentialsEntry : ComponentBase
{
    [Parameter] public EventCallback<CredentialsInfoResult> OnCredentialsEntered { get; set; }
    [Parameter] public bool IsCredentialsEntryValid { get; set; }
    private EditContext? _editContext;
    private CredentialsInputModel _credentialsInputModel = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_credentialsInputModel);
        _editContext.OnFieldChanged += EditContextOnOnFieldChanged;
    }

    private void EditContextOnOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var isValid = _editContext != null && _editContext.Validate();
        OnCredentialsEntered.InvokeAsync(new CredentialsInfoResult(_credentialsInputModel.Username,
            _credentialsInputModel.Password, isValid));
    }
}