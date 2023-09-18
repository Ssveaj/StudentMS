using Core.Dto;
using Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Response
{
    public class GetStudentsResponseModel : BaseResponseModel
    {
        public List<StudentDTO> Students { get; set; } = default!;
    }
}
