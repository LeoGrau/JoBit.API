using System.ComponentModel.DataAnnotations;

namespace JoBit.API.Security.Domain.Services.Communication.Requests;

public class RecruiterRegisterRequest : BaseRegisterRequest
{
    [Required] public long CompanyId { get; set; }
}