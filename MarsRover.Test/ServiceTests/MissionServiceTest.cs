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
    public class MissionServiceTest
    {
        private const char CommandLineSeperator = '\r';
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection()
               .AddSingleton<IDirectionService, DirectionService>()
               .AddSingleton<IMovementService, MovementService>()
               .AddSingleton<IMissionService, MissionService>()
               .BuildServiceProvider();
        }

        [Test]
        [TestCase("A A\r3 3 N\rMMMM")]
        public void Movement_Should_Fire_Error_With_Wrong_Input_Parameter(string command)
        {

            Action actionWrongParameters = () =>
            {
                var missionService = _serviceProvider.GetService<IMissionService>();
                var rovers = missionService.ExecuteMission(command).ToArray();
            };

            actionWrongParameters.Should().Throw<ArgumentException>();
         
        }


        [Test]
        [TestCase("5 5\r1 2 N\rLMLMLMLMM\r3 3 E\rMMRMMRMRRM", "1 3 N\r5 1 E")]
        [TestCase("5 5\r2 2 E\rLLLRM\r4 1 S\rMRRRM", "1 2 W\r5 0 E")]
        public void MovementService_Should_Return_Correct_Values(string command, string result)
        {
            var missionService = _serviceProvider.GetService<IMissionService>();
            var rovers = missionService.ExecuteMission(command).ToArray();

            var results = result.Split(CommandLineSeperator);

            for (int i = 0; i < results.Count(); i++)
            {
                Assert.AreEqual(results[i], rovers[i].ToString());
            }
        }

        [Test]
        [TestCase("5 5\r3 3 N\rMMMM\r2 1 E\rMMMM")]
        public void MovementService_Should_Calculate_Out_Of_Grid_Status(string command)
        {
            var missionService = _serviceProvider.GetService<IMissionService>();
            var rovers = missionService.ExecuteMission(command).ToArray();

            foreach (var item in rovers)
            {
                Assert.AreEqual(true, item.HasError);
            }
        }             
    }
}
