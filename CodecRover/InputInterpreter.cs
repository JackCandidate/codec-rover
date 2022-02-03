using CodecRover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecRover
{
    public static class InputInterpreter
    {

        public static List<Command> ParseInput(string input)
        {
            List<Command> commands = new List<Command>();
            foreach (var c in input.ToLower().ToCharArray())
            {
                commands.Add(GetCommand(c));
            }
            return commands;
        }

        static Command GetCommand(char c)
        {
            switch (c)
            {
                case 'l':
                    return Command.TurnLeft;
                    break;
                case 'r':
                    return Command.TurnRight;
                    break;
                case 'f':
                    return Command.Advance;
                    break;
                default: throw new ArgumentException("Invalid input");
            }
        }
    }
}
