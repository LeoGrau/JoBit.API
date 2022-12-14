using JoBit.API.Security.Domain.Models.Flags;

namespace JoBit.API.Security.Domain.Models.Bases;

public abstract class UserBase
{
    public long UserId { get; set; }
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? Email { get; set; }
    public String? Username { get; set; }
    public String? Password { get; set; }


    protected UserBase()
    {
        
    }

    protected UserBase(string? firstname, string? lastname, string? email, string? username, string? password)
    {
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Username = username;
        Password = password;
    }
}