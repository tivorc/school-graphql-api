using GraphQL.Types;
using School.Models;

namespace School.GraphQL.Types;

public class StudentType : ObjectGraphType<Student>
{
  public StudentType()
  {
    Field(x => x.Id);
    Field(x => x.Names);
    Field(x => x.Surname);
    Field<StringGraphType>("fullname")
      .Resolve(context => $"{context.Source.Names} {context.Source.Surname}");
    Field<DateGraphType>("dateOfBirth")
      .Resolve(context => context.Source.DateOfBirth);
    Field(x => x.Email, nullable: true);
  }
}
