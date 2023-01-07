using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Services;

public interface ICompanyService
{
    public Task<Company> FindByCompanyIdAsync(long companyId);
    public Task AddAsync(Company newCompany);
    public Task RemoveAsync(Company toDeleteCompany);
}