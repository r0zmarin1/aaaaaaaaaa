class CommandCreateStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandCreateStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Создание студента...");
        Student newStudent = studentDB.Create();
        Console.WriteLine("Укажите имя...");
        newStudent.FirstName = Console.ReadLine();
        Console.WriteLine("Укажите фамилию...");
        newStudent.LastName = Console.ReadLine();
        if (studentDB.Update(newStudent))
            Console.WriteLine("Студент создан!");
        else
            Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
    }
}
