using AutoMapper;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;

namespace Entity.Profiles
{
    public class QuestionsProfile : Profile
    {
        public QuestionsProfile()
        {
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<QuestionCreateDto, QuestionFile>();
            CreateMap<QuestionCreateDto, Tag>();

        }
    }
}
