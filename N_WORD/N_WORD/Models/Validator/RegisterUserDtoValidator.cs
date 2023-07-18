using FluentValidation;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using N_WORD.Entities;

namespace N_WORD.Models.Validator
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(N_WordDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(8);
            RuleFor(x => x.ConfirmePassword)
                .Equal(e => e.Password);
            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var EmailUsed = dbContext.Users.Any(u => u.Email == value);
                    if (EmailUsed)
                    {
                        context.AddFailure("Email", "Email already taken");
                    }
                });
        }
    }
}
