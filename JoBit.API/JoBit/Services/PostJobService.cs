using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class PostJobService : IPostJobService
{
    private readonly IPostJobRepository _postJobRepository;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostJobService(IPostJobRepository postJobRepository, IUnitOfWork unitOfWork, IRecruiterRepository recruiterRepository)
    {
        _postJobRepository = postJobRepository;
        _recruiterRepository = recruiterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PostJob>> ListAllAsync()
    {
        var postJobs = await _postJobRepository.ListAllAsync();
        postJobs.ToList().ForEach(postJob =>
        {
            postJob.PostJobRecruiters.ToList().ForEach(postJobRecruiter =>
            {
                postJobRecruiter.Recruiter = _recruiterRepository.FindByRecruiterIdAsync(postJobRecruiter.RecruiterId).Result;
            });
        });
        return await _postJobRepository.ListAllAsync();
    }

    public async Task<IEnumerable<PostJob>> ListAllByContainingJobName(string jobName)
    {
        return await _postJobRepository.ListAllByContainingJobName(jobName);
    }

    public async Task<PostJobResponse> FindByPostJobIdAsync(long postJobId)
    {
        var existingPostJob = await _postJobRepository.FindByPostJobIdAsync(postJobId);
        if (existingPostJob == null)
            return new PostJobResponse("Post Job does not exist.");
        
        //Get Inside Objects
        
        return new PostJobResponse(existingPostJob);
    }

    public async Task<PostJobResponse> AddAsync(PostJob newPostJob)
    {
        try
        {
            await _postJobRepository.AddAsync(newPostJob);
            await _unitOfWork.CompleteAsync();
            return new PostJobResponse(newPostJob);
        }
        catch (Exception e)
        {
            return new PostJobResponse(e.Message);
        }
    }

    public async Task<PostJobResponse> RemoveAsync(long postJobId)
    {
        var existingPostJob = await _postJobRepository.FindByPostJobIdAsync(postJobId);
        if (existingPostJob == null)
            return new PostJobResponse("Post Job does not exist.");
        try
        {
            _postJobRepository.Remove(existingPostJob);
            await _unitOfWork.CompleteAsync();
            return new PostJobResponse(existingPostJob);
        }
        catch (Exception e)
        {
            return new PostJobResponse(e.Message);
        }
    }

    public async Task<PostJobResponse> UpdateAsync(long postJobId, PostJob updatedPostJob)
    {
        var existingPostJob = await _postJobRepository.FindByPostJobIdAsync(postJobId);
        if (existingPostJob == null)
            return new PostJobResponse("Applicant Tech Skill does not exist.");
        
        existingPostJob.SetPostJob(updatedPostJob);
        
        try
        {
            _postJobRepository.Remove(existingPostJob);
            await _unitOfWork.CompleteAsync();
            return new PostJobResponse(existingPostJob);
        }
        catch (Exception e)
        {
            return new PostJobResponse(e.Message);
        }
    }

}