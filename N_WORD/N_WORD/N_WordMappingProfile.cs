using AutoMapper;
using N_WORD.Entities;
using N_WORD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD
{
    public class N_WordMappingProfile : Profile
    {
        public N_WordMappingProfile()
        {
            CreateMap<Word, WordDto>()
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => s.Category.Name));

            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateWordDto, Word>();
        }
    }
}
