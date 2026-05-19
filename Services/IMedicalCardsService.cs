using MedicalCardsApp.Web.Models;
using Microsoft.AspNetCore.Components;

namespace MedicalCardsApp.Web.Services;

/// <summary>
/// Интерфейс сервиса для работы с медицинскими картами.
/// </summary>
public interface IMedicalCardsService
{
    // Пациенты
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
    Task<Patient?> GetPatientByIdAsync(int id);
    Task CreatePatientAsync(Patient patient);
    Task UpdatePatientAsync(Patient patient);
    Task DeletePatientAsync(int id);

    // Врачи
    Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
    Task CreateDoctorAsync(Doctor doctor);
    Task DeleteDoctorAsync(int id);

    // Медицинские записи
    Task<IEnumerable<MedicalRecord>> GetAllRecordsAsync();
    Task<IEnumerable<MedicalRecord>> GetRecordsByPatientIdAsync(int patientId);
    Task CreateMedicalRecordAsync(MedicalRecord record);

    // Приемы
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    Task CreateAppointmentAsync(Appointment appointment);
    Task DeletePatientWithRecordsAsync(int id);
    Task DeleteMedicalRecordAsync(int id);
    Task<Doctor?> GetDoctorByIdAsync(int id);
    Task DeleteAppointmentAsync(int id);
    Task<Appointment?> GetAppointmentByIdAsync(int id);
    Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId);
    Task UpdateAppointmentAsync(Appointment appointment);
    Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync();
    Task<MedicalRecord?> GetMedicalRecordByIdAsync(int id);
}