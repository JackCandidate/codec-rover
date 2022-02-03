using CodecRover.Core;
using CodecRover.Core.Environments;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodecRover.Tests
{
    public class TestInterpreter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInput_FFF()
        {
            string input = "FFF";
            List<Command> commands = InputInterpreter.ParseInput(input);
            Assert.IsTrue(commands.TrueForAll(c => c == Command.Advance));
        }
        
        [Test]
        public void TestInput_LRF()
        {
            string input = "LRF";
            List<Command> commands = InputInterpreter.ParseInput(input);
            Assert.IsTrue(commands[0] == Command.TurnLeft &&
                commands[1] == Command.TurnRight &&
                commands[2] == Command.Advance);
        }
    }
}