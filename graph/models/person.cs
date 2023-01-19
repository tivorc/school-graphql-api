namespace School.Models;

public class Person
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Surname { get; set; }
  public DateTime DateOfBirth { get; set; }
  public string? Email { get; set; }

  public Person(Guid id, string name, string surname, DateTime dateOfBirth)
  {
    Id = id;
    Name = name;
    Surname = surname;
    DateOfBirth = dateOfBirth;
  }
}
