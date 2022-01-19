using MarsRover.Core.Entities;
using MarsRover.Core.Enums;
using MarsRover.Core.Helpers;
using MarsRover.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Service
{
    public class MissionService : IMissionService
    {
        private readonly IDirectionService _directionService;
        private readonly IMovementService _movementService;
        public MissionService(IDirectionService directionService, IMovementService movementService)
        {
            _directionService = directionService;
            _movementService = movementService;
        }

        public IEnumerable<Rover> ExecuteMission(string command)
        {
            var commands = CommandValidator.GetCommands(command);

            if (commands[0].command != CommandType.PleatueCommand)
                throw new ArgumentException("Wrong command for pleatue size");

            if (commands.Count < 3 || (commands.Count - 1) % 2 != 0)
                throw new ArgumentException("There is not enough command to execute mission");

            var pleatueParams = CommandValidator.GetPleatueParams(commands[0].commandTxt);

            var plateau = new Plateau(pleatueParams.width, pleatueParams.height);
            var roversAfterPath = new List<Rover>();
            var roverPaths = new List<RoverPath>();
            uint roverId = 1;
            for (int i = 1; i < commands.Count; i++)
            {
                var roverDeployCommand = commands[i];
                if (roverDeployCommand.command != CommandType.SetRoverCommand)
                    throw new ArgumentException("Wrong command for set rover");

                var roverParams = CommandValidator.GetRoverSetParams(roverDeployCommand.commandTxt);

                i++;

                var roverMoveCommand = commands[i];
                if (roverMoveCommand.command != CommandType.MoveRoverCommand)
                    throw new ArgumentException("Wrong command for move rover");

                var roverCommands = CommandValidator.GetRoverCommands(roverMoveCommand.commandTxt);
                var rover = new Rover(roverId, roverParams.x, roverParams.y, roverParams.direction);
                var roverPath = new RoverPath(rover, roverCommands);
                
                roverPaths.Add(roverPath);
                roverId += 1;
            }

            foreach (var item in roverPaths)
                roversAfterPath.Add(NavigatePath(plateau, item));

            return roversAfterPath;
        }

        private Rover NavigatePath(Plateau plateau,RoverPath roverPath)
        {
            var rover = roverPath.Rover;

            foreach(var item in roverPath.Commands)
            {
                if (item != Command.M)
                    rover.Direction = _directionService.GetNextDirection(roverPath.Rover.Direction, item);
                else
                    rover.Position = _movementService.GetNextPosition(roverPath.Rover.Position, roverPath.Rover.Direction);
            }

            if (rover.Position.X > plateau.Width || rover.Position.Y > plateau.Height)
                rover.Error = $"Rover {rover.Id} ({rover.Position.X},{rover.Position.Y}) position is out of plateau.";

            return rover;
        }
    }
}
