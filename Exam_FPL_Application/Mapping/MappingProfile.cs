using ApiUser.BuildingBlocks.Enums;
using ApiUser.Domain.AggregateModels.ExamAggregate;
using AutoMapper;

namespace Exam_FPL_Application.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();
        }
    }

}
