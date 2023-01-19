using GraphQL.Types;
using School.Models;

namespace School.GraphQL.Types;

public class StudentType : ObjectGraphType<Student>
{
  public StudentType()
  {
    Field(x => x.Id);
    Field(x => x.Name);
    Field(x => x.Surname);
    Field<StringGraphType>("fullname")
      .Resolve(context => $"{context.Source.Name} {context.Source.Surname}");
    Field<DateGraphType>("dateOfBirth")
      .Resolve(context => context.Source.DateOfBirth);
    Field(x => x.Email, nullable: true);
  }
}
