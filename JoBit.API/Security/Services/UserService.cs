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

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IApplicantRepository applicantRepository, IRecruiterRepository recruiterRepository, IApplicantProfileRepository applicantProfileRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _applicantRepository = applicantRepository;
        _recruiterRepository = recruiterRepository;
        _applicantProfileRepository = applicantProfileRepository;
    }

    public async Task<User> FindUserAsync(long userId)
    {
        var existingUser = await _userRepository.FindUserByIdAsync(userId);
        if (existingUser == null)
            throw new AppException("User does not exist.");
        return existingUser;
    }
    
}