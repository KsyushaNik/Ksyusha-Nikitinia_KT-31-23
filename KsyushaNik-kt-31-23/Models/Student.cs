using System.Text.RegularExpressions;

namespace KsyushaNik_kt_31_23.Models;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}