using MedicalCardsApp.Web.Components;
using MedicalCardsApp.Web.Data;
using MedicalCardsApp.Web.Repositories;
using MedicalCardsApp.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ВАЖНО: AddInteractiveServerComponents()
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// EF Core
builder.Services.AddDbContext<MedicalCardsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Репозитории
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

// Сервисы
builder.Services.AddScoped<IMedicalCardsService, MedicalCardsService>();
builder.Services.AddScoped<IDataSeeder, DataSeeder>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// ВАЖНО: AddInteractiveServerRenderMode()
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Инициализация БД
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<MedicalCardsDbContext>();
await dbContext.Database.MigrateAsync();

var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
await seeder.SeedAsync();

app.Run();