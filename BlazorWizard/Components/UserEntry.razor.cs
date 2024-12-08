using BlazorWizard.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWizard.Components;

public partial class UserEntry : ComponentBase
{
    [Parameter] public EventCallback<UserInfoResult> OnUserInfoEntered { get; set; }
    [Parameter] public bool IsUserEntryValid { get; set; }
    private EditContext? _editContext;
    private UserInfoInputModel _userInfoInputModel = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_userInfoInputModel);
        _editContext.OnFieldChanged += EditContextOnFieldChanged;
    }

    private void EditContextOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var isValid = _editContext != null && _editContext.Validate();
        OnUserInfoEntered.InvokeAsync(new UserInfoResult(_userInfoInputModel.FirstName, _userInfoInputModel.LastName, isValid));
    }
}