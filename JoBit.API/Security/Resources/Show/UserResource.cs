using JoBit.API.Security.Domain.Models.Flags;
using JoBit.API.Security.Resources.Base;

namespace JoBit.API.Security.Resources.Show;

public class UserResource : UserBaseResource
{
    public long UserId { get; set; }
    public UserType UserType { get; set; }
}