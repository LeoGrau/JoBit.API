using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface ICompanyProfileRepository
{
    Task<IEnumerable<CompanyProfile>> ListAllAsync();
    Task<CompanyProfile> FindByCompanyIdAsync(long companyId);
    Task AddAsync(CompanyProfile newCompanyProfile);
}