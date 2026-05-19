using MedicalCardsApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCardsApp.Web.Data;

/// <summary>
/// Контекст базы данных для работы с электронными медицинскими картами.
/// </summary>
public class MedicalCardsDbContext : DbContext
{
    public MedicalCardsDbContext(DbContextOptions<MedicalCardsDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Настройка Patient
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique().HasDatabaseName("IX_Patients_Email");
            entity.HasIndex(e => e.Phone).HasDatabaseName("IX_Patients_Phone");

            entity.HasMany(e => e.MedicalRecords)
                  .WithOne(e => e.Patient)
                  .HasForeignKey(e => e.PatientId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Appointments)
                  .WithOne(e => e.Patient)
                  .HasForeignKey(e => e.PatientId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Начальные данные - 30 пациентов
            entity.HasData(
                new Patient { Id = 1, FullName = "Иванов Иван Петрович", DateOfBirth = DateTime.Parse("1985-03-15"), Phone = "+79001234567", Email = "ivanov@test.ru" },
                new Patient { Id = 2, FullName = "Петрова Анна Сергеевна", DateOfBirth = DateTime.Parse("1990-07-22"), Phone = "+79001234568", Email = "petrova@test.ru" },
                new Patient { Id = 3, FullName = "Сидоров Алексей Михайлович", DateOfBirth = DateTime.Parse("1978-11-30"), Phone = "+79001234569", Email = "sidorov@test.ru" },
                new Patient { Id = 4, FullName = "Козлова Елена Владимировна", DateOfBirth = DateTime.Parse("1995-01-10"), Phone = "+79001234570", Email = "kozlova@test.ru" },
                new Patient { Id = 5, FullName = "Морозов Дмитрий Олегович", DateOfBirth = DateTime.Parse("1982-06-18"), Phone = "+79001234571", Email = "morozov@test.ru" },
                new Patient { Id = 6, FullName = "Новикова Мария Игоревна", DateOfBirth = DateTime.Parse("1988-09-25"), Phone = "+79001234572", Email = "novikova@test.ru" },
                new Patient { Id = 7, FullName = "Волков Сергей Андреевич", DateOfBirth = DateTime.Parse("1975-04-12"), Phone = "+79001234573", Email = "volkov@test.ru" },
                new Patient { Id = 8, FullName = "Лебедева Ольга Павловна", DateOfBirth = DateTime.Parse("1992-12-05"), Phone = "+79001234574", Email = "lebedeva@test.ru" },
                new Patient { Id = 9, FullName = "Соколов Николай Викторович", DateOfBirth = DateTime.Parse("1980-08-20"), Phone = "+79001234575", Email = "sokolov@test.ru" },
                new Patient { Id = 10, FullName = "Павлова Татьяна Дмитриевна", DateOfBirth = DateTime.Parse("1987-02-14"), Phone = "+79001234576", Email = "pavlova@test.ru" },
                new Patient { Id = 11, FullName = "Семенов Андрей Евгеньевич", DateOfBirth = DateTime.Parse("1993-05-28"), Phone = "+79001234577", Email = "semenov@test.ru" },
                new Patient { Id = 12, FullName = "Федорова Ирина Николаевна", DateOfBirth = DateTime.Parse("1979-10-03"), Phone = "+79001234578", Email = "fedorova@test.ru" },
                new Patient { Id = 13, FullName = "Кузнецов Михаил Сергеевич", DateOfBirth = DateTime.Parse("1986-07-16"), Phone = "+79001234579", Email = "kuznetsov@test.ru" },
                new Patient { Id = 14, FullName = "Попова Светлана Александровна", DateOfBirth = DateTime.Parse("1991-03-09"), Phone = "+79001234580", Email = "popova@test.ru" },
                new Patient { Id = 15, FullName = "Васильев Павел Иванович", DateOfBirth = DateTime.Parse("1984-11-21"), Phone = "+79001234581", Email = "vasiliev@test.ru" },
                new Patient { Id = 16, FullName = "Смирнова Анна Петровна", DateOfBirth = DateTime.Parse("1996-06-07"), Phone = "+79001234582", Email = "smirnova@test.ru" },
                new Patient { Id = 17, FullName = "Конов Игорь Владимирович", DateOfBirth = DateTime.Parse("1977-01-25"), Phone = "+79001234583", Email = "konov@test.ru" },
                new Patient { Id = 18, FullName = "Михайлова Екатерина Сергеевна", DateOfBirth = DateTime.Parse("1989-09-13"), Phone = "+79001234584", Email = "mikhailova@test.ru" },
                new Patient { Id = 19, FullName = "Александров Дмитрий Павлович", DateOfBirth = DateTime.Parse("1983-04-30"), Phone = "+79001234585", Email = "alexandrov@test.ru" },
                new Patient { Id = 20, FullName = "Борисова Наталья Игоревна", DateOfBirth = DateTime.Parse("1994-12-18"), Phone = "+79001234586", Email = "borisova@test.ru" },
                new Patient { Id = 21, FullName = "Григорьев Сергей Михайлович", DateOfBirth = DateTime.Parse("1981-08-05"), Phone = "+79001234587", Email = "grigoriev@test.ru" },
                new Patient { Id = 22, FullName = "Егорова Ольга Александровна", DateOfBirth = DateTime.Parse("1990-02-22"), Phone = "+79001234588", Email = "egorova@test.ru" },
                new Patient { Id = 23, FullName = "Зайцев Андрей Дмитриевич", DateOfBirth = DateTime.Parse("1976-10-11"), Phone = "+79001234589", Email = "zaytsev@test.ru" },
                new Patient { Id = 24, FullName = "Иванова Мария Сергеевна", DateOfBirth = DateTime.Parse("1992-05-27"), Phone = "+79001234590", Email = "ivanova.m@test.ru" },
                new Patient { Id = 25, FullName = "Козлов Павел Николаевич", DateOfBirth = DateTime.Parse("1985-07-14"), Phone = "+79001234591", Email = "kozlov.p@test.ru" },
                new Patient { Id = 26, FullName = "Лебедев Игорь Владимирович", DateOfBirth = DateTime.Parse("1988-03-01"), Phone = "+79001234592", Email = "lebedev.i@test.ru" },
                new Patient { Id = 27, FullName = "Макарова Татьяна Петровна", DateOfBirth = DateTime.Parse("1993-11-19"), Phone = "+79001234593", Email = "makarova@test.ru" },
                new Patient { Id = 28, FullName = "Николаев Алексей Сергеевич", DateOfBirth = DateTime.Parse("1979-06-08"), Phone = "+79001234594", Email = "nikolaev@test.ru" },
                new Patient { Id = 29, FullName = "Орлова Светлана Дмитриевна", DateOfBirth = DateTime.Parse("1991-01-23"), Phone = "+79001234595", Email = "orlova@test.ru" },
                new Patient { Id = 30, FullName = "Романов Михаил Павлович", DateOfBirth = DateTime.Parse("1984-09-15"), Phone = "+79001234596", Email = "romanov@test.ru" }
            );
        });

        // 2. Настройка Doctor
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Specialty).HasDatabaseName("IX_Doctors_Specialty");

            entity.HasMany(e => e.MedicalRecords)
                  .WithOne(e => e.Doctor)
                  .HasForeignKey(e => e.DoctorId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Appointments)
                  .WithOne(e => e.Doctor)
                  .HasForeignKey(e => e.DoctorId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Начальные данные - 5 врачей
            entity.HasData(
                new Doctor { Id = 1, FullName = "Докторов Иван Петрович", Specialty = "Терапевт", Phone = "+79001111111" },
                new Doctor { Id = 2, FullName = "Медведева Анна Сергеевна", Specialty = "Кардиолог", Phone = "+79002222222" },
                new Doctor { Id = 3, FullName = "Хирургов Алексей Михайлович", Specialty = "Хирург", Phone = "+79003333333" },
                new Doctor { Id = 4, FullName = "Невролова Елена Владимировна", Specialty = "Невролог", Phone = "+79004444444" },
                new Doctor { Id = 5, FullName = "Педиатров Дмитрий Олегович", Specialty = "Педиатр", Phone = "+79005555555" }
            );
        });

        // 3. Настройка MedicalRecord
        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Diagnosis).HasDatabaseName("IX_MedicalRecords_Diagnosis");

            // Начальные данные - медицинские записи
            entity.HasData(
                new MedicalRecord { Id = 1, PatientId = 1, DoctorId = 1, Diagnosis = "ОРВИ", Description = "Острая респираторная вирусная инфекция. Назначено симптоматическое лечение.", RecordDate = DateTime.Parse("2025-01-15") },
                new MedicalRecord { Id = 2, PatientId = 2, DoctorId = 2, Diagnosis = "Гипертония", Description = "Артериальная гипертензия 2 степени. Рекомендована диета и медикаментозная терапия.", RecordDate = DateTime.Parse("2025-02-10") },
                new MedicalRecord { Id = 3, PatientId = 3, DoctorId = 3, Diagnosis = "Аппендицит", Description = "Острый аппендицит. Проведена аппендэктомия.", RecordDate = DateTime.Parse("2025-03-05") },
                new MedicalRecord { Id = 4, PatientId = 4, DoctorId = 4, Diagnosis = "Мигрень", Description = "Хроническая мигрень. Назначены профилактические препараты.", RecordDate = DateTime.Parse("2025-01-20") },
                new MedicalRecord { Id = 5, PatientId = 5, DoctorId = 1, Diagnosis = "Гастрит", Description = "Хронический гастрит. Рекомендована диета стол №5.", RecordDate = DateTime.Parse("2025-02-25") },
                new MedicalRecord { Id = 6, PatientId = 6, DoctorId = 5, Diagnosis = "Бронхит", Description = "Острый бронхит у ребенка. Назначены ингаляции.", RecordDate = DateTime.Parse("2025-03-10") },
                new MedicalRecord { Id = 7, PatientId = 7, DoctorId = 2, Diagnosis = "Аритмия", Description = "Нарушение сердечного ритма. Проведено обследование.", RecordDate = DateTime.Parse("2025-01-30") },
                new MedicalRecord { Id = 8, PatientId = 8, DoctorId = 1, Diagnosis = "Ангина", Description = "Острый тонзиллит. Назначены антибиотики.", RecordDate = DateTime.Parse("2025-02-15") },
                new MedicalRecord { Id = 9, PatientId = 9, DoctorId = 4, Diagnosis = "Остеохондроз", Description = "Остеохондроз поясничного отдела. Рекомендована ЛФК.", RecordDate = DateTime.Parse("2025-03-01") },
                new MedicalRecord { Id = 10, PatientId = 10, DoctorId = 3, Diagnosis = "Грыжа", Description = "Паховая грыжа. Запланирована операция.", RecordDate = DateTime.Parse("2025-02-20") }
            );
        });

        // 4. Настройка Appointment
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.ScheduledDate).HasDatabaseName("IX_Appointments_ScheduledDate");

            // Начальные данные - приёмы
            entity.HasData(
                new Appointment { Id = 1, PatientId = 1, DoctorId = 1, ScheduledDate = DateTime.Parse("2026-05-15 10:00"), Status = "Запланирован" },
                new Appointment { Id = 2, PatientId = 2, DoctorId = 2, ScheduledDate = DateTime.Parse("2026-05-16 11:30"), Status = "Запланирован" },
                new Appointment { Id = 3, PatientId = 3, DoctorId = 3, ScheduledDate = DateTime.Parse("2026-05-17 14:00"), Status = "Завершён" },
                new Appointment { Id = 4, PatientId = 4, DoctorId = 4, ScheduledDate = DateTime.Parse("2026-05-18 09:00"), Status = "Запланирован" },
                new Appointment { Id = 5, PatientId = 5, DoctorId = 1, ScheduledDate = DateTime.Parse("2026-05-19 15:30"), Status = "Завершён" }
            );
        });
    }
}