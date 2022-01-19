using MarsRover.Core.Attributes;
using System;
using System.Linq;

namespace MarsRover.Core.Helpers
{
    public static class EnumExtensions
    {
        public static int GetDirectionIndex(this Enum val)
        {
            var directionIndexAttr = GetAttributeOfType<DirectionIndexAttribute>(val);

            return directionIndexAttr?.Index ?? default(int);
        }

        private static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            if (memInfo.Length <= 0) return null;
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes.FirstOrDefault();
        }
    }
}
