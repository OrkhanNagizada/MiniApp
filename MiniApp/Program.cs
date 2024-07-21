using MiniApp.Helpers;
using MiniApp;

static List<Classroom> classrooms = new List<Classroom>();

public static void Main(string[] args)
{
    while (true)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Create Classroom");
        Console.WriteLine("2. Create Student");
        Console.WriteLine("3. Display All Students");
        Console.WriteLine("4. Display Students in Selected Classroom");
        Console.WriteLine("5. Delete Student by ID");
        Console.WriteLine("6. Exit");

        Console.Write("Enter your choice: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        switch (choice)
        {
            case 1:
                CreateClassroom();
                break;
            case 2:
                CreateStudent();
                break;
            case 3:
                DisplayAllStudents();
                break;
            case 4:
                DisplayStudentsByClassroom();
                break;
            case 5:
                DeleteStudent();
                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 6.");
                break;
        }
    }
}

static void CreateClassroom()
{
    Console.Write("Enter classroom name: ");
    string name = Console.ReadLine();

    Console.Write("Enter classroom type (Backend or FrontEnd): ");
    if (!Enum.TryParse<ClassType>(Console.ReadLine(), out ClassType type))
    {
        Console.WriteLine("Invalid class type. Please enter Backend or FrontEnd.");
        return;
    }

    Classroom classroom = new Classroom(name, type);
    classrooms.Add(classroom);
    Console.WriteLine($"Classroom '{name}' created successfully.");
}

static void CreateStudent()
{
    Console.Write("Enter student name: ");
    string name = Console.ReadLine();

    Console.Write("Enter student surname: ");
    string surname = Console.ReadLine();

    Console.Write("Enter classroom ID to add the student to: ");
    if (!int.TryParse(Console.ReadLine(), out int classroomId))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        return;
    }

    var classroom = classrooms.FirstOrDefault(c => c.Id == classroomId);
    if (classroom == null)
    {
        Console.WriteLine("Classroom not found.");
        return;
    }

    try
    {
        Student student = new Student(classroom.Students.Count + 1, name, surname);
        classroom.AddStudent(student);
        Console.WriteLine($"Student '{name} {surname}' added to classroom '{classroom.Name}' successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void DisplayAllStudents()
{
    foreach (var classroom in classrooms)
    {
        classroom.DisplayAllStudents();
    }
}

static void DisplayStudentsByClassroom()
{
    Console.Write("Enter classroom ID to display students: ");
    if (!int.TryParse(Console.ReadLine(), out int classroomId))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        return;
    }

    var classroom = classrooms.FirstOrDefault(c => c.Id == classroomId);
    if (classroom == null)
    {
        Console.WriteLine("Classroom not found.");
        return;
    }

    classroom.DisplayStudentsByClassType();
}

static void DeleteStudent()
{
    Console.Write("Enter student ID to delete: ");
    if (!int.TryParse(Console.ReadLine(), out int studentId))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        return;
    }

    foreach (var classroom in classrooms)
    {
        try
        {
            classroom.DeleteStudentById(studentId);
            Console.WriteLine($"Student with ID {studentId} deleted successfully.");
            return;
        }
        catch (StudentNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    Console.WriteLine($"Student with ID {studentId} not found.");
}