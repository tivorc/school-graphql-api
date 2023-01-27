namespace School.Models;

public class Person
{
  public Guid Id { get; set; }
  public string Names { get; set; }
  public string Surname { get; set; }
  public DateTime DateOfBirth { get; set; }
  public string? Email { get; set; }

  public Person(Guid id, string names, string surname, DateTime dateOfBirth)
  {
    Id = id;
    Names = names;
    Surname = surname;
    DateOfBirth = dateOfBirth;
  }
}
