using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Application.Abstractions.Contracts;

public interface IDoctorService
{
    Task<RespondDoctorDto> CreateDoctorAsync(RequestDoctorDto doctor, CancellationToken cancellationToken = default);

    Task<RespondDoctorDto> UpdateDoctorAsync(Guid id, RequestDoctorDto doctor,
        CancellationToken cancellationToken = default);
    Task DeleteDoctorAsync(Guid id, CancellationToken cancellationToken = default);
    Task<RespondDoctorDto?> GetDoctorByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<RespondDoctorDto?> GetDoctorWithAddressByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RespondDoctorDto>> GetDoctorsAsync(CancellationToken cancellationToken = default);
}