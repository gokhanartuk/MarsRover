using MarsRover.Core.Enums;
using MarsRover.Service.Interfaces;

namespace MarsRover.Service
{
    public class MovementService : IMovementService
    {
        private const int MoveSize = 1;
        public (uint X, uint Y) GetNextPosition((uint X, uint Y) currentPos, Direction moveDirection)
        {
            switch (moveDirection)
            {
                case Direction.N:
                    return (currentPos.X, currentPos.Y + MoveSize);
                case Direction.S:
                    return (currentPos.X, currentPos.Y - MoveSize);
                case Direction.E:
                    return (currentPos.X + MoveSize, currentPos.Y);
                default:
                    return (currentPos.X - MoveSize, currentPos.Y);
                    
            }           
        }
    }
}
