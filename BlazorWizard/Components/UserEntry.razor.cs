using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWizard.Components;

public partial class UserEntry : ComponentBase
{
    [Parameter] public EventCallback<UserEntryResult> OnUserEntryEntered { get; set; }
    [Parameter] public bool IsUserEntryValid { get; set; }
    private EditContext? _editContext;
    private UserInfo _user = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_user);
        _editContext.OnFieldChanged += EditContextOnOnFieldChanged;
    }

    private void EditContextOnOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var isValid = _editContext != null && _editContext.Validate();
        OnUserEntryEntered.InvokeAsync(new UserEntryResult(_user.FirstName, _user.LastName, isValid));
    }

    private class UserInfo
    {
        [Required] public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
    }
}