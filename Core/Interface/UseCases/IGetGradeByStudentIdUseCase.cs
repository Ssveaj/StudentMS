using Core.Models.Response;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.UseCases
{
    public interface IGetGradeByStudentIdUseCase
    {
        Task<Result<GetGradeByStudentIdResponseModel>> ExecuteUseCaseAsync(int studentId);
    }
}
