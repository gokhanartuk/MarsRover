using MarsRover.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core.Entities
{
    public class RoverPath
    {
        public RoverPath(Rover rover,List<Command> commands)
        {
            if (rover == null) throw new NullReferenceException("Rover path rover parameter cannot be null");
            if (commands == null || !commands.Any()) throw new NullReferenceException("Rover path rover commands cannot be null or empty");

            Rover = rover;
            Commands = commands;
        }        
        public Rover Rover { get; private set; }
        public List<Command> Commands { get; private set; }
    }
}
