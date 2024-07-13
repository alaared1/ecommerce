
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
                400 => "A bad request, as bad as your stamina when you go for a run",
                401 => "Not Authorized, stop trying to be someone else, just be you",
                404 => "Resource Not Found, just like people when you need them",
                500 => "Errors occured, too many errors, you can try and fix them but better start something new",
                _ => null
            };
        }

    }
}