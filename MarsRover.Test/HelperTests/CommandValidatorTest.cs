using FluentAssertions;
using NUnit.Framework;
using System;
using MarsRover.Core.Enums;
using MarsRover.Core.Helpers;
using System.Linq;

namespace MarsRover.Test.HelperTests
{
    [TestFixture]
    public class CommandValidatorTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CommandValidator_Should_Fire_Error_With_Wrong_Command_Pattern()
        {
            Action actNullRover = () =>
            {
                CommandValidator.GetCommands("AB");
            };

            actNullRover.Should().Throw<ArgumentException>();
        }

        [Test]
        public void CommandValidator_Should_Fire_Error_With_Wrong_Command_Parameters()
        {
            Action actWrongPleatueCountParam = () =>
            {
                var pleatueParams = CommandValidator.GetPleatueParams("4 5 6");
            };

            Action actWrongPleatueParam = () =>
            {
                var pleatueParams=CommandValidator.GetPleatueParams("-4 0");
            };

            Action actWrongRoverCountParam = () =>
            {
                var pleatueParams = CommandValidator.GetRoverSetParams("4 3");
            };

            Action actWrongRoverParam = () =>
            {
                var pleatueParams = CommandValidator.GetRoverCommands("1 4 X");
            };



            actWrongPleatueCountParam.Should().Throw<ArgumentException>("Invalid parameters length for pleatue size");
            actWrongPleatueParam.Should().Throw<ArgumentException>("Width parameter is not correct for pleatue size");
            actWrongRoverCountParam.Should().Throw<ArgumentException>("Invalid parameters length for rover set");
            actWrongRoverParam.Should().Throw<ArgumentException>("Direction parameter is not correct value range");

           
        }

        [Test]
        public void CommandValidator_Should_Fire_No_Error_Return_Correct_Command_Pattern()
        {
            var pleatueCommand = CommandValidator.GetCommands("5 5").Single();
            var moveRoverCommand = CommandValidator.GetCommands("LMRMMRLLL").Single();
            var setRoverCommand = CommandValidator.GetCommands("1 4 E").Single();

            Assert.AreEqual(pleatueCommand.command,CommandType.PleatueCommand );
            Assert.AreEqual(moveRoverCommand.command, CommandType.MoveRoverCommand);
            Assert.AreEqual(setRoverCommand.command, CommandType.SetRoverCommand);
        }



        [Test]

        public void CommandValidator_Should_Fire_No_Error_Return_Correct_Command_Parameters()
        {
            var pleatueParams = CommandValidator.GetPleatueParams("5 5");
            var moveRoverParams = CommandValidator.GetRoverCommands("LMRMMRLLL");
            var setRoverParams = CommandValidator.GetRoverSetParams("1 4 E");            

            Assert.AreEqual(pleatueParams.width,5);
            Assert.AreEqual(pleatueParams.height, 5);
            Assert.AreEqual(moveRoverParams.Count, 9);
            Assert.AreEqual(moveRoverParams.First(), Command.L);
            Assert.AreEqual(setRoverParams.direction, Direction.E);
            Assert.AreEqual(setRoverParams.x, 1);
            Assert.AreEqual(setRoverParams.y, 4);
        }
    }
}
