using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Utility
{
    [Flags]
    enum CommandsTable
    {
        None,
        Remove,
        In,
        Out,
    }

    class Command
    {
        public CommandsTable command;
        public List<string> parameters;

        public void ExtractParameters(ref int index , string [] args)
        {
            parameters = new List<string>();

            switch (command)
            {
                case CommandsTable.None:
                    break;
                case CommandsTable.Remove:
                    index++;
                    parameters.Add(args[index]);
                    index++;
                    parameters.Add(args[index]);
                    break;
                case CommandsTable.In:
                    index++;
                    parameters.Add(args[index]);
                    break;
                case CommandsTable.Out:
                    index++;
                    parameters.Add(args[index]);
                    break;
                default:
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Not Input Argumnets");
                return;
            }

            var arguments = ConvertLowerCase(args);
            var comands = ProcessArguments(arguments);

            if (comands.Count == 0)
                return;

            
        }

        static List<Command> ProcessArguments(string[] args)
        {
            var commands = new List<Command>();
            CommandsTable comandType;

            for (var i = 0; i < args.Length; i++)
            {
                if (Enum.TryParse<CommandsTable>(args[i], out comandType))
                {
                    var newComand = new Command();
                    newComand.command = comandType;
                    newComand.ExtractParameters(ref i, args);

                    commands.Add(newComand);
                }
                else
                {
                    Console.WriteLine("invalide arguments");
                    break;
                }
            }

            return commands;
        }

        static string[] ConvertLowerCase(string[] args)
        {
            var newArgs = new string[args.Length];

            for (var i = 0; i < args.Length; i++)
                newArgs[i] = args[i].ToLower();

            return newArgs;
        }
    }



}
