using System;

namespace MarsRover.Core.Attributes
{
    public class DirectionIndexAttribute : Attribute
    {
        public DirectionIndexAttribute(int index)
        {
            this.Index = index;
        }

        public DirectionIndexAttribute()
        {
        }

        public int Index { get; set; }
    }
}
