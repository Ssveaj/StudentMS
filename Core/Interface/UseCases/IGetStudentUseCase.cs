using Core.Models;
using Core.Models.Response;

namespace Core.Interfaces.UseCases
{
    public interface IGetStudentUseCase
    {
        public Task<Result<GetStudentsResponseModel>> ExecuteUseCaseAsync();
    }
}
