using ConsoleApp5.DB;

internal class CommandEditGroup : CommandStudent
{
    private GroupDB groupDB;

    public CommandEditGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск группы");
        List<Group> groups = groupDB.Search(Console.ReadLine());
        for (int i = 0; i < groups.Count; i++)
        {
            Console.WriteLine($"{groups[i].Name}{groups[i].UID}");
            Console.WriteLine("Кого отредактировать?");
            int.TryParse(Console.ReadLine(), out int edit);
            if ((groups.Count > edit - 1))
            {
                Console.WriteLine("Укажите имя...");
                groups[i].Name = Console.ReadLine();
                if (groupDB.Update(groups[i]))
                    Console.WriteLine("Группа переименована!");
            }
            else
                Console.WriteLine("Таких нет");
        }
    }
}