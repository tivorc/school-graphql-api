using GraphQL;
using GraphQL.Types;
using School.GraphQL.Types;
using School.Models;
using School.Services;

namespace School.GraphQL;
public class Queries : ObjectGraphType<object>
{
  public Queries()
  {
    Name = "Queries";
    Field<PaginationType<Student, StudentType>>("students")
      .Argument<NonNullGraphType<StringGraphType>>("criteria", "Student name or id number")
      .Argument<NonNullGraphType<UIntGraphType>>("limit", "Pagination limit")
      .Argument<NonNullGraphType<UIntGraphType>>("offset", "Pagination offset")
      .ResolveAsync(async context => {
        var criteria = context.GetArgument<string>("criteria");
        var limit = context.GetArgument<int>("limit");
        var offset = context.GetArgument<int>("offset");
        var service = context.RequestServices!.GetRequiredService<StudentService>();
        return await service.GetAllStudents(criteria, limit, offset);
      });
    Field<NonNullGraphType<StringGraphType>>("hello")
      .Resolve(context => "Hello World from Chepén!");
  }
}
