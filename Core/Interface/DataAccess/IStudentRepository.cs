


using Core.Dto;


namespace Core.Interfaces
{
    public interface IStudentRepository
    {
         List<StudentDTO> GetStudents();
    }
}
