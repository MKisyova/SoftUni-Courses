using System;
using System.Linq;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandInfo = args.Split();

            string commandName = $"{commandInfo[0]}Command";
            
            ICommand command = null;
            string result = null;

            if (commandName == nameof(HelloCommand))
            {
                command = new HelloCommand();
            }

            else if (commandName == "Exit")
            {
                command = new ExitCommand();
            }

            else
            {
                throw new InvalidOperationException("Invalid command name");
            }

            result = command.Execute(commandInfo.Skip(1).ToArray());
            return result;
        }
    }
}
