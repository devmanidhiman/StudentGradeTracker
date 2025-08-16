using System.Runtime.CompilerServices;

namespace StudentGraderApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var manager = new StudentManager();
            manager.SeedMockStudent();
            RunMenu(manager);
        }

        private static string NameValidation()
        {
            Console.Write("Name: ");
            var nameInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nameInput))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            return nameInput.Trim();
        }

        private static double GradeValidation()
        {
            Console.Write("Grade: ");
            var gradeInput = Console.ReadLine();

            if (!double.TryParse(gradeInput, out double grade))
            {
                throw new ArgumentException("Grade must be a valid number");
            }
            return grade;
        }

        private static void RunMenu(StudentManager manager)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Find Student");
                Console.WriteLine("4. Update Grade");
                Console.WriteLine("5. Get All Student");
                Console.WriteLine("6. Exit");

                if (!int.TryParse(Console.ReadLine(), out int numChoice)
                || !Enum.IsDefined(typeof(MenuOption), numChoice))
                {
                    Console.WriteLine("Invalid Choice");
                    continue;
                }
                var choice = (MenuOption)numChoice;
                switch (choice)
                {
                    case MenuOption.AddStudent:
                        try
                        {
                            var name = NameValidation();
                            var grade = GradeValidation();
                            var student = new Student(name, grade);

                            manager.AddStudent(student);
                            Console.WriteLine("Student added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case MenuOption.RemoveStudent:
                        try
                        {
                            var removeName = NameValidation();
                            manager.RemoveStudent(removeName);
                            Console.WriteLine("Student removed successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case MenuOption.FindStudent:
                        try
                        {
                            var findName = NameValidation();
                            var student = manager.FindStudent(findName);
                            if (student != null)
                            {
                                Console.WriteLine($"Found: {student.Name}, Grade: {student.Grade}");
                            }
                            else
                            {
                                Console.WriteLine("Student not found");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case MenuOption.UpdateGrade:
                        try
                        {
                            var updateName = NameValidation();
                            var updateGrade = GradeValidation();
                            manager.UpdateGrade(updateName, updateGrade);
                            Console.WriteLine("Grade updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case MenuOption.GetAllStudents:
                        var studentList = manager.GetAllStudents();
                        if (studentList.Count == 0)
                        {
                            Console.WriteLine("No Student to display.");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent Report:");
                            Console.WriteLine("---------------");
                            foreach (var student in studentList)
                            {
                                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
                            }
                        }
                        break;
                    case MenuOption.Exit:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            }
        }
    }
}
