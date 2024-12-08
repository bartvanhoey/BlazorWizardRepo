namespace BlazorWizard.Components;

public class UserModel
{
    public User User { get; set; } = new();
    public Address Address { get; set; } = new();
    public Credentials Credentials { get; set; } = new();
}

public class Credentials
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}

public class Address
{
    public string? Street { get; set; }
    public string? StreetNumber { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Country { get; set; }
    
}

public class User
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}