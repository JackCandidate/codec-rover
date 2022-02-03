using CodecRover.Core;
using CodecRover.Core.Environments;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodecRover.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMove()
        {
            SimpleGridWorld world = new SimpleGridWorld(5, 5);

            Rover rover = new Rover(world);
            rover.MoveForward();
            Assert.IsTrue(rover.CurrentPosition.X == 2 && rover.CurrentPosition.Y == 1);

        }

        [Test]
        public void TestBorder()
        {
            SimpleGridWorld world = new SimpleGridWorld(5, 5);
            Command[] commands = new Command[] { Command.TurnRight, Command.Advance, Command.Advance };
            Rover rover = new Rover(world);
            ExecuteCommands(commands, rover);

            Assert.IsTrue(rover.CurrentPosition.X == 1 && rover.CurrentPosition.Y == 1);
        }

        [Test]
        public void TestBorder_East()
        {
            SimpleGridWorld world = new SimpleGridWorld(2, 2);
            Command[] commands = new Command[] { Command.Advance, Command.Advance, Command.Advance };
            Rover rover = new Rover(world);

            ExecuteCommands(commands, rover);

            Assert.IsTrue(rover.CurrentPosition.X == 2 && rover.CurrentPosition.Y == 1);
        }

        [Test]
        public void TestTurn_North()
        {
            SimpleGridWorld world = new SimpleGridWorld(5, 5);
            Command[] commands = new Command[] { Command.TurnLeft, Command.Advance };
            Rover rover = new Rover(world);
            
            ExecuteCommands(commands, rover);

            Assert.IsTrue(rover.CurrentPosition.X == 1 && rover.CurrentPosition.Y == 2);
        }


        void ExecuteCommands(IEnumerable<Command> commands, Rover rover)
        {
            foreach (Command command in commands)
            {
                switch (command)
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
        }

    }
}