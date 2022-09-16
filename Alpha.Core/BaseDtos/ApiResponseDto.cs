using System.Text.Json.Serialization;

namespace Alpha.Core.BaseDtos;

public class ApiResponseDto<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    [JsonIgnore] public int StatusCode { get; set; }


    // ! Static Factory Methods - Factory Design Pattern


    // *  SUCCESS   *
    public static ApiResponseDto<T> Success(int statusCode, T data)
    {
        return new ApiResponseDto<T> { Data = data, StatusCode = statusCode, Errors = null };
    }

    public static ApiResponseDto<T> Success(int statusCode)
    {
        return new ApiResponseDto<T> { StatusCode = statusCode };
    }

    // *    FAIL  *
    public static ApiResponseDto<T> Fail(int statusCode, List<string> errors)
    {
        return new ApiResponseDto<T> { StatusCode = statusCode, Errors = errors };
    }

    public static ApiResponseDto<T> Fail(int statusCode, string error)
    {
        return new ApiResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
    }
}