using MarsRover.Core.Entities;
using System.Collections.Generic;

namespace MarsRover.Service.Interfaces
{
    public interface IMissionService
    {
        IEnumerable<Rover> ExecuteMission(string command);
    }
}
