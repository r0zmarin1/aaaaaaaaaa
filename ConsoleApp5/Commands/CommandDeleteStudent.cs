internal class CommandDeleteStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandDeleteStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента");
        List<Student> students = studentDB.Search(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{students[i]}");
            Console.WriteLine("Кого удалить?");
            int.TryParse(Console.ReadLine(), out int delete);
            if (students.Count > delete - 1)
            { 
            studentDB.Delete(students[i]);
            Console.WriteLine("Удален"); 
            }

            else
                Console.WriteLine("Такого нет");
        }

    }
}