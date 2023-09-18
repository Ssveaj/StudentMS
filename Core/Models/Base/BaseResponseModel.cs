

namespace Core.Models.Base
{
    public class BaseResponseModel
    {
        public int HttpStatusCode { get; set; } = 500;
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<ApiErrorResponseModel>? Errors { get; set; }
    }
}
