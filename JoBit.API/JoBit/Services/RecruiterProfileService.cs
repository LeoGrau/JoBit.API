using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class RecruiterProfileService : IRecruiterProfileService
{
    private readonly IRecruiterProfileRepository _recruiterProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecruiterProfileService(IRecruiterProfileRepository recruiterProfileRepository, IUnitOfWork unitOfWork)
    {
        _recruiterProfileRepository = recruiterProfileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RecruiterProfile>> ListAllAsync()
    {
        return await _recruiterProfileRepository.ListAllAsync();
    }

    public async Task<RecruiterProfileResponse> FindByRecruiterId(long recruiterId)
    {
        var existingRecruiterProfile = await _recruiterProfileRepository.FindByRecruiterIdAsync(recruiterId);
        if (existingRecruiterProfile == null)
            return new RecruiterProfileResponse("Recruiter profile does not exist.");
        return new RecruiterProfileResponse(existingRecruiterProfile);
    }

    public Task<RecruiterProfileResponse> AddAsync(RecruiterProfile recruiterProfile)
    {
        throw new NotImplementedException();
    }

    public Task<RecruiterProfileResponse> UpdateAsync(long recruiterId, RecruiterProfile updatedRecruiterProfile)
    {
        throw new NotImplementedException();
    }

    public Task<RecruiterProfileResponse> RemoveAsync(long recruiterId)
    {
        throw new NotImplementedException();
    }
}