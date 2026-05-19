using MedicalCardsApp.Web.Models;

namespace MedicalCardsApp.Web.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task<Appointment?> GetByIdAsync(int id);
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
    Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId);
   
}