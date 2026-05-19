using MedicalCardsApp.Web.Models;

public class MedicalRecord
{
    public int Id { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // ← Просто добавьте это свойство (без настройки в DbContext)
    public string? Treatment { get; set; }

    public DateTime RecordDate { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
}