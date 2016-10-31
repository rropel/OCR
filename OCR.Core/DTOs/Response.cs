namespace OCR.Core.DTOs
{
    public class Response<T> : BasicResponse
    {
        public T Result { get; set; }
        public string Message { get; set; }
    }
}