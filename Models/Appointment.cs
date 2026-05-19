namespace MedicalCardsApp.Web.Models;

/// <summary>
/// Запись на приём (связь N:N между пациентом и врачом).
/// </summary>
public class Appointment
{
    public int Id { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string Status { get; set; } = "Запланирован";

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
}