using MarsRover.Core.Enums;
using MarsRover.Core.Helpers;
using MarsRover.Service.Interfaces;
using System;
using System.Linq;

namespace MarsRover.Service
{
    public class DirectionService : IDirectionService
    {
        public Direction GetNextDirection(Direction direction, Command command)
        {
            var enumValues = Enum.GetValues(typeof(Direction)).Cast<Direction>().OrderBy(c=>c.GetDirectionIndex()).ToArray();
            var currentIndex = Array.IndexOf(enumValues, direction);
            switch (command)
            {
                case Command.L:
                    return currentIndex == 0 ? Direction.W : enumValues[currentIndex - 1];
                case Command.R:
                    return currentIndex == 3 ? Direction.N : enumValues[currentIndex + 1];
                default:
                    return direction;
            }
        }
    }
}
