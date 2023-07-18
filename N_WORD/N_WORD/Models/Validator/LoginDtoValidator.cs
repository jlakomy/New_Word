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
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator(N_WordDbContext _dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
