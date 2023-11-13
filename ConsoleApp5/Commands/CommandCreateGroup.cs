using ConsoleApp5.DB;

internal class CommandCreateGroup : CommandStudent
{
    private GroupDB groupDB;

    public CommandCreateGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Создание группы...");
        Group newGroup = groupDB.Create();
        Console.WriteLine("Укажите имя...");
        newGroup.Name = Console.ReadLine();
        if (groupDB.Update(newGroup))
            Console.WriteLine("Группа создана!");
        else
            Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
    }
}