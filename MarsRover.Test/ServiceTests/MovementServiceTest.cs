using FluentAssertions;
using NUnit.Framework;
using System;
using MarsRover.Core.Enums;
using MarsRover.Core.Helpers;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MarsRover.Service.Interfaces;
using MarsRover.Service;

namespace MarsRover.Test.ServiceTests
{
    [TestFixture]
    public class MovementServiceTest
    {

        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection()
               .AddSingleton<IMovementService, MovementService>()            
               .BuildServiceProvider();
        }

        [Test]
        [TestCase("1 3 E 2 3")]
        [TestCase("4 2 N 4 3")]
        [TestCase("4 3 S 4 2")]
        [TestCase("1 1 W 0 1")]        
        public void MovementService_Should_Return_Correct_Values(string command)
        {
            var movementService = _serviceProvider.GetService<IMovementService>();

            var commandItems = command.Split(' ');
            var currentX = Convert.ToUInt32(commandItems[0]);
            var currentY = Convert.ToUInt32(commandItems[1]);
            var direction = commandItems[2].ToDirection();
            var expectedPosX = Convert.ToUInt32(commandItems[3]);
            var expectedPosY = Convert.ToUInt32(commandItems[4]);

            var nextPosisiton = movementService.GetNextPosition((currentX, currentY), direction);

            Assert.AreEqual(expectedPosX, nextPosisiton.X);
            Assert.AreEqual(expectedPosY, nextPosisiton.Y);
        }
    }
}
