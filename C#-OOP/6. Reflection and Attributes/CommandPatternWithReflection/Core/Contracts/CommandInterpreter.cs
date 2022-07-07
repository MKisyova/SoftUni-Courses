using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandInfo = args.Split();

            string commandName = $"{commandInfo[0]}Command";

            Type commandType = Assembly.GetCallingAssembly().GetTypes()
                .Where(x => x.Name == commandName).FirstOrDefault();

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command name");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string result = command.Execute(commandInfo.Skip(1).ToArray());

            return result;
        }
    }
}
