using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Models.Flags;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Exceptions;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.Security.Services;

public class ApplicantService : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IApplicantProfileRepository _applicantProfileRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantService(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IApplicantProfileRepository applicantProfileRepository)
    {
        _applicantRepository = applicantRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _applicantProfileRepository = applicantProfileRepository;
    }

    public async Task<Applicant?> FindByApplicantIdAsync(long applicantId)
    {
        var existingApplicant = await _applicantRepository.FindByApplicantIdAsync(applicantId);
        if (existingApplicant != null)
            return existingApplicant;
        return null;
    }

    public async Task AddAsync(Applicant newApplicant)
    {
        try
        {
            //Adding new user
            var newUser = new User(newApplicant.Firstname, newApplicant.Lastname, newApplicant.Email,
                newApplicant.Username, newApplicant.Password, UserType.Applicant);
            await _userRepository.RegisterUserAsync(newUser);
            await _unitOfWork.CompleteAsync();

            //Adding new applicant
            newApplicant.UserId = newUser.UserId;
            await _applicantRepository.AddAsync(newApplicant);
            await _unitOfWork.CompleteAsync();
            
            //Adding new applicant profile
            var newApplicantProfile = new ApplicantProfile(newApplicant.Firstname, newApplicant.Lastname, "", "", newApplicant.ApplicantId);
            await _applicantProfileRepository.AddAsync(newApplicantProfile);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception exception)
        {
            throw new AppException($"An error has occurred: {exception.Message}");
        }
    }
}