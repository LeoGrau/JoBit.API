using JoBit.API.JoBit.Domain.Models.Composite;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Models.Intermediate;
using JoBit.API.Shared.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using Org.BouncyCastle.Tls;

namespace JoBit.API.JoBit.Services;

public class PostJobRecruiterService : IPostJobRecruiterService
{
    private readonly IPostJobRecruiterRepository _postJobRecruiterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostJobRecruiterService(IPostJobRecruiterRepository postJobRecruiterRepository, IUnitOfWork unitOfWork)
    {
        _postJobRecruiterRepository = postJobRecruiterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PostJobRecruiter>> ListAllAsync()
    {
        return await _postJobRecruiterRepository.ListAllAsync();
    }

    public async Task<PostJobRecruiterResponse> FindByPostJobIdAndRecruiterId(PostJobRecruiterPk postJobRecruiterPk)
    {
        var existingPostJobRecruiter = await _postJobRecruiterRepository.FindByPostJobIdAndRecruiterIdAsync(postJobRecruiterPk);
        if (existingPostJobRecruiter == null)
            return new PostJobRecruiterResponse("Post Job Recruiter does not exist");
        return new PostJobRecruiterResponse(existingPostJobRecruiter);
    }

    public async Task<PostJobRecruiterResponse> AddAsync(PostJobRecruiter newPostJobRecruiter)
    {
        try
        {
            await _postJobRecruiterRepository.AddAsync(newPostJobRecruiter);
            await _unitOfWork.CompleteAsync();
            return new PostJobRecruiterResponse(newPostJobRecruiter);
        }
        catch (Exception exception)
        {
            return new PostJobRecruiterResponse(exception.Message);
        }
    }

    public async Task<PostJobRecruiterResponse> Update(PostJobRecruiterPk postJobRecruiterPk, PostJobRecruiter updatedPostJobRecruiter)
    {
        throw new TlsNoCloseNotifyException();
    }

    public async Task<PostJobRecruiterResponse> RemoveAsync(PostJobRecruiterPk postJobRecruiterPk)
    {
        var existingPostJobRecruiter = await _postJobRecruiterRepository.FindByPostJobIdAndRecruiterIdAsync(postJobRecruiterPk);
        if (existingPostJobRecruiter == null)
            return new PostJobRecruiterResponse("Post Job Recruiter does not exist");
        try
        {
            _postJobRecruiterRepository.Remove(existingPostJobRecruiter);
            await _unitOfWork.CompleteAsync();
            return new PostJobRecruiterResponse(existingPostJobRecruiter);
        }
        catch (Exception exception)
        {
            return new PostJobRecruiterResponse(exception.Message);
        }
    }
}