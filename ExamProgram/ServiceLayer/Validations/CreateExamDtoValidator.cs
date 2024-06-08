using FluentValidation;
using ServiceLayer.Dtos.Exam;

namespace ServiceLayer.Validations
{
    public class CreateExamDtoValidator : AbstractValidator<CreateExamDto>
    {
        public CreateExamDtoValidator()
        {
            RuleFor(x => x.examDate)
                .NotEmpty().WithMessage("İmtahan tarixi boş olmamalıdır")
                .GreaterThan(DateTime.Now).WithMessage("İmtahan tarixi gələcəkdə olmalıdır");

            RuleFor(x => x.Score)
                .InclusiveBetween(0, 10).WithMessage("İmtahan qiyməti 0 ilə 10 arasında olmalıdır");

            RuleFor(x => x.LessonId)
                .NotEmpty().WithMessage("Dərs boş olmamalıdır")
                .NotNull().WithMessage("Dərs boş olmamalıdır");

            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("Tələbə boş olmamalıdır")
                .NotNull().WithMessage("Tələbə boş olmamalıdır");
        }
    }
}
