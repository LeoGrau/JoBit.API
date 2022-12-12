using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class RecruiterProfileService : IRecruiterProfileService
{
    private readonly IRecruiterRepository _applicantProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecruiterProfileService(IRecruiterRepository applicantProfileRepository, IUnitOfWork unitOfWork)
    {
        _applicantProfileRepository = applicantProfileRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<RecruiterProfile>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RecruiterProfileResponse> FindByApplicantId(long recruiterId)
    {
        throw new NotImplementedException();
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