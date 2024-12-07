namespace BlazorWizard.Components;

public class CredentialEntryResult(string? credentialsUsername, string? credentialsPassword, bool isValidResult)
{
    public string? CredentialsUsername { get; } = credentialsUsername;
    public string? CredentialsPassword { get; } = credentialsPassword;
    public bool IsValidResult { get; } = isValidResult;
}