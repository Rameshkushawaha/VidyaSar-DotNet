namespace VidyaSar.Application.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public ApiResponse() { }

    public ApiResponse(bool success, string message, T? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static ApiResponse<T> Ok(string message, T? data = default) =>
        new(true, message, data);

    public static ApiResponse<T> Fail(string message) =>
        new(false, message, default);
}

public class ApiResponse : ApiResponse<object>
{
    public ApiResponse() { }
    public ApiResponse(bool success, string message, object? data = null)
        : base(success, message, data) { }

    public static ApiResponse Ok(string message, object? data = null) =>
        new(true, message, data);

    public static ApiResponse Fail(string message) =>
        new(false, message, null);
}
