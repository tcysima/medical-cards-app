using MedicalCardsApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCardsApp.Web.Data;

public class DataSeeder : IDataSeeder
{
    private readonly MedicalCardsDbContext _context;
    private static readonly Random _random = new Random(); // ← Один Random на весь класс!

    public DataSeeder(MedicalCardsDbContext context) => _context = context;

    // Генератор реалистичного номера телефона
    private string GeneratePhone()
    {
        var codes = new[] { 916, 915, 910, 926, 925, 927, 903, 905, 906, 977, 999, 968, 965, 962 };
        var code = codes[_random.Next(codes.Length)];
        var part1 = _random.Next(100, 999);
        var part2 = _random.Next(10, 99);
        var part3 = _random.Next(10, 99);

        return $"+7 ({code}) {part1}-{part2}-{part3}";
    }
        public async Task SeedAsync()
    {
        // ← УДАЛИТЕ или ЗАКОММЕНТИРУЙТЕ эту строку!
        // if (await _context.Patients.AnyAsync()) return;

        // ОЧИСТИТЬ существующие данные
        _context.MedicalRecords.RemoveRange(_context.MedicalRecords);
        _context.Appointments.RemoveRange(_context.Appointments);
        _context.Patients.RemoveRange(_context.Patients);
        _context.Doctors.RemoveRange(_context.Doctors);
        await _context.SaveChangesAsync();

        Console.WriteLine("🗑️ Старые данные удалены");

        // 1. Врачи (5 штук) с телефонами
        var doctors = new List<Doctor>
        {
            new Doctor { FullName = "Иванов Иван Петрович", Specialty = "Терапевт", Phone = GeneratePhone() },
            new Doctor { FullName = "Петрова Анна Сергеевна", Specialty = "Кардиолог", Phone = GeneratePhone() },
            new Doctor { FullName = "Сидоров Алексей Михайлович", Specialty = "Невролог", Phone = GeneratePhone() },
            new Doctor { FullName = "Козлова Елена Владимировна", Specialty = "Педиатр", Phone = GeneratePhone() },
            new Doctor { FullName = "Морозов Дмитрий Олегович", Specialty = "Хирург", Phone = GeneratePhone() }
        };

        // 2. Пациенты (~30) с реалистичными номерами
        var patients = new List<Patient>();
        var lastNames = new[] { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов", "Попов", "Лебедев", "Козлов", "Новиков", "Морозов", "Васильев", "Михайлов", "Александров", "Федоров", "Григорьев" };
        var firstNames = new[] { "Александр", "Дмитрий", "Алексей", "Сергей", "Андрей", "Михаил", "Владимир", "Николай", "Иван", "Анна", "Елена", "Ольга", "Татьяна", "Мария", "Светлана" };
        var middleNames = new[] { "Александрович", "Дмитриевич", "Алексеевич", "Сергеевич", "Андреевич", "Михайлович", "Владимирович", "Николаевич", "Иванович", "Александровна", "Дмитриевна", "Алексеевна", "Сергеевна", "Андреевна", "Михайловна" };

        for (int i = 1; i <= 30; i++)
        {
            var lastName = lastNames[_random.Next(lastNames.Length)];
            var firstName = firstNames[_random.Next(firstNames.Length)];
            var middleName = middleNames[_random.Next(middleNames.Length)];

            var fullName = $"{lastName} {firstName} {middleName}";

            patients.Add(new Patient
            {
                FullName = fullName,
                DateOfBirth = DateTime.Now.AddYears(-_random.Next(18, 80)),
                Phone = GeneratePhone(),
                Email = $"patient{i}@demo.test"
            });
        }

        // Сохраняем, чтобы EF сгенерировал Id
        _context.Doctors.AddRange(doctors);
        _context.Patients.AddRange(patients);
        await _context.SaveChangesAsync();

        // 3. Медицинские записи и приёмы
        var records = new List<MedicalRecord>();
        var appointments = new List<Appointment>();
        var diagnoses = new[] { "ОРВИ", "Гипертония", "Гастрит", "Бронхиальная астма", "Аллергический ринит", "Мигрень", "Сахарный диабет 2 типа", "Остеохондроз", "Анемия", "Пневмония" };

        foreach (var patient in patients)
        {
            var doctor = doctors[_random.Next(doctors.Count)];

            // 1-2 записи на пациента
            int recCount = _random.Next(1, 3);
            for (int j = 0; j < recCount; j++)
            {
                records.Add(new MedicalRecord
                {
                    PatientId = patient.Id,
                    DoctorId = doctor.Id,
                    Diagnosis = diagnoses[_random.Next(diagnoses.Length)],
                    Description = "Назначено лечение. Рекомендовано наблюдение. Контрольный осмотр через 2 недели.",
                    RecordDate = DateTime.Now.AddDays(-_random.Next(10, 700))
                });
            }

            // 0-1 приём на пациента
            if (_random.Next(3) != 0)
            {
                appointments.Add(new Appointment
                {
                    PatientId = patient.Id,
                    DoctorId = doctor.Id,
                    ScheduledDate = DateTime.Now.AddDays(_random.Next(1, 21)),
                    Status = _random.Next(2) == 0 ? "Запланирован" : "Завершён"
                });
            }
        }

        _context.MedicalRecords.AddRange(records);
        _context.Appointments.AddRange(appointments);
        await _context.SaveChangesAsync();
    }
}