namespace LeaveTastic.Shared.Models
{
    public class DataResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; } = null!;
    }
}
