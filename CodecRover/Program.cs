// See https://aka.ms/new-console-template for more information
using CodecRover;
using CodecRover.Core;
using CodecRover.Core.Environments;

Console.WriteLine("CodecRover is waiting for commands.");
Console.WriteLine("Enter 'quit' to exit");

bool userQuit = false;

Console.WriteLine("What are the world dimensions? (ex: 10x10)");
string dimensionInput = Console.ReadLine();

string[] dimensions = dimensionInput.Split('x');
SimpleGridWorld world = new SimpleGridWorld(int.Parse(dimensions[0]), int.Parse(dimensions[1]));
Rover rover = new Rover(world);


while (!userQuit)
{
    Console.WriteLine("Enter commands. L,R, or F, in sequence");
    Console.WriteLine("ex: LFFRFF");
    string input = Console.ReadLine();
    if (input == "quit")
    {
        userQuit = true;
    }
    else
    {
        List<Command> commands = InputInterpreter.ParseInput(input);
        foreach (Command c in commands)
        {

            switch (c)
            {
                case Command.TurnLeft:
                    rover.Rotate(TurnDirection.Left);
                    break;
                case Command.TurnRight:
                    rover.Rotate(TurnDirection.Right);
                    break;
                case Command.Advance:
                    rover.MoveForward();
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine($"{rover.CurrentPosition.X}, {rover.CurrentPosition.Y}, {rover.CurrentDirection.ToString()}");
    }
}
