namespace School.Models;

public class Student : Person
{
  public Student(Guid id, string names, string surname, DateTime dateOfBirth) : base(id, names, surname, dateOfBirth)
  {
  }
}
