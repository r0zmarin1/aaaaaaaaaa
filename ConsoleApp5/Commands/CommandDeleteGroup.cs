using ConsoleApp5.DB;

internal class CommandDeleteGroup : CommandStudent
{
    private GroupDB groupDB;

    public CommandDeleteGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск группы");
        List<Group> groups = groupDB.Search(Console.ReadLine());
        for (int i = 0; i < groups.Count; i++)
        {
            Console.WriteLine($"{groups[i]}");
            Console.WriteLine("Кого удалить?");
            int.TryParse(Console.ReadLine(), out int delete);
            if ((groups.Count > delete - 1))
            {
                groupDB.Delete(groups[i]);
                Console.WriteLine("Удалена");
            }

            else
                Console.WriteLine("Таких нет");
        }

    }
}