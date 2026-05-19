using MedicalCardsApp.Web.Data;
using MedicalCardsApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCardsApp.Web.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly MedicalCardsDbContext _context;

    public AppointmentRepository(MedicalCardsDbContext context) => _context = context;

    public async Task<IEnumerable<Appointment>> GetAllAsync() =>
        await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Appointment?> GetByIdAsync(int id) =>
        await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment is not null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId) =>
        await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
}