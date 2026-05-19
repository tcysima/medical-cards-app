using FluentValidation;
using MedicalCardsApp.Web.Models;

namespace MedicalCardsApp.Web.Validators;

/// <summary>
/// Валидатор для сущности Patient.
/// </summary>
public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        // Проверка ФИО
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("ФИО обязательно для заполнения")
            .MaximumLength(100).WithMessage("ФИО не может быть длиннее 100 символов");

        // Проверка даты рождения
        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Дата рождения обязательна")
            .LessThan(DateTime.Now).WithMessage("Дата рождения не может быть в будущем");

        // Проверка Email (если введен)
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Неверный формат Email");
    }
}