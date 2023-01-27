namespace School.DB;

public class DatabaseResponse<T>
{
  public T? Data { get; set; }
  public string? Error { get; set; }
  public bool Success { get; set; }

  public DatabaseResponse(T? data, string? error)
  {
    Data = data;
    Error = error;
    Success = error is null;
  }

  public static DatabaseResponse<T> Default()
  {
    return new DatabaseResponse<T>(default(T), "Default error");
  }
}
