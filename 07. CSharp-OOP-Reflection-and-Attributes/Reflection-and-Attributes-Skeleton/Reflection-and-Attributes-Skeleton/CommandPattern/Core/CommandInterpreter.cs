using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public string Read(string args)
        {
            string[] cmdTokens = args
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            string commandName = cmdTokens[0] + COMMAND_POSTFIX;

            string[] commandARGS = cmdTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();
            Type typeToCreate = types.FirstOrDefault(x => x.Name == commandName);

            //if (typeToCreate == null)
            //{
            //    throw new InvalidOperationException("Invalid Command Type!");
            //}

            Object instace = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instace;
            string result = command.Execute(commandARGS);
            return result;
        }
    }
}
