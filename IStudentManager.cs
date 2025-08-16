namespace StudentGraderApp
{
    public interface IStudentManager
    {
        bool AddStudent(Student student);
        bool RemoveStudent(string name);
        Student? FindStudent(string name);
        bool UpdateGrade(string name, double updatedGrade);
        IReadOnlyList<Student> GetAllStudents(bool sortByName);
    }
}