using MedicalCardsApp.Web.Models;

namespace MedicalCardsApp.Web.Repositories;

public interface IMedicalRecordRepository
{
    Task<IEnumerable<MedicalRecord>> GetAllAsync();
    Task<MedicalRecord?> GetByIdAsync(int id);
    Task AddAsync(MedicalRecord record);
    Task UpdateAsync(MedicalRecord record);
    Task DeleteAsync(int id);
    Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
    Task SaveChangesAsync();
}