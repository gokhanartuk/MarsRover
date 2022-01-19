using FluentAssertions;
using MarsRover.Core.Entities;
using NUnit.Framework;
using System;
using MarsRover.Core.Enums;
using System.Collections.Generic;

namespace MarsRover.Test.EntityTests
{
    [TestFixture]
    public class RoverPathTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoverPath__Should_Fire_Error_With_Given_Wrong_Width_Value()
        {
            Action actNullRover = () =>
            {
                var rover = new RoverPath(null, new List<Command>() { Command.L });
            };

            Action actNullCommand = () =>
            {
                var rover = new RoverPath(new Rover(1,0,0,Direction.E), new List<Command>());
            };

            Action actEmptyCommand = () =>
            {
                var rover = new RoverPath(new Rover(1, 0, 0, Direction.E), new List<Command>());
            };

            actNullRover.Should().Throw<NullReferenceException>();
            actNullCommand.Should().Throw<NullReferenceException>();
            actEmptyCommand.Should().Throw<NullReferenceException>();
        }
     

        [Test]
        public void RoverPath_Should_Initialize_Correctly_With_Given_Values()
        {
            Action act = () =>
            {
                var rover = new RoverPath(new Rover(1, 0, 0, Direction.E), new List<Command>() { Command.L });
            };

            act.Should().NotThrow();            
        }

       
    }
}
