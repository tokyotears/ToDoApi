namespace Api.DTO;

public enum ErrorType {
    NotFound
}

public class Response(string msg, ErrorType? error = null) {
    public ErrorType? Error { get; init; } = error;
    public string Message { get; init; } = msg;
    public bool IsSuccess => Error is null;
}

public class Response<T>(T data, string msg, ErrorType? error = null) : Response(msg, error) {
   public T Data = data;
}