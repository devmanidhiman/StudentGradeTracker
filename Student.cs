public class Student
{

    private string _name = string.Empty;
    private double _grade = -1;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            _name = value;
        }
    }
    public double Grade
    {
        get => _grade;

        set
        {
            if (value == -1)
            {
                throw new ArgumentException("Grade Cannot be empty");
            }
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Grade must be between 0 and 100.");
            }
            _grade = value; 
        }
    }

    public Student(string name, double grade)
    {
        Name = name;
        Grade = grade;
    }

}