namespace BlazorWizard.Components;

public class UserEntryResult
{
    public UserEntryResult()
    {
    }

    public UserEntryResult(string? firstName, string? lastName, bool isValidResult)
    {
        FirstName = firstName;
        LastName = lastName;
        IsValidResult = isValidResult;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsValidResult { get; set; }
}