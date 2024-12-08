using BlazorWizard.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorWizard.Pages;

public partial class Home : ComponentBase
{
    public UserModel UserModel { get; set; } = new();
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
        if (result.IsFinished)
        {
            Console.WriteLine("Wizard Finished");
            Console.WriteLine(UserModel.ToString());
        }
    }

}

