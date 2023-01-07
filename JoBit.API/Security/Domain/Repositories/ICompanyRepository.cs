using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Repositories;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> ListAllAsync();
    Task<Company> FindByCompanyIdAsync(long applicantId);
    Task AddAsync(Company newApplicant);
    void Update(Company updatedApplicant);
    void Remove(Company toDeleteApplicant);
}