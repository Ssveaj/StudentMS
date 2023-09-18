using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Education { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
