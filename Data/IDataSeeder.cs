namespace MedicalCardsApp.Web.Data;

/// <summary>
/// Интерфейс для первичного заполнения базы данных тестовыми данными.
/// </summary>
public interface IDataSeeder
{
    /// <summary>
    /// Заполняет БД данными, если они ещё не существуют.
    /// </summary>
    Task SeedAsync();
}