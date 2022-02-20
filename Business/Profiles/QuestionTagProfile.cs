using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concretes.Models;

namespace Business.Profiles
{
    internal class QuestionTagProfile : Profile
    {
        public QuestionTagProfile()
        {
            CreateMap<Tag, QuestionTag>()
                .ForMember(dest => dest.TagId,
                    opt 
                        => opt.MapFrom(src => src.Id));

            CreateMap<Question, QuestionTag>()
                .ForMember(dest => dest.QuestionId,
                    opt 
                        => opt.MapFrom(src => src.Id));
        }
    }
}
