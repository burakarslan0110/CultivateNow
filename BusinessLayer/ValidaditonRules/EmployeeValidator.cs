using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidaditonRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmpNameSurname).NotEmpty().WithMessage("Ad ve soyadı boş geçemezsiniz!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev tanımını boş geçemezsiniz!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim yolu boş geçilemez!");
            RuleFor(x => x.EmpNameSurname).MaximumLength(60).WithMessage("Lütfen 60 karakterden kısa veri girişi yapın.");
            RuleFor(x => x.EmpNameSurname).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik veri girişi yapın.");
            RuleFor(x => x.Title).MaximumLength(60).WithMessage("Lütfen 60 karakterden kısa veri girişi yapın.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik veri girişi yapın.");


        }
    }
}
