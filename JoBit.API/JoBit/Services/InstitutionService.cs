using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class InstitutionService : IInstitutionService
{
    private readonly IEducationalInstitutionRepository _educationalInstitutionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InstitutionService(IEducationalInstitutionRepository educationalInstitutionRepository, IUnitOfWork unitOfWork)
    {
        _educationalInstitutionRepository = educationalInstitutionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Institution>> ListAllAsync()
    {
        return await _educationalInstitutionRepository.ListAllAsync();
    }

    public async Task<IEnumerable<Institution>> ListByContainingInstitutionName(string institutionName)
    {
        return await _educationalInstitutionRepository.ListByContainingInstitutionName(institutionName);
    }

    public async Task<EducationalInstitutionResponse> FindByInstitutionIdAsync(int institutionId)
    {
        var existingEducationalInstitution = await _educationalInstitutionRepository.FindByInstitutionIdAsync(institutionId);
        if (existingEducationalInstitution == null)
            return new EducationalInstitutionResponse("Educational Institution does not exist.");
        return new EducationalInstitutionResponse(existingEducationalInstitution);
    }
}