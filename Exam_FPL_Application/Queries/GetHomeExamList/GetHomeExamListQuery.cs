using ApiUser.BuildingBlocks.Enums;
using MediatR;
using System.Collections.Generic;

namespace Exam_FPL_Application.Queries.GetHomeExamList
{
    public class GetHomeExamListQuery : IRequest<IEnumerable<ExamDto>>
    {



    }
}
