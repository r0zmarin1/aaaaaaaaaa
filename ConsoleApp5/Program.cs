using ConsoleApp5.DB;
using System.Xml.Linq;

class Program
{
    public static void Main()
    { 
        CommandManager commandManager = new CommandManager();
        StudentDB studentDB = new StudentDB();
        GroupDB groupDB = new GroupDB();
        commandManager.RegisterCommand("Create s", new CommandCreateStudent(studentDB));
        commandManager.RegisterCommand("Search s", new CommandSearchStudent(studentDB));
        commandManager.RegisterCommand("Delete s", new CommandDeleteStudent(studentDB));
        commandManager.RegisterCommand("Edit s", new CommandEditStudent(studentDB));
        commandManager.RegisterCommand("Create g", new CommandCreateGroup(groupDB));
        commandManager.RegisterCommand("Search g", new CommandSearchGroup(groupDB));
        commandManager.RegisterCommand("Delete g", new CommandDeleteGroup(groupDB));
        commandManager.RegisterCommand("Edit g", new CommandEditGroup(groupDB));
        // добавить команды:
        // Search - поиск студентов по имени/фамилии, должен выводиться UID
        // Delete - удаление выбранного студента (по UID или порядковому номеру в выведенном списке)
        // Edit - редактирование выбранного студента
        commandManager.Start();
    }

}
