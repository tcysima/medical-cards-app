using MedicalCardsApp.Web.Data;
using MedicalCardsApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCardsApp.Web.Repositories;

/// <summary>
/// Реализация репозитория Patient с использованием EF Core.
/// </summary>
public class PatientRepository : IPatientRepository
{
    private readonly MedicalCardsDbContext _context;

    public PatientRepository(MedicalCardsDbContext context) => _context = context;

    public async Task<IEnumerable<Patient>> GetAllAsync() =>
        await _context.Patients.AsNoTracking().ToListAsync();

    public async Task<Patient?> GetByIdAsync(int id) =>
        await _context.Patients.FindAsync(id);

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient is not null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    public async Task DeleteWithRelationsAsync(int id)
    {
        var patient = await _context.Patients
            .Include(p => p.MedicalRecords)
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (patient is null) return;

        // Удаляем связанные записи (каскадное удаление)
        _context.MedicalRecords.RemoveRange(patient.MedicalRecords);
        _context.Appointments.RemoveRange(patient.Appointments);

        // Удаляем пациента
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }
}