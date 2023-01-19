using GraphQL;
using GraphQL.Types;
using School.GraphQL.Inputs;
using School.GraphQL.Types;
using School.Models;

namespace School.GraphQL;

public class ApiMutations : ObjectGraphType<object>
{
  public ApiMutations()
  {
    Field<StudentType>("addStudent")
      .Argument<NonNullGraphType<StudentInput>>("student")
      .Resolve(context =>
      {
        var person = context.GetArgument<Student>("student");
        return person;
      });
  }
}