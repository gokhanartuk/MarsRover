using System;

namespace MarsRover.Core.Entities
{
    public class Plateau
    {
        public Plateau(uint width, uint height)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException("Width of Plateau cannot be zero or negative");
            if (height <= 0) throw new ArgumentOutOfRangeException("Height of Plateau cannot be zero or negative");

            Width = width;
            Height = height;
        }

        public uint Width { get; }
        public uint Height { get; }      
    }
}
