using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class ApplicantProfileService : IApplicantProfileService
{
    private readonly IApplicantProfileRepository _applicantProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantProfileService(IApplicantProfileRepository applicantProfileRepository, IUnitOfWork unitOfWork)
    {
        _applicantProfileRepository = applicantProfileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ApplicantProfile>> ListAllAsync()
    {
        return await _applicantProfileRepository.ListAllAsync();
    }

    public async Task<ApplicantProfileResponse> FindByApplicantId(long applicantId)
    {
        var existingApplicantProfile = await _applicantProfileRepository.FindByApplicantIdAsync(applicantId);
        if (existingApplicantProfile == null)
            return new ApplicantProfileResponse("Applicant does not exist");
        return new ApplicantProfileResponse(existingApplicantProfile);
    }

    public Task<ApplicantProfileResponse> AddAsync(ApplicantProfile applicantProfile)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ApplicantProfileResponse> UpdateAsync(long applicantId, ApplicantProfile updatedApplicantProfile)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicantProfileResponse> RemoveAsync(long applicantId)
    {
        throw new NotImplementedException();
    }
}