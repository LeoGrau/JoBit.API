using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class CompanyProfileService : ICompanyProfileService
{
    private readonly ICompanyProfileRepository _companyProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyProfileService(IUnitOfWork unitOfWork, ICompanyProfileRepository companyProfileRepository)
    {
        _unitOfWork = unitOfWork;
        _companyProfileRepository = companyProfileRepository;
    }

    public async Task<IEnumerable<CompanyProfile>> ListAllAsync()
    {
        return await _companyProfileRepository.ListAllAsync();
    }

    public async Task<CompanyProfileResponse> FindByCompanyIdAsync(long companyId)
    {
        var existingCompanyProfile = await _companyProfileRepository.FindByCompanyIdAsync(companyId);
        if (existingCompanyProfile == null)
            return new CompanyProfileResponse("Company profile does not exist.");
        return new CompanyProfileResponse(existingCompanyProfile);
    }
}