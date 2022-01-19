using MarsRover.Service;
using MarsRover.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddScoped<IDirectionService, DirectionService>();
            serviceCollection.AddScoped<IMovementService, MovementService>();
            serviceCollection.AddScoped<IMissionService, MissionService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

          
            Console.WriteLine("Please enter the commands:");

            // Read user input lines
            var command = "";
            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                command += line + Environment.NewLine;
            }

            var missionService = serviceProvider.GetService<IMissionService>();

            try
            {
                var rovers = missionService.ExecuteMission(command);
                foreach (var rover in rovers)
                    Console.WriteLine(rover.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error executing mission: {e.Message}");
            }
                        
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
