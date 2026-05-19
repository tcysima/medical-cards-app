namespace MedicalCardsApp.Web.Models;

/// <summary>
/// Сущность врача.
/// </summary>
public class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string? Phone { get; set; }

    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}