using FluentAssertions;
using MarsRover.Core.Entities;
using NUnit.Framework;
using System;
using MarsRover.Core.Enums;

namespace MarsRover.Test.EntityTests
{
    [TestFixture]
    public class RoverTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Rover_Should_Fire_Error_With_Given_Wrong_Id_Value()
        {
            Action act = () =>
            {
                var rover = new Rover(0, 0, 0,Direction.E);
            };

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
     

        [Test]
        public void Rover_Should_Initialize_Correctly_With_Given_Id_Values()
        {
            Action act = () =>
            {
                var rover = new Rover(1, 0, 0, Direction.E);
            };

            act.Should().NotThrow();            
        }

       
    }
}
