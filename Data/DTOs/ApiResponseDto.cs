// Data/DTOs/ApiResponse.cs
namespace course_learning_tutorial.Data.DTOs;

public class ApiResponseDto<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static ApiResponseDto<T> SuccessResult(T data, string message = "Operation completed successfully")
    {
        return new ApiResponseDto<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static ApiResponseDto<T> ErrorResult(string message)
    {
        return new ApiResponseDto<T>
        {
            Success = false,
            Message = message,
        };
    }
}
public class ApiResponseDto : ApiResponseDto<object>
{
    public static ApiResponseDto SuccessResult(string message = "Operation completed successfully")
    {
        return new ApiResponseDto
        {
            Success = true,
            Message = message
        };
    }

    public new static ApiResponseDto ErrorResult(string message)
    {
        return new ApiResponseDto
        {
            Success = false,
            Message = message,
        };
    }
}
