using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Exceptions;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.Security.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyProfileRepository _companyProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, ICompanyProfileRepository companyProfileRepository)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _companyProfileRepository = companyProfileRepository;
    }

    public async Task<Company> FindByCompanyIdAsync(long companyId)
    {
        var existingCompany = await _companyRepository.FindByCompanyIdAsync(companyId);
        if (existingCompany != null)
            return existingCompany;
        return null;
    }

    public async Task AddAsync(Company newCompany)
    {
        try
        {
            //Adding new company
            await _companyRepository.AddAsync(newCompany);
            await _unitOfWork.CompleteAsync();
            
            //Adding new company profile
            var newApplicantProfile = new CompanyProfile(newCompany.CompanyId, newCompany.CompanyName);
            await _companyProfileRepository.AddAsync(newApplicantProfile);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception exception)
        {
            throw new AppException($"An error has occurred: {exception.Message}");
        }
    }

    public async Task RemoveAsync(Company toDeleteCompany)
    {
        throw new AppException();
    }
}