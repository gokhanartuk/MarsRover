using MarsRover.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover.Core.Helpers
{
    public static class CommandValidator
    {
        private const char CommandLineSeperator = '\r';
        private const string NewLineSeperator = "\n";
        private const char CommandSeperator = ' ';

        private static readonly Regex PlateauSizeRegex = new Regex("^\\d+ \\d+$");
        private static readonly Regex MovementCommandRegex = new Regex("^[LMR]+$");
        private static readonly Regex SetDirectionRegex = new Regex("^\\d+ \\d+ [NSWE]$");                

        private static CommandType GetCommandType(string command)
        {
            if (PlateauSizeRegex.IsMatch(command)) return CommandType.PleatueCommand;
            if (MovementCommandRegex.IsMatch(command)) return CommandType.MoveRoverCommand;
            if (SetDirectionRegex.IsMatch(command)) return CommandType.SetRoverCommand;
            throw new ArgumentException($"{command} Command is not correct format");
        }

        public static List<(CommandType command,string commandTxt)> GetCommands(string command)
        {
            if (string.IsNullOrEmpty(command?.Trim())) throw new ArgumentNullException("Commands cannot be empty or null");

            var result = new List<(CommandType, string)>();            
            var lines = command.Trim().Split(CommandLineSeperator);
            
            foreach(var item in lines)
            {
                result.Add((GetCommandType(item.Replace(NewLineSeperator, "")), item.Replace(NewLineSeperator, "")));
            }
            return result;
        }

        public static (uint width, uint height) GetPleatueParams(string commandValue)
        {
            var pleatueParams = commandValue.Split(CommandSeperator);
            if (pleatueParams.Length != 2)
                throw new ArgumentException("Invalid parameters length for pleatue size");

            uint width, height;

            if (!uint.TryParse(pleatueParams[0], out width))
                throw new ArgumentException("Width parameter is not correct for pleatue size");
            if (!uint.TryParse(pleatueParams[1], out height))
                throw new ArgumentException("Height parameter is not correct for pleatue size");

            return (width, height);
        }
        public static (uint x, uint y,Direction direction) GetRoverSetParams(string commandValue)
        {
            var roverParameters = commandValue.Split(' ');
            if (roverParameters.Length != 3)
                throw new ArgumentException("Invalid parameters length for rover set");

            uint x, y;
            

            if (!uint.TryParse(roverParameters[0], out x))
                throw new ArgumentException("X parameter is not correct for rover");
            if (!uint.TryParse(roverParameters[1], out y))
                throw new ArgumentException("Y parameter is not correct for rover");

            var direction = roverParameters[2].ToDirection();                

            return (x, y, direction);
        }

        public static List<Command> GetRoverCommands(string commandValue)
        {
            var commands = new List<Command>();
            foreach(char c in commandValue)
            {                
                commands.Add(c.ToString().ToCommand());
            }
            return commands;
        }
    }
}
