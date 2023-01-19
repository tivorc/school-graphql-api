namespace School.Models;

public class Student : Person
{
  public Student(Guid id, string name, string surname, DateTime dateOfBirth) : base(id, name, surname, dateOfBirth)
  {
  }

  public static IEnumerable<Student> GetList() {
    return new List<Student>
    {
      new Student(Guid.NewGuid(), "John", "Gonzales", new DateTime(1998, 3, 29)),
      new Student(Guid.NewGuid(), "Jane", "Doe", new DateTime(1994, 10, 13)),
      new Student(Guid.NewGuid(), "Sandra", "Smith", new DateTime(1992, 10, 1)),
      new Student(Guid.NewGuid(), "Tim", "Paz", new DateTime(1999, 1, 12)),
    };
  }
}
