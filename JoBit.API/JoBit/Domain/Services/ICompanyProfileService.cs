using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface ICompanyProfileService
{
    Task<IEnumerable<CompanyProfile>> ListAllAsync();
    Task<CompanyProfileResponse> FindByCompanyIdAsync(long companyId);
}