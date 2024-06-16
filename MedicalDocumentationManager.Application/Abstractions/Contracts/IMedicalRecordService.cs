using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Application.Abstractions.Contracts;

public interface IMedicalRecordService
{
    Task<RespondMedicalRecordDto> CreateMedicalRecordAsync(RequestMedicalRecordDto medicalRecord, CancellationToken cancellationToken = default);

    Task<RespondMedicalRecordDto> UpdateMedicalRecordAsync(Guid id, RequestMedicalRecordDto medicalRecordDto,
        CancellationToken cancellationToken = default);
    Task DeleteMedicalRecordAsync(Guid id, CancellationToken cancellationToken = default);
    Task<RespondMedicalRecordDto?> GetMedicalRecordByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RespondMedicalRecordDto>> GetMedicalRecordsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RespondMedicalRecordDto>> GetMedicalRecordsByPatientAsync(Guid patientId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RespondMedicalRecordDto>> GetMedicalRecordsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default);
}