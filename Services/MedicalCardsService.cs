using MedicalCardsApp.Web.Models;
using MedicalCardsApp.Web.Repositories;

namespace MedicalCardsApp.Web.Services;

/// <summary>
/// Сервис для работы с медицинскими картами.
/// </summary>
public class MedicalCardsService : IMedicalCardsService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMedicalRecordRepository _recordRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public MedicalCardsService(
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IMedicalRecordRepository recordRepository,
        IAppointmentRepository appointmentRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _recordRepository = recordRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync() =>
        await _patientRepository.GetAllAsync();

    public async Task<Patient?> GetPatientByIdAsync(int id) =>
        await _patientRepository.GetByIdAsync(id);

    public async Task CreatePatientAsync(Patient patient) =>
        await _patientRepository.AddAsync(patient);

    public async Task UpdatePatientAsync(Patient patient) =>
        await _patientRepository.UpdateAsync(patient);

    public async Task DeletePatientAsync(int id) =>
        await _patientRepository.DeleteAsync(id);

    public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync() =>
        await _doctorRepository.GetAllAsync();

    public async Task<Doctor?> GetDoctorByIdAsync(int id) =>
        await _doctorRepository.GetByIdAsync(id);

    public async Task<IEnumerable<MedicalRecord>> GetAllRecordsAsync() =>
        await _recordRepository.GetAllAsync();

    public async Task<IEnumerable<MedicalRecord>> GetRecordsByPatientIdAsync(int patientId) =>
        await _recordRepository.GetByPatientIdAsync(patientId);

    public async Task CreateMedicalRecordAsync(MedicalRecord record) =>
        await _recordRepository.AddAsync(record);

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync() =>
        await _appointmentRepository.GetAllAsync();

    public async Task CreateAppointmentAsync(Appointment appointment) =>
        await _appointmentRepository.AddAsync(appointment);
    public async Task DeletePatientWithRecordsAsync(int id)
    {
        await _patientRepository.DeleteWithRelationsAsync(id);
    }
    public async Task DeleteMedicalRecordAsync(int id) => await _recordRepository.DeleteAsync(id);
    public async Task CreateDoctorAsync(Doctor doctor) => await _doctorRepository.AddAsync(doctor);
    public async Task DeleteDoctorAsync(int id) => await _doctorRepository.DeleteAsync(id);
    public async Task DeleteAppointmentAsync(int id) =>
        await _appointmentRepository.DeleteAsync(id);
    public async Task<Appointment?> GetAppointmentByIdAsync(int id) =>
    await _appointmentRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId) =>
        await _appointmentRepository.GetByPatientIdAsync(patientId);

    public async Task UpdateAppointmentAsync(Appointment appointment) =>
        await _appointmentRepository.UpdateAsync(appointment);
    public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync() =>
    await _recordRepository.GetAllAsync();
    public async Task<MedicalRecord?> GetMedicalRecordByIdAsync(int id) =>
    await _recordRepository.GetByIdAsync(id);
}