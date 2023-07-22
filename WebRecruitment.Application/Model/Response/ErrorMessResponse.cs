namespace WebRecruitment.Application.Model.Response
{
    public class ErrorMessResponse
    {

        public ErrorMessResponse() { }

        public ErrorMessResponse(bool success, Exception exception, string message, int error)
        {
            Success = success;
            Exception = exception;
            Message = message;
            Error = error;
        }

        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public int Error { get; set; }

    }
}
