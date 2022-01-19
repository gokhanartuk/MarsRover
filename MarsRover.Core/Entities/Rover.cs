using MarsRover.Core.Enums;
using System;
using System.Collections.Generic;

namespace MarsRover.Core.Entities
{
    public class Rover
    {
        public Rover(uint id, uint xPoint, uint yPoint, Direction direction)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("Rover id parameter cannot be zero or negative");
            if (xPoint < 0) throw new ArgumentOutOfRangeException("Rover x-point cannot be negative");
            if (yPoint < 0) throw new ArgumentOutOfRangeException("Rover y-pointcannot be negative");

            Id = id;
            Position = (xPoint, yPoint);
            Direction = direction;          
        }


        public string Name => $"Rover {Id}";
        public uint Id { get; }
        public (uint X, uint Y) Position { get; set; }
        public Direction Direction { get; set; } 
        
        public bool HasError { get { return !string.IsNullOrEmpty(Error); } }
        public string Error { get; set; }
        public override string ToString()
        {
            return Error ?? $"{Position.X} {Position.Y} {Direction}";
        }
    }
}
