using System.ComponentModel.DataAnnotations;

namespace JoBit.API.Security.Domain.Services.Communication.Requests;

public class BaseRegisterRequest
{
    [Required] public String? Firstname { get; set; }
    [Required] public String? Lastname { get; set; }
    [Required] public String? Username { get; set; }
    [Required] public String? Email { get; set; }
    [Required] public String? Password { get; set; }
}