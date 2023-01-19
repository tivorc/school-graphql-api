using GraphQL.Types;

namespace School.GraphQL.Inputs;
public class StudentInput : InputObjectGraphType
{
  public StudentInput()
  {
    Name = "PersonInput";
    Field<NonNullGraphType<IdGraphType>>("id");
    Field<NonNullGraphType<StringGraphType>>("name");
    Field<NonNullGraphType<StringGraphType>>("surname");
    Field<NonNullGraphType<DateGraphType>>("dateOfBirth");
    Field<StringGraphType>("email");
  }
}
