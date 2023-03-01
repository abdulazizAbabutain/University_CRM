using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Application.Features.Departments.Commands.AddDepaertment
{
    public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator()
        {
            RuleFor(x => x.NameArabic).MaximumLength(100);
            RuleFor(x => x.NameEnglish).MaximumLength(100);
            RuleFor(x => x.DescriptionArabic).MaximumLength(1000);
            RuleFor(x => x.DescriptionEnglish).MaximumLength(1000);
        }
    }
}
