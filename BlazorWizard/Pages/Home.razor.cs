using BlazorWizard.Components;
using BlazorWizard.Components.Wizard;
using BlazorWizard.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWizard.Pages;

public partial class Home : ComponentBase
{
    private UserModel UserModel { get; } = new();
    public bool ShowNextButton { get; set; }

    private void UserInfoEntered(UserInfoResult result)
    {
        ShowNextButton = result.IsValidResult;
        UserModel.User.FirstName = result.FirstName;
        UserModel.User.LastName = result.LastName;
    }

    private void CredentialsEntered(CredentialsInfoResult result)
    {
        ShowNextButton = result.IsValidResult;
        UserModel.Credentials.Username = result.CredentialsUsername;
        UserModel.Credentials.Password = result.CredentialsPassword;
    }

    private void AddressInfoEntered(AddressInfoResult result)
    {
        ShowNextButton = result.IsValidResult;
        UserModel.Address.Street = result.Street;
        UserModel.Address.StreetNumber = result.StreetNumber;
        UserModel.Address.ZipCode = result.ZipCode;
        UserModel.Address.City = result.City;
        UserModel.Address.Province = result.Province;
        UserModel.Address.Country = result.Country;
    }

    private void WizardFinished(WizardFinishedResult result)
    {
        if (result.IsNotFinished) return;
        Console.WriteLine("Wizard Finished");
        Console.WriteLine(UserModel.ToString());
    }
    
    
    private void CarFromDatabaseLoaded(CarFromDatabaseLoadedResult result)
    {
        ShowNextButton = result.IsValidResult;
    }

    
}

