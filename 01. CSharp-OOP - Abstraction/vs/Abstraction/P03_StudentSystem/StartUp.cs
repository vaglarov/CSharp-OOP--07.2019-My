namespace P03_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            CommandParser commandParser = new CommandParser();
            StudentSystem studentSystem = new StudentSystem();
            ConsoleDataReader dataReader = new ConsoleDataReader();
            ConsoleDataWriter dataWriter = new ConsoleDataWriter();

            Engine engine = new Engine(
                commandParser,
                studentSystem,
                dataReader,
                dataWriter);
            engine.Run();
        }
    }
}
