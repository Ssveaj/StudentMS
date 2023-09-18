using Core.Interface.UseCases;
using Core.Models;
using Core.Models.Response;
using Newtonsoft.Json;
using System.Xml.Linq;
using System;

namespace Core.UseCase
{
    public class GetGradeByStudentIdUseCase : IGetGradeByStudentIdUseCase
    {
        public async Task<Result<GetGradeByStudentIdResponseModel>> ExecuteUseCaseAsync(int studentId)
        {
            try
            {
                var message = new HttpRequestMessage();
                var response = new HttpResponseMessage();
                message.RequestUri = new Uri($"{"https://host.docker.internal:63488/api/Grade?studentId="}{studentId}");
                message.Method = HttpMethod.Get;

                // Get rid off SSL connection issue
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    response = await client.SendAsync(message).ConfigureAwait(false);
                }
               
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var getGrade = JsonConvert.DeserializeObject<GetGradeByStudentIdResponseModel>(responseBody);
                if(getGrade == null)
                {
                    return new Result<GetGradeByStudentIdResponseModel>
                    {
                        Error = "GradeMs returns null",
                        ErrorCode = ErrorCode.NotFound,
                        Success = false
                    };
                }

                var responseModel = new GetGradeByStudentIdResponseModel
                {
                    studentGrade = getGrade.studentGrade
                };

                return new Result<GetGradeByStudentIdResponseModel>
                {
                    Success = true,
                    Value = responseModel
                };

            }
            catch (Exception ex)
            {
                return new Result<GetGradeByStudentIdResponseModel>
                {
                    Error = ex.Message,
                    ErrorCode = ErrorCode.InternalServerError,
                    Success = false
                };
            }
        }
    }
}
