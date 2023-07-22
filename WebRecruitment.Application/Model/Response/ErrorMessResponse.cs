namespace WebRecruitment.Application.Model.Response
{
    public class ErrorMessResponse
    {

        public ErrorMessResponse() { }

        public ErrorMessResponse(bool success, Exception exception, int message, string error)
        {
            Success = success;
            Exception = exception;
            Message = message;
            Error = error;
        }

        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public int Message { get; set; }
        public string Error { get; set; }

    }
}
