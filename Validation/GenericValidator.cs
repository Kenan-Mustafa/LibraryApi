using DAL.Abstract;
using DAL.Concrete;
using DAL.Context;
using DTO.AuthorDTOs;
using DTO.BookDTOs;
using DTO.MemberDTOs;
using DTO.RoleDTOs;
using DTO.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class GenericValidator<T> : AbstractValidator<T>
    {
        public GenericValidator()
        {
            if (typeof(T) == typeof(UserToAddDto))
            {
                RuleFor(x => ((UserToAddDto)(object)x).Username) 
                    .NotEmpty().WithMessage("Ad hissəsi boş qoyula bilməz");

                RuleFor(x => ((UserToAddDto)(object)x).Password)
                    .NotEmpty().WithMessage("Şifrə Boş Qoyula Bilməz")
                    .NotNull().WithMessage("Şifrə Boş Qoyula Bilməz")
                    .MinimumLength(8).WithMessage("Şifrə 8 simvoldan qısa ola bilməz")
                    .MaximumLength(30).WithMessage("Şifrə 30 simvoldan uzun ola bilməz")
                    .Must(BeAValidPassword).WithMessage("Şifrə en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.");

            }

            if (typeof(T) == typeof(BookToAddDto))
            {
                RuleFor(x => ((BookToAddDto)(object)x).Title)
                    .NotEmpty().WithMessage("Kitabın adı boş ola bilməz").WithErrorCode("400")
                    .NotNull().WithMessage("Kitabın adı boş ola bilməz").WithErrorCode("400");

                RuleFor(x => ((BookToAddDto)(object)x).AuthorsIds)
                                .Must(ids => ids != null && ids.Count > 0)
                                .WithMessage("Kitabın Müəllifləri Qeyd Edilməlidir.").WithErrorCode("400");

            }
            if (typeof(T) == typeof(RoleToAddDto))
            {
                RuleFor(x => ((RoleToAddDto)(object)x).Name)
                    .NotEmpty().WithMessage("Rol adı boş ola bilməz").WithErrorCode("400")
                    .NotNull().WithMessage("Rol adı boş ola bilməz").WithErrorCode("400");

            }
            if (typeof(T) == typeof(AuthorToAddDto))
            {
                RuleFor(x => ((AuthorToAddDto)(object)x).FirstName)
                    .NotEmpty().WithMessage("Ad  boş ola bilməz").WithErrorCode("400")
                    .NotNull().WithMessage("Ad boş ola bilməz").WithErrorCode("400");
                
                RuleFor(x => ((AuthorToAddDto)(object)x).LastName)
                    .NotEmpty().WithMessage("Soyad  boş ola bilməz").WithErrorCode("400")
                    .NotNull().WithMessage("Soyad boş ola bilməz").WithErrorCode("400");
            }
            if (typeof(T) == typeof(MemberToAddDto))
            {
                RuleFor(x => ((AuthorToAddDto)(object)x).FirstName)
                    .NotEmpty().WithMessage("Ad  boş ola bilməz").WithErrorCode("400")
                    .NotNull().WithMessage("Ad boş ola bilməz").WithErrorCode("400");
                
                RuleFor(x => ((AuthorToAddDto)(object)x).LastName)
                    .NotEmpty().WithMessage("Soyad  boş ola bilməz").WithErrorCode("400")
                    .NotNull().WithMessage("Soyad boş ola bilməz").WithErrorCode("400");


            }

        }
        
        private bool BeAValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            bool hasUpperChar = password.Any(char.IsUpper);
            bool hasLowerChar = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpperChar && hasLowerChar && hasDigit && hasSpecialChar;
        }
    }
}
