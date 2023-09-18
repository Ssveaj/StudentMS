
using Core.Dto;
using Core.Interface.UseCases;
using Core.Interfaces;
using Core.Interfaces.UseCases;
using Core.Models;
using Core.Models.Base;
using Core.Models.Response;

namespace Core.UseCase
{
    public class GetStudentsUseCase : IGetStudentUseCase
    {
        private readonly IStudentRepository repo;       
        private readonly IGetGradeByStudentIdUseCase usecase;
        public GetStudentsUseCase(IStudentRepository repo, IGetGradeByStudentIdUseCase useCase)
        {
            this.repo = repo;
            this.usecase = useCase;
        }
        public async Task<Result<GetStudentsResponseModel>> ExecuteUseCaseAsync()
        {
            var getStudents = repo.GetStudents();
            if (getStudents == null)
            {
                return new Result<GetStudentsResponseModel>
                {
                    Error = "No Student Found",
                    ErrorCode = ErrorCode.NotFound,
                    Success = false
                };
            }
           
            var studentDTOs = new List<StudentDTO>();

            foreach (var student in getStudents)
            {
                var getGrades = await usecase.ExecuteUseCaseAsync(student.Id);
                var newStudent = new StudentDTO
                {
                    StudentName = student.StudentName,
                    Education = student.Education,
                    Id = student.Id,
                    Grades = getGrades.Value.studentGrade,
                };
               
                studentDTOs.Add(newStudent);
            }

            var responseModel = new GetStudentsResponseModel
            {
                Students = studentDTOs,
            };


            return new Result<GetStudentsResponseModel>
            {
                Success = true,
                Value = responseModel
            };

        }
    }
}
