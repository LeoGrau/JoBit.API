using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Models.Flags;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Exceptions;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.Security.Services;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IRecruiterProfileRepository _recruiterProfileRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecruiterService(IUserRepository userRepository, IUnitOfWork unitOfWork, IRecruiterRepository recruiterRepository, IRecruiterProfileRepository recruiterProfileRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _recruiterRepository = recruiterRepository;
        _recruiterProfileRepository = recruiterProfileRepository;
    }

    public async Task<Recruiter?> FindByRecruiterIdAsync(long recruiterId)
    {
        var existingRecruiter = await _recruiterRepository.FindByRecruiterIdAsync(recruiterId);
        if (existingRecruiter != null)
            return existingRecruiter;
        return null;
    }

    public async Task AddAsync(Recruiter newRecruiter)
    {
        try
        {
            //Adding new user
            var newUser = new User(newRecruiter.Firstname, newRecruiter.Lastname, newRecruiter.Email,
                newRecruiter.Username, newRecruiter.Password, UserType.Recruiter);
            await _userRepository.RegisterUserAsync(newUser);
            await _unitOfWork.CompleteAsync();

            //Adding new recruiter
            newRecruiter.UserId = newUser.UserId;
            await _recruiterRepository.AddAsync(newRecruiter);
            await _unitOfWork.CompleteAsync();
            
            //Adding new recruiter profile
            var newRecruiterProfile = new RecruiterProfile(newRecruiter.Firstname, newRecruiter.Lastname, "", "", "", newRecruiter.RecruiterId);
            await _recruiterProfileRepository.AddAsync(newRecruiterProfile);
            await _unitOfWork.CompleteAsync();

        }
        catch (Exception exception)
        {
            throw new AppException($"An error has occurred: {exception.Message}");
        }
    }
}