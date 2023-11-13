internal class CommandEditStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandEditStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента");
        List<Student> students = studentDB.Search(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{students[i].LastName}{students[i].FirstName}{students[i].UID}");
            Console.WriteLine("Кого отредактировать?");
            int.TryParse(Console.ReadLine(), out int edit);
            if ((students.Count > edit - 1))
            {
                Console.WriteLine("Укажите имя...");
                students[i].FirstName = Console.ReadLine();
                Console.WriteLine("Укажите фамилию...");
                students[i].LastName = Console.ReadLine();
                if (studentDB.Update(students[i]))
                    Console.WriteLine("Студент переименован!");
            }
            else
                Console.WriteLine("Такого нет");
        }
    }
}
