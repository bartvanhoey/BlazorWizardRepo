namespace BlazorWizard.Components;

public class UserInfoResult
{
    public UserInfoResult()
    {
    }

    public UserInfoResult(string? firstName, string? lastName, bool isValidResult)
    {
        FirstName = firstName;
        LastName = lastName;
        IsValidResult = isValidResult;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsValidResult { get; set; }
}