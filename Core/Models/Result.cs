using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Result<T>   
    {
        public bool Success { get; set; }
        public string Error { get; set; } = string.Empty;
        public ErrorCode ErrorCode { get; set; } = ErrorCode.None;
        public T? Value { get; set; }
        public Result(T value) => this.Value = value;
        public Result()
        {
        }
    }
    public enum ErrorCode { None, InvalidRequest, NotFound, Failed, FailedToCreate, FailedToUpdate, FailedToDelete, BadRequest, InternalServerError, Unauthorized }
}
