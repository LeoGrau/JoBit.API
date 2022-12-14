using JoBit.API.Security.Domain.Models.Bases;
using JoBit.API.Security.Domain.Models.Flags;

namespace JoBit.API.Security.Domain.Models;

public class User : UserBase
{
    //Relations (We Send)
    //Must
    //Optionals
    public Applicant? Applicant { get; set; }
    public Recruiter? Recruiter { get; set; }
    public UserType UserType { get; set; }

    public User()
    {
    }

    public User(string? firstname, string? lastname, string? email, string? username, string? password, UserType userType) : base(firstname, lastname, email, username, password)
    {
        UserType = userType;
    }
}