using FluentValidation;
using ServiceLayer.Dtos.Student;

namespace ServiceLayer.Validations
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.Number)
                .GreaterThanOrEqualTo(0).WithMessage("Tələbə nömrəsi müsbət olmalıdır")
                .LessThanOrEqualTo(99999).WithMessage("Tələbə nömrəsi ən çox 5 rəqəm olmalıdır");

            RuleFor(x => x.firstName)
                .NotNull().WithMessage("Tələbənin adı boş olmamalıdır")
                .MaximumLength(30).WithMessage("Tələbənin adı ən çox 30 simvol olmalıdır");

            RuleFor(x => x.lastName)
                .NotNull().WithMessage("Tələbənin soyadı boş olmamalıdır")
                .MaximumLength(30).WithMessage("Tələbənin soyadı ən çox 30 simvol olmalıdır");

            RuleFor(x => x.Grade)
                .InclusiveBetween(1, 11).WithMessage("Sinif 1 ilə 11 arasında olmalıdır");
        }
    }
}
