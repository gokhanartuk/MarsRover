using MarsRover.Core.Enums;
using System;

namespace MarsRover.Core.Helpers
{
    public static class StringExtensions
    {
        public static Command ToCommand(this string command)
        {            
            if (string.Equals(command, "L", StringComparison.OrdinalIgnoreCase))
                return Command.L;
            if (string.Equals(command, "R", StringComparison.OrdinalIgnoreCase))
                return Command.R;
            if (string.Equals(command, "M", StringComparison.OrdinalIgnoreCase))
                return Command.M;
            throw new ArgumentOutOfRangeException("Command parameter is not correct value range");           
        }

        public static Direction ToDirection(this string direction)
        {            
            if (string.Equals(direction, "N", StringComparison.OrdinalIgnoreCase))
                return Direction.N;
            if (string.Equals(direction, "S", StringComparison.OrdinalIgnoreCase))
                return Direction.S;
            if (string.Equals(direction, "E", StringComparison.OrdinalIgnoreCase))
                return Direction.E;
            if (string.Equals(direction, "W", StringComparison.OrdinalIgnoreCase))
                return Direction.W;
            throw new ArgumentOutOfRangeException("Direction parameter is not correct value range");
        }

    }
}
