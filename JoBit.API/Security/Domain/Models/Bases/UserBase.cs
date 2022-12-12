using JoBit.API.Security.Domain.Models.Flags;

namespace JoBit.API.Security.Domain.Models.Bases;

public abstract class UserBase
{
    public long UserId { get; set; }
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }

    protected UserBase(long userId, string? firstname, string? lastname)
    {
        UserId = userId;
        Firstname = firstname;
        Lastname = lastname;
    }
}