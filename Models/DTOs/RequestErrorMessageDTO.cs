namespace pLocals.Models.DTOs
{
    public class RequestErrorMessageDTO
    {
        public required string ErrorMessage { get; set; }
        public required int StatusCode { get; set; }
    }
}
