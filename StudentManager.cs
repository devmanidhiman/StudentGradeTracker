using StudentGraderApp;

public class StudentManager() : IStudentManager
{
    private readonly List<Student> _students = new();

    public bool AddStudent(Student student)
    {
        if (_students.Any(s => s.Name.Equals(student.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }
        _students.Add(student);
        return true;
    }

    public bool RemoveStudent(string name)
    {
        var student = _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return student != null && _students.Remove(student);
    }

    public Student? FindStudent(string name)
    {
        return _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public bool UpdateGrade(string name, double updatedGrade)
    {
        var student = FindStudent(name);
        if (student == null) return false;
        student.Grade = updatedGrade;
        return true;
    }

    public List<Student> GetSorted_students()
    {
        return _students.OrderByDescending(s => s.Grade).ToList();
    }

    public double AverageGrade()
    {
        return _students.Any() ? _students.Average(s => s.Grade) : 0;
    }

    public IReadOnlyList<Student> GetAllStudents(bool sortByName = false)
    {
        return sortByName ? new List<Student>(_students.OrderBy(s => s.Name)).AsReadOnly() : _students.AsReadOnly();
    }

    public void SeedMockStudent()
    {
        _students.AddRange(new List<Student>
        {
            new Student("Aarav Mehta", 88.5),
            new Student("Zoya Khan", 92.0),
            new Student("Rohan Verma", 76.3),
            new Student("Isha Patel", 89.9),
            new Student("Kabir Sharma", 65.0),
            new Student("Meera Joshi", 91.2),
            new Student("Dev Dhiman", 100.0),
            new Student("Anaya Singh", 59.9),
            new Student("Tanishq Rao", 85.0),
            new Student("Nisha Bhatia", 72.4)

        });
    }
}