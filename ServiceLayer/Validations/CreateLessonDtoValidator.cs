using FluentValidation;
using ServiceLayer.Dtos.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class CreateLessonDtoValidator : AbstractValidator<CreateLessonDto>
    {
        public CreateLessonDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotNull().WithMessage("Dərs kodu boş olmamalıdır")
                .Length(1, 3).WithMessage("Dərs kodu 1 ilə 3 simvol arasında olmalıdır");

            RuleFor(x => x.lessonName)
                .NotNull().WithMessage("Dərsin adı boş olmamalıdır")
                .MaximumLength(30).WithMessage("Dərsin adı ən çox 30 simvol olmalıdır");

            RuleFor(x => x.teacherName)
                .NotNull().WithMessage("Müəllim adı boş olmamalıdır")
                .MaximumLength(30).WithMessage("Müəllim adı ən çox 30 simvol olmalıdır");

            RuleFor(x => x.teacherSurname)
                .NotNull().WithMessage("Müəllim soyadı boş olmamalıdır")
                .MaximumLength(30).WithMessage("Müəllim soyadı ən çox 30 simvol olmalıdır");

            RuleFor(x => x.Grade)
                .InclusiveBetween(1, 11).WithMessage("Sinif 1 ilə 11 arasında olmalıdır");
        }
    }
}
