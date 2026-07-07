using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Shared.Responses
{
    public static class ApiResponseFactory
    {
        public static ApiResponse<T> Success<T>(T data, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Failure<T>(string message, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
