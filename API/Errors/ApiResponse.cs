using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);    
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

         private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request You Have Made",
                401 => "Authorized, You Are NOT",
                404 => "Resource Found!, It Was not",
                500 => "Error Are the path to the Dark side, Errors Leads To AnGer. Anger leads to hate. hate leads to career change",
                _ => null
            };
        }
    }
}