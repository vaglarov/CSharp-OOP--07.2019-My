namespace P03_StudentSystem
{
using System.Collections.Generic;
using System.Text;
    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;

        private IDataReader consoleDataReader;
        private IDataWriter consoleDataWriter;
        public Engine(
            CommandParser commandParser,
            StudentSystem studentSystem,
            IDataReader consoleDataReader,
            IDataWriter consoleDataWriter)
        {
            this.commandParser= commandParser;
            this.studentSystem= studentSystem;
            this.consoleDataReader = consoleDataReader;
            this.consoleDataWriter = consoleDataWriter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var data = this.consoleDataReader.Read();
                    var command = commandParser.Parse(data);
                    if (command.Name == "Create")
                    {
                        var name = command.Arguments[0];
                        var age = int.Parse(command.Arguments[1]);
                        var grade = double.Parse(command.Arguments[2]);

                        studentSystem.Add(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        var name = command.Arguments[0];
                        var currentStudent = studentSystem.Get(name);
                        this.consoleDataWriter.Write(currentStudent);
                    }
                    else if (command.Name == "Exit")
                    {
                        break;
                    }
                }
                catch
                {

                    continue;
                }


            }
        }
    }
}
