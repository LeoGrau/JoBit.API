namespace JoBit.API.Shared.Domain.Services.Communication;

public class BaseResponse<T>
{
    public String Message { get; private set; }
    public Boolean Success { get; private set; }
    public T Resource { get; private set; }

    
    //Successful Response
    protected BaseResponse(T resource)
    {
        Message = String.Empty;
        Success = true;
        Resource = resource;
    }
    
    //Error Response
    protected BaseResponse(String message)
    {
        Message = message;
        Success = false;
        Resource = default;
    }
}