class CommandManager
{
    Dictionary<string, CommandStudent> commands = new();
    public void Start()
    {
        string command;
        do
        {
            Console.WriteLine("Введите команду");
            command = Console.ReadLine();
            TestCommand(command);
        }
        while (command != "exit");

    }

    void TestCommand(string? command)
    {
        if (commands.ContainsKey(command))
        {
            commands[command].Execute();
        }
    }

    public void RegisterCommand(string command, CommandStudent commandStudent)
    {
        commands.Add(command, commandStudent);
    }
}
