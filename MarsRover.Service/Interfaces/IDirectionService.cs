using MarsRover.Core.Enums;

namespace MarsRover.Service.Interfaces
{
    public interface IDirectionService
    {
        Direction GetNextDirection(Direction direction, Command command);
    }
}
