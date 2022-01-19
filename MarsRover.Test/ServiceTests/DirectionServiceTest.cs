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
    public class DirectionServiceTest
    {

        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection()
               .AddSingleton<IDirectionService, DirectionService>()            
               .BuildServiceProvider();
        }

        [Test]
        [TestCase("E M E")]
        [TestCase("E R S")]
        [TestCase("S L E")]
        [TestCase("S R W")]
        [TestCase("N R E")]
        public void DirectionService_Should_Return_Correct_Values(string command)
        {
            var directionService = _serviceProvider.GetService<IDirectionService>();

            var commandItems = command.Split(' ');
            var currentDirection = commandItems[0].ToDirection();
            var directionCommand = commandItems[1].ToCommand();
            var expectedDirection = commandItems[2].ToDirection();

            var nextDirection = directionService.GetNextDirection(currentDirection, directionCommand);

            Assert.AreEqual(nextDirection, expectedDirection);
        }
    }
}
