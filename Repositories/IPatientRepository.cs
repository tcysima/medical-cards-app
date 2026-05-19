using MedicalCardsApp.Web.Models;

namespace MedicalCardsApp.Web.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с сущностью Patient.
/// </summary>
public interface IPatientRepository
{
    /// <summary>Получить всех пациентов.</summary>
    Task<IEnumerable<Patient>> GetAllAsync();
    /// <summary>Найти пациента по ID.</summary>
    Task<Patient?> GetByIdAsync(int id);
    /// <summary>Добавить пациента.</summary>
    Task AddAsync(Patient patient);
    /// <summary>Обновить пациента.</summary>
    Task UpdateAsync(Patient patient);
    /// <summary>Удалить пациента.</summary>
    Task DeleteAsync(int id);
    /// <summary>Сохранить изменения в БД.</summary>
    Task SaveChangesAsync();
    Task DeleteWithRelationsAsync(int id);
}