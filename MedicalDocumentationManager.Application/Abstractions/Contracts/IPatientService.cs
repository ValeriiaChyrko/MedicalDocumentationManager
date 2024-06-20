using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Application.Abstractions.Contracts;

public interface IPatientService
{
    Task<RespondPatientDto> CreatePatientAsync(RequestPatientDto patient, CancellationToken cancellationToken = default);

    Task<RespondPatientDto> UpdatePatientAsync(Guid id, RequestPatientDto patient,
        CancellationToken cancellationToken = default);
    Task DeletePatientAsync(Guid id, CancellationToken cancellationToken = default);
    Task<RespondPatientDto?> GetPatientByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<RespondPatientDto?> GetPatientWithAddressByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RespondPatientDto>> GetPatientsAsync(CancellationToken cancellationToken = default);
}