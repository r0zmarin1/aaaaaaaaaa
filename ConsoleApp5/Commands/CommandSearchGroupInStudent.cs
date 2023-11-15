using ConsoleApp5.DB;

internal class CommandSearchGroupInStudent : CommandStudent
{
    private StudentGroupDB studentGroupDB;

    public CommandSearchGroupInStudent(StudentGroupDB studentGroupDB)
    {
        this.studentGroupDB = studentGroupDB;
    }
    public override void Execute()
    {
        Console.WriteLine("Поиск студента");
        Group groups = studentGroupDB.GetGroupByStudent(Console.ReadLine());
        Console.WriteLine($"{groups.Name}{groups.UID}");
    }
}