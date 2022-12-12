using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Models.Flags;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Exceptions;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IApplicantProfileRepository _applicantProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> FindUserAsync(long userId)
    {
        return await _userRepository.FindUserByIdAsync(userId);
    }

    public async Task RegisterUserAsync(User newUser)
    {
        try
        {
            await _userRepository.RegisterUserAsync(newUser);
            switch (newUser.UserType)
            {
                case UserType.Applicant:
                    Applicant newApplicant = new Applicant(newUser.UserId, newUser.Firstname, newUser.Lastname);
                    await _applicantRepository.AddAsync(newApplicant);
                    await _unitOfWork.CompleteAsync();
                    break;
                case UserType.Recruiter:
                    Recruiter newRecruiter = new Recruiter(newUser.UserId, newUser.Firstname, newUser.Lastname);
                    await _recruiterRepository.AddAsync(newRecruiter);
                    await _unitOfWork.CompleteAsync();
                    break;
            }
        }
        catch (Exception exception)
        {
            throw new AppException($"An error has occurred { exception.Message }");
        }
    }
}