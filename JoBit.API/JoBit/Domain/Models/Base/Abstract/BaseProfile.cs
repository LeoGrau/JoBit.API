namespace JoBit.API.JoBit.Domain.Models.Base;

public abstract class BaseProfile
{
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? PhotoUrl { get; set; }
    public String? Description { get; set; }
    public String? Profession { get; set; }

    public BaseProfile()
    {
    }

    public BaseProfile(string? firstname, string? lastname, string? photoUrl, string? description, string? profession)
    {
        Firstname = firstname;
        Lastname = lastname;
        PhotoUrl = photoUrl;
        Description = description;
        Profession = profession;
    }
}