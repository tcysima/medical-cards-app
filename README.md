[ReadMe.md](https://github.com/user-attachments/files/28031667/ReadMe.md)
MedicalCardsWeb:
Веб-приложение для управления медицинской документацией и картами пациентов на ASP.NET Core 10 с использованием Blazor Server.

Описание:
MedicalCardsWeb — это полнофункциональное веб-приложение для автоматизации учёта медицинской документации в амбулаторно-поликлинических условиях. Приложение позволяет:
Регистрировать новых пациентов и заполнять их профили
Вести справочник врачей со специализациями
Создавать и редактировать медицинские карты (диагноз, симптомы, лечение)
Планировать и отслеживать врачебные приёмы
Быстро искать данные по ФИО, диагнозу или дате
Просматривать детальную статистику и историю обращений

Используемые технологии:
1. .NET 10
2. ASP.NET Core
3. Blazor Server
4. Entity Framework Core 10
5. SQLite
6. Bootstrap 5 / CSS Custom Properties
7. Docker

Установка и запуск приложения:
Клонирование репозитория
git clone https://github.com/tcysima/medical-cards-app
cd MedicalCardsWeb

Восстановление зависимостей
dotnet restore
dotnet build

Применение миграций базы данных
dotnet ef database update

Запуск приложения
dotnet run
Перейти по ссылке http://localhost:5111/

Запуск через Docker:
Сборка образа

docker build -t amirka19/medicalcards:latest .

Запуск контейнера
docker run -d -p 8080:8080 --name medicalcards -v medical-db:/amirka19/medicalcards:latest

Перейти по ссылке http://localhost:8080

Сущности:
Patients — Пациенты (ФИО, дата рождения, телефон, электронная почта)
Doctors — Врачи (ФИО, специальность, телефон)
MedicalRecords — Медицинские карты (дата записи, диагноз, описание симптомов, назначенное лечение)
Appointments — Приёмы (дата и время, статус, привязка к пациенту и врачу)

Полезные команды:
Создание новой миграции:
dotnet ef migrations add MigrationName

Применение миграций:
dotnet ef database update

Сборка проекта:
dotnet build

Публикация:
dotnet publish -c Release -o ./publish

Очистка:
dotnet clean

Структура проекта:
MedicalCardsWeb/
├── Data/
│   ├── MedicalCardsDbContext.cs
│   ├── DataSeeder.cs
│   └── Migrations/
├── Models/
│   ├── Patient.cs
│   ├── Doctor.cs
│   ├── MedicalRecord.cs
│   ── Appointment.cs
├── Repositories/
│   ├── IPatientRepository.cs
│   ├── IDoctorRepository.cs
│   ├── IMedicalRecordRepository.cs
│   ├── IAppointmentRepository.cs
│   └── Implementations/
├── Services/
│   ├── IMedicalCardsService.cs
│   └── MedicalCardsService.cs
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   └── Pages/
│       ├── Patients.razor
│       ├── PatientDetails.razor
│       ├── Doctors.razor
│       ├── DoctorDetails.razor
│       ├── Appointments.razor
│       ├── AppointmentDetails.razor
│       ├── MedicalRecords.razor
│       └── MedicalRecordDetails.razor
├── wwwroot/
│   ── css/
│       ├── bootstrap.min.css
│       └── medical-theme.css
├── appsettings.json
├── Program.cs
├── Dockerfile
└── docker-compose.yml


 Описание основных папок:
Components/ — Blazor компоненты и страницы интерфейса
Components/Layout/ — Макеты страниц и меню навигации
Components/Pages/ — Razor-страницы с бизнес-логикой (@code)
Data/ — Контекст базы данных, конфигурация EF Core и сидер
Migrations/ — История изменений схемы БД
Models/ — Классы доменных сущностей
Repositories/ — Интерфейсы и реализации паттерна Repository
Services/ — Сервисный слой, агрегирующий работу репозиториев
wwwroot/ — Статические файлы, CSS-темы оформления


Студент: Кашапов Амир Рустемович
Группа:  ББСО-02-24
Университет: РТУ МИРЭА
Репозиторий: https://github.com/tcysima/medical-cards-app
Docker Hub: https://hub.docker.com/r/amirka19/medicalcards/tags
