using ConsoleApp5.DB;

internal class CommandAddStudentInGroup : CommandStudent
{
    private StudentGroupDB studentGroupDB;

    public CommandAddStudentInGroup(StudentGroupDB studentGroupDB)
    {
        this.studentGroupDB = studentGroupDB;
    }
    
    public override void Execute()
    {
        Console.WriteLine("введите uid студента...");
        string uidS = Console.ReadLine();
        Console.WriteLine("введите uid группы...");
        string uidG = Console.ReadLine();
        if (studentGroupDB.Add(uidS, uidG))
            Console.WriteLine("Done!");
    }
}
