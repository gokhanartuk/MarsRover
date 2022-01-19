using FluentAssertions;
using NUnit.Framework;
using System;
using MarsRover.Core.Enums;
using MarsRover.Core.Helpers;
using System.Linq;

namespace MarsRover.Test.HelperTests
{
    [TestFixture]
    public class StringExtensionTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("A")]
        [TestCase("AB")]
        [TestCase("C")]
        public void StringExtensions_Should_Fire_Error_With_Wrong_Command_Parameter(string command)
        {
            Action actNullRover = () =>
            {
                command.ToCommand();
            };

            actNullRover.Should().Throw<ArgumentOutOfRangeException>("Command parameter is not correct value range");
        }

        [Test]
        [TestCase("A")]
        [TestCase("AB")]
        [TestCase("C")]
        public void StringExtensions_Should_Fire_Error_With_Wrong_Direction_Parameter(string direction)
        {
            Action actNullRover = () =>
            {
                direction.ToDirection();
            };

            actNullRover.Should().Throw<ArgumentOutOfRangeException>("Direction parameter is not correct value range");
        }

        [Test]
        [TestCase("L")]
        [TestCase("M")]
        [TestCase("R")]
        public void StringExtensions_Should_Fire_No_Error_Return_Correct_Command_Parameter(string command)
        {
            var cmdResult=command.ToCommand();

            Assert.AreEqual(typeof(Command), cmdResult.GetType());
        }

        [Test]
        [TestCase("N")]
        [TestCase("E")]
        [TestCase("W")]
        [TestCase("S")]
        public void StringExtensions_Should_Fire_No_Error_Return_Correct_Direction_Parameter(string direction)
        {
            var directionResult = direction.ToDirection();

            Assert.AreEqual(typeof(Direction), directionResult.GetType());
        }
    }
}
