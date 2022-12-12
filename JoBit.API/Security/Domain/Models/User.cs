using JoBit.API.Security.Domain.Models.Bases;
using JoBit.API.Security.Domain.Models.Flags;

namespace JoBit.API.Security.Domain.Models;

public class User : UserBase
{
    public String? Email { get; set; }
    public String? Username { get; set; }
    public String? Password { get; set; }
    public UserType UserType { get; set; }
    
    
    //Relations (Others send)
    //Must
    //Optionals
    

    //Relations (We Send)
    //Must
    //Optionals
    public Applicant? Applicant { get; set; }
    public Recruiter? Recruiter { get; set; }

    public User(long userId, string? firstname, string? lastname, string? email, string? username, string? password, UserType userType) : base(userId, firstname, lastname)
    {
        Email = email;
        Username = username;
        Password = password;
        UserType = userType;
    }
}