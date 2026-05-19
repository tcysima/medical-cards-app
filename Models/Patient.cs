namespace MedicalCardsApp.Web.Models;

/// <summary>
/// Сущность пациента.
/// </summary>
public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    /// <summary>
    /// Список медицинских записей пациента.
    /// </summary>
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    /// <summary>
    /// Список приёмов/визитов.
    /// </summary>
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}