namespace JoBit.API.Security.Domain.Services.Communication.Requests;

public class CompanyRegisterRequest
{
    public String? CompanyName { get; set; }
    public String? AdminMail { get; set; }
    public String? Password { get; set; }
}