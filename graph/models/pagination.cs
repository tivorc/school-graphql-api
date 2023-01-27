namespace School.Models;

public class Pagination<T>
{
  public List<T> List { get; set; }
  public int Total { get; set; }
  public int Limit { get; set; }
  public int Offset { get; set; }
  public int TotalPages { get { return GetTotalPages(); } }
  public int CurrentPage { get { return GetCurrentPage(); } }
  public bool Next { get { return Limit + Offset < Total; } }
  public bool Back { get { return CurrentPage != 1; } }

  public Pagination(List<T> list, int total, int limit, int offset)
  {
    List = list;
    Total = total;
    Limit = limit;
    Offset = offset;
  }

  private int GetTotalPages()
  {
    if (Limit == 0 || Total == 0)
      return 0;

    decimal limit = Limit;
    decimal total = Total;
    int totalPages = Int32.Parse(Math.Ceiling(total / limit).ToString());

    return totalPages;
  }

  private int GetCurrentPage()
  {
    if (Limit == 0 || Total == 0)
      return 0;

    var isLastPage = Limit + Offset >= Total;
    int totalPages = isLastPage ? TotalPages : (Offset + Limit / Limit);

    return totalPages;
  }
}
