using AutoMapper;
using Core.Dto;
using Core.Interfaces;
using Core.Models;


namespace Infrastructure.Database.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<StudentDTO> GetStudents()
        {
            var dummyData = new List<Student>
            {
                new Student { Id = 1, StudentName = "John Doe", Education= "University, Örebro" },
                new Student { Id = 2, StudentName = "Jane Smith", Education= "University, Örebro" },
                new Student { Id = 3, StudentName = "Bob Johnson", Education= "University, Örebro" },
                new Student { Id = 4, StudentName = "Emily Davis", Education= "YH, Örebro"},
                new Student { Id = 5, StudentName = "Chris Wilson", Education= "YH, Örebro" }
            };


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>(MemberList.Destination)
                .ForMember(dest => dest.Grades, opt => opt.Ignore());

            });
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);
            var mappedData = mapper.Map<List<Student>, List<StudentDTO>>(dummyData);
          
            return mappedData;

        }
    }
}
