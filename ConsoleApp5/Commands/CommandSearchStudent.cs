internal class CommandSearchStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandSearchStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента");
        List <Student> students = studentDB.Search(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{students[i].LastName}{students[i].FirstName}{students[i].UID}");
        }
    }
}