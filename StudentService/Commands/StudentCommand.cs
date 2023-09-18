using Core.Interfaces.UseCases;
using Core.Models;
using Core.Models.Base;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace StudentService.Commands
{
    public class StudentCommand
    {
        private readonly IGetStudentUseCase usecase;
        public StudentCommand(IGetStudentUseCase usecase)
        {
            this.usecase = usecase;
        }
        public async Task<IActionResult> ExecuteAsync()
        {
            try
            {
                var result = await usecase.ExecuteUseCaseAsync();
                if(result.Success && result.Value == null)
                {
                    var errorResponseModel = new GetStudentsResponseModel
                    {
                        Success = false,
                        HttpStatusCode = 404,
                        Errors = new List<ApiErrorResponseModel> { new ApiErrorResponseModel { Message = result.Error } }
                    };

                    return new ObjectResult(errorResponseModel);
                }

                var retreivedGetStudentResponseModel = new GetStudentsResponseModel
                {
                    Success = true,
                    HttpStatusCode = 200,
                    Students = result.Value.Students,

                };
                return new OkObjectResult(retreivedGetStudentResponseModel);

            }
            catch (Exception ex)
            {
                var responseModel = new GetStudentsResponseModel
                {
                    Success = false,
                    HttpStatusCode = 500,
                    Errors = new List<ApiErrorResponseModel> { new ApiErrorResponseModel { Message = ex.Message } }

                };
                return new ObjectResult(responseModel);
            }
        }
    }
}
