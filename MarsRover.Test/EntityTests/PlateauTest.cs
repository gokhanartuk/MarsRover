using FluentAssertions;
using MarsRover.Core.Entities;
using NUnit.Framework;
using System;

namespace MarsRover.Test.EntityTests
{
    [TestFixture]
    public class PlateauTest
    {        
        [SetUp]
        public void Setup()
        {
        }
          
        [Test]
        public void Plateau_Should_Fire_Error_With_Given_Wrong_Width_Value()
        {
            Action act = () =>
            {
                var plateau = new Plateau(0, 1);
            };

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Plateau_Should_Fire_Error_With_Given_Wrong_Height_Value()
        {
            Action act = () =>
            {
                var plateau = new Plateau(1, 0);
            };

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Plateau_Should_Initialize_Correctly_With_Given_Values()
        {
            Action act = () =>
            {
                var plateau = new Plateau(4, 5);
            };
            act.Should().NotThrow();
        }

        [Test]
        [TestCase("5 10")]
        public void Plateau_Should_Initialize_Correctly_With_Given_Values(string sizeValues)
        {
            var sizes = sizeValues.Split(" ");
            uint width, height;
            uint.TryParse(sizes[0],out width);
            uint.TryParse(sizes[1],out height);

            var plateau = new Plateau(width, height);
            Assert.AreEqual(plateau.Width, width);
            Assert.AreEqual(plateau.Height, height);
        }
    }
}