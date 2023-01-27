using School.DB;
using School.Models;

namespace School.Services;
public class StudentService
{
  private readonly MySqlConnectionManager _connector;

  public StudentService(MySqlConnectionManager connector)
  {
    _connector = connector;
  }

  public async Task<Pagination<Student>> GetAllStudents(string criteria, int limit, int offset)
  {
    var parameters = new Dictionary<string, object>();
    parameters.Add("criteria", criteria);
    parameters.Add("p_limit", limit);
    parameters.Add("p_offset", offset);
    var response = await _connector.Execute<Pagination<Student>>("find_students_by_criteria", parameters);
    
     return response.Data ?? new Pagination<Student>(new List<Student>(), 0, limit, offset);
  }
}
