using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class CareerService : ICareerService
{
    private readonly ICareerRepository _careerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CareerService(ICareerRepository careerRepository, IUnitOfWork unitOfWork)
    {
        _careerRepository = careerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Career>> ListAllAsync()
    {
        return await _careerRepository.ListAllAsync();
    }

    public async Task<IEnumerable<Career>> ListByContainingCareerName(string careerName)
    {
        return await _careerRepository.ListByContainingCareerName(careerName);
    }

    public async Task<CareerResponse> FindByCareerIdAsync(int careerId)
    {
        var existingCareer = await _careerRepository.FindByCareerIdAsync(careerId);
        if (existingCareer == null)
            return new CareerResponse("Career does not exist.");
        return new CareerResponse(existingCareer);
    }
}