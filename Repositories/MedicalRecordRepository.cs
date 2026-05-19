using MedicalCardsApp.Web.Data;
using MedicalCardsApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCardsApp.Web.Repositories;

public class MedicalRecordRepository : IMedicalRecordRepository
{
    private readonly MedicalCardsDbContext _context;

    public MedicalRecordRepository(MedicalCardsDbContext context) => _context = context;

    public async Task<IEnumerable<MedicalRecord>> GetAllAsync() =>
        await _context.MedicalRecords
            .Include(r => r.Patient)
            .Include(r => r.Doctor)
            .AsNoTracking()
            .ToListAsync();

    public async Task<MedicalRecord?> GetByIdAsync(int id) =>
        await _context.MedicalRecords
            .Include(r => r.Patient)
            .Include(r => r.Doctor)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId) =>
        await _context.MedicalRecords
            .Include(r => r.Doctor)
            .Where(r => r.PatientId == patientId)
            .AsNoTracking()
            .ToListAsync();

    public async Task AddAsync(MedicalRecord record)
    {
        await _context.MedicalRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MedicalRecord record)
    {
        _context.MedicalRecords.Update(record);
        await _context.SaveChangesAsync();
    }

    // ← ТОЛЬКО ОДИН ТАКОЙ МЕТОД!
    public async Task DeleteAsync(int id)
    {
        var record = await _context.MedicalRecords.FindAsync(id);
        if (record is not null)
        {
            _context.MedicalRecords.Remove(record);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}