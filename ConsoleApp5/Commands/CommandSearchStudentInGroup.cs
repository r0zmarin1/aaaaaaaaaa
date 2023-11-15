using ConsoleApp5.DB;

internal class CommandSearchStudentInGroup : CommandStudent
{
    private StudentGroupDB studentGroupDB;

    public CommandSearchStudentInGroup(StudentGroupDB studentGroupDB)
    {
        this.studentGroupDB = studentGroupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск группы");
        List<Student> students = studentGroupDB.GetStudentByGroup(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{students[i].LastName}{students[i].FirstName}{students[i].UID}");
        }
    }
}