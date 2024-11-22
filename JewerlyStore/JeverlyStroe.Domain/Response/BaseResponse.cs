using JeverlyStroe.Domain.Enum;
namespace JeverlyStroe.Domain.Response;

public class BaseResponse<T>:IBaseResponse<T>
{
    public string Description { get; set; }
    public StatucCode StatusCode { get; set; }
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    T Data { get; set; }
}