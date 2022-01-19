using MarsRover.Core.Attributes;

namespace MarsRover.Core.Enums
{
    public enum Direction
    {
        [DirectionIndex(0)]
        N,
        [DirectionIndex(1)]
        E,
        [DirectionIndex(2)]
        S,        
        [DirectionIndex(3)]
        W
    }
}
