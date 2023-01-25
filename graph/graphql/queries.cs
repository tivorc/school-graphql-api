using GraphQL.Types;
using School.GraphQL.Types;
using School.Models;

namespace School.GraphQL;
public class Queries : ObjectGraphType<object>
{
  public Queries()
  {
    Name = "Queries";
    Field<NonNullGraphType<ListGraphType<NonNullGraphType<StudentType>>>>("students")
      .Resolve(context => Student.GetList());
    Field<NonNullGraphType<StringGraphType>>("hello")
      .Resolve(context => "Hello World from Chepén!");
  }
}
