using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class CareerInstitutionService : ICareerInstitutionService
{
    private readonly ICareerInstitutionRepository _careerInstitutionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CareerInstitutionService(ICareerInstitutionRepository careerInstitutionRepository, IUnitOfWork unitOfWork)
    {
        _careerInstitutionRepository = careerInstitutionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CareerInstitution>> ListAllAsync()
    {
        return await _careerInstitutionRepository.ListAllAsync();
    }

    public async Task<IEnumerable<CareerInstitution>> ListByApplicantIdAsync(long applicantId)
    {
        return await _careerInstitutionRepository.ListByApplicantIdAsync(applicantId);
    }

    public async Task<CareerInstitutionResponse> FindByCareerInstitutionIdAsync(long careerInstitutionId)
    {
        var existingCareerInstitution = await _careerInstitutionRepository.FindByCareerInstitutionIdAsync(careerInstitutionId);
        if (existingCareerInstitution == null)
            return new CareerInstitutionResponse("CareerInstitution does not exist");
        return new CareerInstitutionResponse(existingCareerInstitution);
    }

    public async Task<CareerInstitutionResponse> AddAsync(CareerInstitution newCareerInstitution)
    {
        try
        {
            await _careerInstitutionRepository.AddAsync(newCareerInstitution);
            await _unitOfWork.CompleteAsync();
            return new CareerInstitutionResponse(newCareerInstitution);
        }
        catch (Exception exception)
        {
            return new CareerInstitutionResponse(exception.Message);
        }
    }

    public async Task<CareerInstitutionResponse> Update(long careerInstitutionId, CareerInstitution updatedCareerInstitution)
    {
        var existingCareerInstitution = await _careerInstitutionRepository.FindByCareerInstitutionIdAsync(careerInstitutionId);
        if (existingCareerInstitution == null)
            return new CareerInstitutionResponse("CareerInstitution does not exist");
        try
        {
            _careerInstitutionRepository.Update(updatedCareerInstitution);
            await _unitOfWork.CompleteAsync();
            return new CareerInstitutionResponse(updatedCareerInstitution);
        }
        catch (Exception exception)
        {
            return new CareerInstitutionResponse(exception.Message);
        }
    }

    public async Task<CareerInstitutionResponse> RemoveAsync(long careerInstitutionId)
    {
        var existingCareerInstitution = await _careerInstitutionRepository.FindByCareerInstitutionIdAsync(careerInstitutionId);
        if (existingCareerInstitution == null)
            return new CareerInstitutionResponse("CareerInstitution does not exist");
        try
        {
            _careerInstitutionRepository.Remove(existingCareerInstitution);
            await _unitOfWork.CompleteAsync();
            return new CareerInstitutionResponse(existingCareerInstitution);
        }
        catch (Exception exception)
        {
            return new CareerInstitutionResponse(exception.Message);
        }
    }
}