using MedicalCardsApp.Web.Data;
using MedicalCardsApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCardsApp.Web.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly MedicalCardsDbContext _context;

    public DoctorRepository(MedicalCardsDbContext context) => _context = context;

    public async Task<IEnumerable<Doctor>> GetAllAsync() =>
        await _context.Doctors.AsNoTracking().ToListAsync();

    public async Task<Doctor?> GetByIdAsync(int id) =>
        await _context.Doctors.FindAsync(id);

    public async Task AddAsync(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is not null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}