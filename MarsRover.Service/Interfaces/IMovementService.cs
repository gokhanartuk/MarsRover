using MarsRover.Core.Enums;

namespace MarsRover.Service.Interfaces
{
    public interface IMovementService
    {
        (uint X, uint Y) GetNextPosition((uint X, uint Y) currentPos, Direction moveDirection);
    }
}
